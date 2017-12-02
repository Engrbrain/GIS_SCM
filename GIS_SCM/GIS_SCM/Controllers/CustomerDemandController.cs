using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GIS_SCM.DAL;

namespace GIS_SCM.Controllers
{
    public class CustomerDemandController : Controller
    {
        // GET: CustomerDemand
        public ActionResult Index()
        {
            string items = "[";

            using (var db = new GIS_SCMContext())
            {
                var MaterialList = db.Materials;
                var finishedGoodsList = MaterialList.Where(x => x.MaterialType == "Finished Goods");
                if (finishedGoodsList != null)
                {
                    foreach (var material in finishedGoodsList)
                    {

                        items += "{";
                        items += string.Format("label: '{0} {1} {2}',", material.MaterialCode, " - ", material.MaterialDescription);
                        items += string.Format("value: '{0} {2}',", material.MaterialCode, " - ", material.MaterialDescription);
                        items += "},";

                    }

                }

                items += "];";
                ViewBag.items = items;
            }
            return View();
        }
    }
}