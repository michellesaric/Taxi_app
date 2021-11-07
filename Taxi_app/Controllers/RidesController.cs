using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Taxi_app.DAL;
using Taxi_app.Models;

namespace Taxi_app.Controllers
{
    public class RidesController : Controller
    {
        private Taxi01Context db = new Taxi01Context();

        // GET: Rides
        public ActionResult Index()
        {
            var rides = db.Rides.Include(r => r.Driver).Include(r => r.EndLocation).Include(r => r.Passenger).Include(r => r.StartLocation).Include(r => r.Vehicle);
            return View(rides.ToList());
        }

        // GET: Rides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ride ride = db.Rides.Find(id);
            if (ride == null)
            {
                return HttpNotFound();
            }
            return View(ride);
        }

        // GET: Rides/Create
        public ActionResult Create(int? driverId)
        {
            // ViewBag.DriverId = new SelectList(db.Drivers, "ID", "Name");
            ViewBag.EndLocationId = new SelectList(db.Cities, "ID", "Name");
            ViewBag.PassengerId = new SelectList(db.Passengers, "ID", "Name");
            ViewBag.StartLocationId = new SelectList(db.Cities, "ID", "Name");
            // ViewBag.VehicleId = new SelectList(db.Vehicles, "ID", "Brand");

            var drivers = db.Drivers;
            if (driverId != null)
            {
                var chosenDriver = drivers.Find(driverId);
                ViewBag.DriverSelectList = new SelectList(drivers, "ID", "Fullname", chosenDriver.Fullname);
                ViewBag.VehicleSelectList = new SelectList(db.Vehicles.Where(v => v.DriverId == driverId), "ID", "Fullname");
            }
            else
            {
                int firstId = drivers.FirstOrDefault().ID;
                ViewBag.DriverSelectList = new SelectList(drivers, "ID", "Fullname", firstId);
                ViewBag.VehicleSelectList = new SelectList(db.Vehicles.Where(v => v.DriverId == firstId), "ID", "Fullname");
            }
            return View();
        }

        // POST: Rides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StartLocationId,EndLocationId,VehicleId,DriverId,PassengerId,Time")] Ride ride)
        {
            if (ModelState.IsValid)
            {
                db.Rides.Add(ride);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverId = new SelectList(db.Drivers, "ID", "Name", ride.DriverId);
            ViewBag.EndLocationId = new SelectList(db.Cities, "ID", "Name", ride.EndLocationId);
            ViewBag.PassengerId = new SelectList(db.Passengers, "ID", "Name", ride.PassengerId);
            ViewBag.StartLocationId = new SelectList(db.Cities, "ID", "Name", ride.StartLocationId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "ID", "Brand", ride.VehicleId);
            return View(ride);
        }

        // GET: Rides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ride ride = db.Rides.Find(id);
            if (ride == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(db.Drivers, "ID", "Name", ride.DriverId);
            ViewBag.EndLocationId = new SelectList(db.Cities, "ID", "Name", ride.EndLocationId);
            ViewBag.PassengerId = new SelectList(db.Passengers, "ID", "Name", ride.PassengerId);
            ViewBag.StartLocationId = new SelectList(db.Cities, "ID", "Name", ride.StartLocationId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "ID", "Brand", ride.VehicleId);
            return View(ride);
        }

        // POST: Rides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StartLocationId,EndLocationId,VehicleId,DriverId,PassengerId,Time")] Ride ride)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ride).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverId = new SelectList(db.Drivers, "ID", "Name", ride.DriverId);
            ViewBag.EndLocationId = new SelectList(db.Cities, "ID", "Name", ride.EndLocationId);
            ViewBag.PassengerId = new SelectList(db.Passengers, "ID", "Name", ride.PassengerId);
            ViewBag.StartLocationId = new SelectList(db.Cities, "ID", "Name", ride.StartLocationId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "ID", "Brand", ride.VehicleId);
            return View(ride);
        }

        // GET: Rides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ride ride = db.Rides.Find(id);
            if (ride == null)
            {
                return HttpNotFound();
            }
            return View(ride);
        }

        // POST: Rides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ride ride = db.Rides.Find(id);
            db.Rides.Remove(ride);
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
