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
    public class TiposDeVacinaController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: TiposDeVacina
        public ActionResult Index()
        {
            return View(db.TiposDeVacina.ToList());
        }

        // GET: TiposDeVacina/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDeVacina tiposDeVacina = db.TiposDeVacina.Find(id);
            if (tiposDeVacina == null)
            {
                return HttpNotFound();
            }
            return View(tiposDeVacina);
        }

        // GET: TiposDeVacina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposDeVacina/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TiposDeVacina tiposDeVacina)
        {
            if (ModelState.IsValid)
            {
                db.TiposDeVacina.Add(tiposDeVacina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposDeVacina);
        }

        // GET: TiposDeVacina/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDeVacina tiposDeVacina = db.TiposDeVacina.Find(id);
            if (tiposDeVacina == null)
            {
                return HttpNotFound();
            }
            return View(tiposDeVacina);
        }

        // POST: TiposDeVacina/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TiposDeVacina tiposDeVacina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposDeVacina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposDeVacina);
        }

        // GET: TiposDeVacina/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDeVacina tiposDeVacina = db.TiposDeVacina.Find(id);
            if (tiposDeVacina == null)
            {
                return HttpNotFound();
            }
            return View(tiposDeVacina);
        }

        // POST: TiposDeVacina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TiposDeVacina tiposDeVacina = db.TiposDeVacina.Find(id);
            db.TiposDeVacina.Remove(tiposDeVacina);
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
