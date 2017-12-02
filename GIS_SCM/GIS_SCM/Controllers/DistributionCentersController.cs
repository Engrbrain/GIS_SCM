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
    public class DistributionCentersController : Controller
    {
        private GIS_SCMContext db = new GIS_SCMContext();

        // GET: DistributionCenters
        public ActionResult Index()
        {
            var distributionCenters = db.DistributionCenters.Include(d => d.Plant);
            return View(distributionCenters.ToList());
        }

        // GET: DistributionCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributionCenter distributionCenter = db.DistributionCenters.Find(id);
            if (distributionCenter == null)
            {
                return HttpNotFound();
            }
            return View(distributionCenter);
        }

        // GET: DistributionCenters/Create
        public ActionResult Create()
        {
            ViewBag.PlantID = new SelectList(db.Plants, "ID", "PlantCode");
            return View();
        }

        // POST: DistributionCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlantID,DCNumber,DCDesc,DCAddress,Latitude,Longitude")] DistributionCenter distributionCenter)
        {
            if (ModelState.IsValid)
            {
                db.DistributionCenters.Add(distributionCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantID = new SelectList(db.Plants, "ID", "PlantCode", distributionCenter.PlantID);
            return View(distributionCenter);
        }

        // GET: DistributionCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributionCenter distributionCenter = db.DistributionCenters.Find(id);
            if (distributionCenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantID = new SelectList(db.Plants, "ID", "PlantCode", distributionCenter.PlantID);
            return View(distributionCenter);
        }

        // POST: DistributionCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlantID,DCNumber,DCDesc,DCAddress,Latitude,Longitude")] DistributionCenter distributionCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distributionCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantID = new SelectList(db.Plants, "ID", "PlantCode", distributionCenter.PlantID);
            return View(distributionCenter);
        }

        // GET: DistributionCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributionCenter distributionCenter = db.DistributionCenters.Find(id);
            if (distributionCenter == null)
            {
                return HttpNotFound();
            }
            return View(distributionCenter);
        }

        // POST: DistributionCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DistributionCenter distributionCenter = db.DistributionCenters.Find(id);
            db.DistributionCenters.Remove(distributionCenter);
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
