using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GIS_SCM.DAL;

namespace GIS_SCM.Controllers
{
    public class CustomerMapController : Controller
    {
        // GET: CustomerMap
        public ActionResult Index()
        {
            string markers = "[";



            using (var db = new GIS_SCMContext())
            {
                var mycustomerslist = db.Customers;
                var randomcustomers = mycustomerslist.OrderBy(x => Guid.NewGuid()).Take(3000);
                foreach (var customer in randomcustomers)
                {

                    markers += "{";
                    markers += string.Format("'title': '{0} {1} {2}',", customer.CustomerNumber, " - ", customer.CustomerName);
                    markers += string.Format("'lat': '{0}',", customer.Latitude);
                    markers += string.Format("'lng': '{0}'", customer.Longitude);
                    markers += "},";

                }

            }

            markers += "];";
            ViewBag.Markers = markers;

            return View();
        }
    }
    
}