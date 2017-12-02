using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GIS_SCM.DAL;

namespace GIS_SCM.Controllers
{
    public class DistributionCenterMapController : Controller
    {
        // GET: DistributionCenterMap
        public ActionResult Index()
        {
            string markers = "[";
            using (var db = new GIS_SCMContext())
            {
                foreach (var dc in db.DistributionCenters)
                {

                    markers += "{";
                    markers += string.Format("latLng: [{0} {1} {2}],", dc.Latitude, " , ", dc.Longitude);
                    markers += string.Format(" name: '{0}'", dc.DCDesc);
                    markers += "},";

                }

            }

            markers += "]";
            ViewBag.markers = markers;

            return View();
        }
    }
}