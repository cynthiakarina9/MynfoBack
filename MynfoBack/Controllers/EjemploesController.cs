using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MynfoBack.Models;

namespace MynfoBack.Controllers
{
    public class EjemploesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Ejemploes
        public ActionResult Index()
        {
            return View(db.Ejemploes.ToList());
        }

        // GET: Ejemploes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplo ejemplo = db.Ejemploes.Find(id);
            if (ejemplo == null)
            {
                return HttpNotFound();
            }
            return View(ejemplo);
        }

        // GET: Ejemploes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejemploes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EjemploID,Description,Price")] Ejemplo ejemplo)
        {
            if (ModelState.IsValid)
            {
                db.Ejemploes.Add(ejemplo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ejemplo);
        }

        // GET: Ejemploes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplo ejemplo = db.Ejemploes.Find(id);
            if (ejemplo == null)
            {
                return HttpNotFound();
            }
            return View(ejemplo);
        }

        // POST: Ejemploes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EjemploID,Description,Price")] Ejemplo ejemplo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ejemplo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ejemplo);
        }

        // GET: Ejemploes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplo ejemplo = db.Ejemploes.Find(id);
            if (ejemplo == null)
            {
                return HttpNotFound();
            }
            return View(ejemplo);
        }

        // POST: Ejemploes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ejemplo ejemplo = db.Ejemploes.Find(id);
            db.Ejemploes.Remove(ejemplo);
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
