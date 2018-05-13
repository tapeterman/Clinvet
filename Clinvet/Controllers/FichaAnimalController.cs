using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinvet.Models;

namespace Clinvet.Controllers
{
    public class FichaAnimalController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: FichaAnimal
        public ActionResult Index()
        {
            var fichaAnimal = db.FichaAnimal.Include(f => f.Animal);
            return View(fichaAnimal.ToList());
        }

        // GET: FichaAnimal/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaAnimal fichaAnimal = db.FichaAnimal.Find(id);
            if (fichaAnimal == null)
            {
                return HttpNotFound();
            }
            return View(fichaAnimal);
        }

        // GET: FichaAnimal/Create
        public ActionResult Create()
        {
            ViewBag.IdAnimal = new SelectList(db.Animal, "Id", "Nome");
            return View();
        }

        // POST: FichaAnimal/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PesoPorteAntesDosProcedimentos,IdAnimal")] FichaAnimal fichaAnimal)
        {
            if (ModelState.IsValid)
            {
                db.FichaAnimal.Add(fichaAnimal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnimal = new SelectList(db.Animal, "Id", "Nome", fichaAnimal.IdAnimal);
            return View(fichaAnimal);
        }

        // GET: FichaAnimal/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaAnimal fichaAnimal = db.FichaAnimal.Find(id);
            if (fichaAnimal == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAnimal = new SelectList(db.Animal, "Id", "Nome", fichaAnimal.IdAnimal);
            return View(fichaAnimal);
        }

        // POST: FichaAnimal/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PesoPorteAntesDosProcedimentos,IdAnimal")] FichaAnimal fichaAnimal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichaAnimal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAnimal = new SelectList(db.Animal, "Id", "Nome", fichaAnimal.IdAnimal);
            return View(fichaAnimal);
        }

        // GET: FichaAnimal/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaAnimal fichaAnimal = db.FichaAnimal.Find(id);
            if (fichaAnimal == null)
            {
                return HttpNotFound();
            }
            return View(fichaAnimal);
        }

        // POST: FichaAnimal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FichaAnimal fichaAnimal = db.FichaAnimal.Find(id);
            db.FichaAnimal.Remove(fichaAnimal);
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
