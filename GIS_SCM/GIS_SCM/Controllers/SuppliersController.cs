using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GIS_SCM.DAL;
using GIS_SCM.Models;

namespace GIS_SCM.Controllers
{
    public class SuppliersController : Controller
    {
        private GIS_SCMContext db = new GIS_SCMContext();

        // GET: Suppliers
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        public ActionResult supplierPlant(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            string plantmarkers = "[";



            using (var db = new GIS_SCMContext())
            {
               
                foreach (var plant in db.Plants)
                {

                    plantmarkers += "{";
                    plantmarkers += string.Format("'title': '{0} {1} {2}',", plant.PlantCode, " - ", plant.PlantName);
                    plantmarkers += string.Format("'lat': '{0}',", plant.Latitude);
                    plantmarkers += string.Format("'lng': '{0}'", plant.Longitude);
                    plantmarkers += "},";

                }

            }

            plantmarkers += "];";
            ViewBag.plantmarkers = plantmarkers;
            return View(supplier);
        }


        public ActionResult supplierStorageLocation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            string slocmarkers = "[";

             

            using (var db = new GIS_SCMContext())
            {
                var mystoragelocationlist = db.StorageLocations;
                var randomstoragelocation = mystoragelocationlist.OrderBy(x => Guid.NewGuid()).Take(8);

                foreach (var storageloc in randomstoragelocation)
                {

                    slocmarkers += "{";
                    slocmarkers += string.Format("'title': '{0} {1} {2}',", storageloc.StorageLocationNumber, " - ", storageloc.StorageLocationDesc);
                    slocmarkers += string.Format("'lat': '{0}',", storageloc.Latitude);
                    slocmarkers += string.Format("'lng': '{0}'", storageloc.Longitude);
                    slocmarkers += "},";

                }

            }

            slocmarkers += "];";
            ViewBag.slocmarkers = slocmarkers;
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SupplierNumber,SupplierName,Nationality,SupplierState,SupplierAddress,Latitude,Longitude")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SupplierNumber,SupplierName,Nationality,SupplierState,SupplierAddress,Latitude,Longitude")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }



        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
