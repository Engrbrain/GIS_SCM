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
    public class StorageLocationsController : Controller
    {
        private GIS_SCMContext db = new GIS_SCMContext();

        // GET: StorageLocations
        public ActionResult Index()
        {
            var storageLocations = db.StorageLocations.Include(s => s.Plant);
            return View(storageLocations.ToList());
        }

        // GET: StorageLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageLocation storageLocation = db.StorageLocations.Find(id);
            if (storageLocation == null)
            {
                return HttpNotFound();
            }
            return View(storageLocation);
        }

        // GET: StorageLocations/Create
        public ActionResult Create()
        {
            ViewBag.PlantID = new SelectList(db.Plants, "ID", "PlantCode");
            return View();
        }

        // POST: StorageLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlantID,StorageLocationNumber,StorageLocationDesc,StorageLocationAddress,Latitude,Longitude")] StorageLocation storageLocation)
        {
            if (ModelState.IsValid)
            {
                db.StorageLocations.Add(storageLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantID = new SelectList(db.Plants, "ID", "PlantCode", storageLocation.PlantID);
            return View(storageLocation);
        }

        // GET: StorageLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageLocation storageLocation = db.StorageLocations.Find(id);
            if (storageLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantID = new SelectList(db.Plants, "ID", "PlantCode", storageLocation.PlantID);
            return View(storageLocation);
        }

        // POST: StorageLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlantID,StorageLocationNumber,StorageLocationDesc,StorageLocationAddress,Latitude,Longitude")] StorageLocation storageLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storageLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantID = new SelectList(db.Plants, "ID", "PlantCode", storageLocation.PlantID);
            return View(storageLocation);
        }

        // GET: StorageLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageLocation storageLocation = db.StorageLocations.Find(id);
            if (storageLocation == null)
            {
                return HttpNotFound();
            }
            return View(storageLocation);
        }

        // POST: StorageLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StorageLocation storageLocation = db.StorageLocations.Find(id);
            db.StorageLocations.Remove(storageLocation);
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
