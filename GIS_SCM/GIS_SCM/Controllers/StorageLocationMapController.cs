using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GIS_SCM.DAL;

namespace GIS_SCM.Controllers
{
    public class StorageLocationMapController : Controller
    {
        // GET: StorageLocationMap
        public ActionResult Index()
        {
            string markers = "[";
            using (var db = new GIS_SCMContext())
            {
                foreach (var storagelocation in db.StorageLocations)
                {

                    markers += "{";
                    markers += string.Format("latLng: [{0} {1} {2}],", storagelocation.Latitude, " , ", storagelocation.Longitude);
                    markers += string.Format(" name: '{0}'", storagelocation.StorageLocationDesc);
                    markers += "},";

                }

            }

            markers += "]";
            ViewBag.markers = markers;

            return View();
        }
    }
}