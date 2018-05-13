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
    public class FormaDePagamentoController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: FormaDePagamento
        public ActionResult Index()
        {
            return View(db.FormaDePagamento.ToList());
        }

        // GET: FormaDePagamento/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDePagamento formaDePagamento = db.FormaDePagamento.Find(id);
            if (formaDePagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaDePagamento);
        }

        // GET: FormaDePagamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaDePagamento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] FormaDePagamento formaDePagamento)
        {
            if (ModelState.IsValid)
            {
                db.FormaDePagamento.Add(formaDePagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formaDePagamento);
        }

        // GET: FormaDePagamento/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDePagamento formaDePagamento = db.FormaDePagamento.Find(id);
            if (formaDePagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaDePagamento);
        }

        // POST: FormaDePagamento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] FormaDePagamento formaDePagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formaDePagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formaDePagamento);
        }

        // GET: FormaDePagamento/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDePagamento formaDePagamento = db.FormaDePagamento.Find(id);
            if (formaDePagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaDePagamento);
        }

        // POST: FormaDePagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FormaDePagamento formaDePagamento = db.FormaDePagamento.Find(id);
            db.FormaDePagamento.Remove(formaDePagamento);
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
