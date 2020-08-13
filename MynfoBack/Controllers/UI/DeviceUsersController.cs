using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MynfoBack.Models;

namespace MynfoBack.Controllers.UI
{
    public class DeviceUsersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DeviceUsers
        public ActionResult Index()
        {
            return View(db.DeviceUsers.ToList());
        }

        // GET: DeviceUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceUser deviceUser = db.DeviceUsers.Find(id);
            if (deviceUser == null)
            {
                return HttpNotFound();
            }
            return View(deviceUser);
        }

        // GET: DeviceUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeviceUserID,NickName,FirstName,LastName,Password")] DeviceUser deviceUser)
        {
            if (ModelState.IsValid)
            {
                db.DeviceUsers.Add(deviceUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deviceUser);
        }

        // GET: DeviceUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceUser deviceUser = db.DeviceUsers.Find(id);
            if (deviceUser == null)
            {
                return HttpNotFound();
            }
            return View(deviceUser);
        }

        // POST: DeviceUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeviceUserID,NickName,FirstName,LastName,Password")] DeviceUser deviceUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deviceUser);
        }

        // GET: DeviceUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceUser deviceUser = db.DeviceUsers.Find(id);
            if (deviceUser == null)
            {
                return HttpNotFound();
            }
            return View(deviceUser);
        }

        // POST: DeviceUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeviceUser deviceUser = db.DeviceUsers.Find(id);
            db.DeviceUsers.Remove(deviceUser);
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
