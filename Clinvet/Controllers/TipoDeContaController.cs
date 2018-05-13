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
    public class TipoDeContaController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: TipoDeConta
        public ActionResult Index()
        {
            return View(db.TipoDeConta.ToList());
        }

        // GET: TipoDeConta/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeConta tipoDeConta = db.TipoDeConta.Find(id);
            if (tipoDeConta == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeConta);
        }

        // GET: TipoDeConta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeConta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TipoDeConta tipoDeConta)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeConta.Add(tipoDeConta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeConta);
        }

        // GET: TipoDeConta/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeConta tipoDeConta = db.TipoDeConta.Find(id);
            if (tipoDeConta == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeConta);
        }

        // POST: TipoDeConta/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TipoDeConta tipoDeConta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeConta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeConta);
        }

        // GET: TipoDeConta/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeConta tipoDeConta = db.TipoDeConta.Find(id);
            if (tipoDeConta == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeConta);
        }

        // POST: TipoDeConta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TipoDeConta tipoDeConta = db.TipoDeConta.Find(id);
            db.TipoDeConta.Remove(tipoDeConta);
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
