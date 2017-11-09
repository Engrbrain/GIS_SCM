using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Configuration;
using System.Web.UI;
using System.Net;
using System.Xml.Linq;
using GIS_SCM.Models;
using GIS_SCM.DAL;

namespace GIS_SCM.Controllers
{
    public class UploadCustomerController : Controller
    {
        private CustomerContext db = new CustomerContext();
        // GET: UploadCustomer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadCustomers ()
        {
            
            string drive = ConfigurationManager.AppSettings["DrivePath"].ToString();
            string line = @"\";

            HttpPostedFileBase uploadfile = null;

            foreach (string file in HttpContext.Request.Files)
            {
                uploadfile = Request.Files[file] as HttpPostedFileBase;
            }

            if ((uploadfile != null) && (uploadfile.ContentLength > 0) && !string.IsNullOrEmpty(uploadfile.FileName))
            {
                byte[] fileBlob = new byte[uploadfile.ContentLength]; //new byte[uploadfile.InputStream.Length];
                var data = uploadfile.InputStream.Read(fileBlob, 0, Convert.ToInt32(uploadfile.ContentLength)); //fileBlob.Length

                if (uploadfile.FileName.EndsWith(".xls") || uploadfile.FileName.EndsWith(".xlsx"))
                {
                    string path = Path.Combine(drive + "GIS_SCM" + line + "Archive" + line + "Resources" + line + "Customer" + line + uploadfile.FileName);
                    if (path == null)
                    {
                        TempData["Notification"] = "Path does not exist, Please confirm if the path exist or not.";
                    }
                    else if (System.IO.File.Exists(path)) {
                        TempData["Notification"] = "File Name Already Exist, Please be sure the file hasn't been uploaded before!";

                    }

                    // Read data from excel file
                    List<Customer> listCustomer = new List<Customer>();
                    
                    using (var package = new ExcelPackage(uploadfile.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;

                      
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            Customer c = new Customer();
                            c.CustomerAddress = workSheet.Cells[rowIterator, 6].Text.ToString();
                            c.CustomerName = workSheet.Cells[rowIterator, 3].Text.ToString();
                            c.CustomerNumber = workSheet.Cells[rowIterator, 2].Text.ToString();
                            c.CustomerState = workSheet.Cells[rowIterator, 5].Text.ToString();
                            c.Nationality = workSheet.Cells[rowIterator, 4].Text.ToString();

                            // Leverage Geocoding API using address
                            string physical_address1 = c.CustomerAddress + c.CustomerState + c.Nationality;
                            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key=AIzaSyCiTj6_U1FvAawzGsTg9ug9ZzJ7nP14H_E", Uri.EscapeDataString(physical_address));

                            WebRequest request = WebRequest.Create(requestUri);
                            WebResponse response = request.GetResponse();
                            XDocument xdoc = XDocument.Load(response.GetResponseStream());
                            XElement result = xdoc.Element("GeocodeResponse").Element("result");
                            XElement locationElement = result.Element("geometry").Element("location");
                            XElement lat = locationElement.Element("lat");
                            XElement lng = locationElement.Element("lng");

                            string latitude = lat.ToString();
                            string longitude = lng.ToString();

                            c.Latitude = latitude;
                            c.Longitude = longitude;
                            db.Customers.Add(c);
                            db.SaveChanges();
                        }

                       }
                      
                    }

            }
    }
}