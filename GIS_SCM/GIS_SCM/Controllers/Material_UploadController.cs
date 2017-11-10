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
    public class Material_UploadController : Controller
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GIS_SCMContext"].ConnectionString);
        OleDbConnection Econ;
        // GET: Material_Upload
        public ActionResult Index()
        {
            TempData["Notification"] = "";
            return View();
        }

        public ActionResult Index(HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            InsertExceldata(filepath, filename);
            TempData["Notification"] = "Supplier Master Data Uploaded Successfully";

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
            objbulk.DestinationTableName = "Material";
            objbulk.ColumnMappings.Add("MaterialCode", "MaterialCode");
            objbulk.ColumnMappings.Add("MaterialType", "MaterialType");
            objbulk.ColumnMappings.Add("MaterialDescription", "MaterialDescription");
            objbulk.ColumnMappings.Add("MaterialReorder", "MaterialReorder");
            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();




        }

    }
}