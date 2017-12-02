using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GIS_SCM.Models;
using GIS_SCM.DAL;

namespace GIS_SCM.Controllers
{
    public class TruckLocationMapController : Controller
    {
        // GET: TruckLocationMap
        public ActionResult Index()
        {
            string markers = "[";



            using (var db = new GIS_SCMContext())
            {
               
                foreach (var truck in db.Trucks)
                {

                    markers += "{";
                    markers += string.Format("'title': '{0} {1} {2}',", truck.TruckNumber, " - ", truck.TruckModel);
                    markers += string.Format("'lat': '{0}',", truck.LastParkedLatitude);
                    markers += string.Format("'lng': '{0}'", truck.LastParkedLongitude);
                    markers += "},";

                }

            }

            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
    }
}