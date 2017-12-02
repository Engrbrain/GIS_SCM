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
    public class TransportersController : Controller
    {
        private GIS_SCMContext db = new GIS_SCMContext();

        // GET: Transporters
        public ActionResult Index()
        {
            var transporters = db.Transporters.Include(t => t.Truck);
            return View(transporters.ToList());
        }

        // GET: Transporters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            if (transporter == null)
            {
                return HttpNotFound();
            }
            return View(transporter);
        }

        // GET: Transporters/Create
        public ActionResult Create()
        {
            ViewBag.TruckID = new SelectList(db.Trucks, "ID", "TruckNumber");
            return View();
        }

        // POST: Transporters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TruckID,TransporterNumber,TransporterName,Nationality,TransporterState,TransporterAddress,Latitude,Longitude")] Transporter transporter)
        {
            if (ModelState.IsValid)
            {
                db.Transporters.Add(transporter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TruckID = new SelectList(db.Trucks, "ID", "TruckNumber", transporter.TruckID);
            return View(transporter);
        }

        // GET: Transporters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            if (transporter == null)
            {
                return HttpNotFound();
            }
            ViewBag.TruckID = new SelectList(db.Trucks, "ID", "TruckNumber", transporter.TruckID);
            return View(transporter);
        }

        // POST: Transporters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TruckID,TransporterNumber,TransporterName,Nationality,TransporterState,TransporterAddress,Latitude,Longitude")] Transporter transporter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transporter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TruckID = new SelectList(db.Trucks, "ID", "TruckNumber", transporter.TruckID);
            return View(transporter);
        }

        // GET: Transporters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            if (transporter == null)
            {
                return HttpNotFound();
            }
            return View(transporter);
        }

        // POST: Transporters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transporter transporter = db.Transporters.Find(id);
            db.Transporters.Remove(transporter);
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
