using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GIS_SCM.Models;
using GIS_SCM.DAL;

namespace GIS_SCM.Controllers
{
    public class SuppliersMapController : Controller
    {
        // GET: SuppliersMap
        public ActionResult Index()
        {
            string markers = "[";
            
           
           
            using (var db = new GIS_SCMContext())
            {
                var mysupplierslist = db.Suppliers;
                var randomsuppliers = mysupplierslist.OrderBy(x => Guid.NewGuid()).Take(3000);
                foreach (var supplier in randomsuppliers)
                {
                    
                        markers += "{";
                        markers += string.Format("'title': '{0} {1} {2}',", supplier.SupplierNumber, " - ", supplier.SupplierName);
                        markers += string.Format("'lat': '{0}',", supplier.Latitude);
                        markers += string.Format("'lng': '{0}'", supplier.Longitude);
                        markers += "},";
                   
                }
               
            }

            markers += "];";
            ViewBag.Markers = markers;
            
            return View();
        }
    }
}