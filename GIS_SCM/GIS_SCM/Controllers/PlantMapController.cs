using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GIS_SCM.DAL;

namespace GIS_SCM.Controllers
{
    public class PlantMapController : Controller
    {
        // GET: PlantMap
        public ActionResult Index()
        {
            string markers = "[";
            using (var db = new GIS_SCMContext())
            {
                foreach (var plant in db.Plants)
                {

                    markers += "{";
                    markers += string.Format("latLng: [{0} {1} {2}],", plant.Latitude, " , ", plant.Longitude);
                    markers += string.Format(" name: '{0}'", plant.PlantName);
                    markers += "},";

                }

            }

            markers += "]";
            ViewBag.markers = markers;

            return View();
        }
    }
}