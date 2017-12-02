using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using GIS_SCM.Models;
using GIS_SCM.DAL;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace GIS_SCM.Controllers
{
    public class Customer_UploadController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GIS_SCMContext"].ConnectionString);
        OleDbConnection Econ;
        // GET: Customer_Upload
        public ActionResult Index()
        {
            TempData["Notification"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            InsertExceldata(filepath, filename);

            using (var db = new GIS_SCMContext())
            {
                foreach (var customer in db.Customers)
                {
                    // Geocode Address
                    // Leverage Geocoding API using address
                    if (customer.Latitude == "NA" || customer.Longitude == "NA")
                     {
                        string strlong;
                        string strlat;

                    string physical_address = customer.CustomerAddress + " " + customer.CustomerState + " " + customer.Nationality;
                    string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key=AIzaSyCiTj6_U1FvAawzGsTg9ug9ZzJ7nP14H_E", Uri.EscapeDataString(physical_address));
                    WebRequest request = WebRequest.Create(requestUri);
                    WebResponse response = request.GetResponse();
                    XDocument xdoc = XDocument.Load(response.GetResponseStream());
                    XElement result = xdoc.Element("GeocodeResponse").Element("result");
                        if (result != null)
                        {
                            XElement locationElement = result.Element("geometry").Element("location");
                            XElement lat = locationElement.Element("lat");
                            XElement lng = locationElement.Element("lng");

                            string latitude = lat.ToString();
                            string longitude = lng.ToString();

                            strlong = longitude.Replace("<lng>", "").Replace("</lng>", "");
                            strlat = latitude.Replace("<lat>", "").Replace("</lat>", "");

                        }
                        else { 
                            strlong = "3.3333";
                            strlat = "6.5833";
                        }

                        customer.Latitude = strlat;
                    customer.Longitude = strlong;
                    db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    }
                }

                db.SaveChanges();
                TempData["Notification"] = "Customer Master Data Uploaded Successfully";

            }

            return View();
        }

        private void Excelconn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=Yes;""", filepath);
            Econ = new OleDbConnection(constr);

        }

        private void InsertExceldata(string fileepath, string filename)
        {
            string fullpath = Server.MapPath("/excelfolder/") + filename;
            Excelconn(fullpath);
            string query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);

            DataTable dt = ds.Tables[0];
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "Customer";
            objbulk.ColumnMappings.Add("CustomerNumber", "CustomerNumber");
            objbulk.ColumnMappings.Add("CustomerName", "CustomerName");
            objbulk.ColumnMappings.Add("Nationality", "Nationality");
            objbulk.ColumnMappings.Add("CustomerState", "CustomerState");
            objbulk.ColumnMappings.Add("CustomerAddress", "CustomerAddress");
            objbulk.ColumnMappings.Add("Latitude", "Latitude");
            objbulk.ColumnMappings.Add("Longitude", "Longitude");
            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();




        }

    }
}