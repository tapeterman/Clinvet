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
    public class TipoController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: Tipo
        public ActionResult Index()
        {
            return View(db.Tipo.ToList());
        }

        // GET: Tipo/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // GET: Tipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Tipo.Add(tipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo);
        }

        // GET: Tipo/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // POST: Tipo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo);
        }

        // GET: Tipo/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // POST: Tipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tipo tipo = db.Tipo.Find(id);
            db.Tipo.Remove(tipo);
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
