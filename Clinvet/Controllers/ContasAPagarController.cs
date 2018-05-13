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
    public class ContasAPagarController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: ContasAPagar
        public ActionResult Index()
        {
            var contasAPagar = db.ContasAPagar.Include(c => c.Fornecedor).Include(c => c.TipoDeConta);
            return View(contasAPagar.ToList());
        }

        // GET: ContasAPagar/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasAPagar contasAPagar = db.ContasAPagar.Find(id);
            if (contasAPagar == null)
            {
                return HttpNotFound();
            }
            return View(contasAPagar);
        }

        // GET: ContasAPagar/Create
        public ActionResult Create()
        {
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "NomeFantasia");
            ViewBag.IdTipoDeConta = new SelectList(db.TipoDeConta, "Id", "Descricao");
            return View();
        }

        // POST: ContasAPagar/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Valor,IdFornecedor,IdTipoDeConta")] ContasAPagar contasAPagar)
        {
            if (ModelState.IsValid)
            {
                db.ContasAPagar.Add(contasAPagar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "NomeFantasia", contasAPagar.IdFornecedor);
            ViewBag.IdTipoDeConta = new SelectList(db.TipoDeConta, "Id", "Descricao", contasAPagar.IdTipoDeConta);
            return View(contasAPagar);
        }

        // GET: ContasAPagar/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasAPagar contasAPagar = db.ContasAPagar.Find(id);
            if (contasAPagar == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "NomeFantasia", contasAPagar.IdFornecedor);
            ViewBag.IdTipoDeConta = new SelectList(db.TipoDeConta, "Id", "Descricao", contasAPagar.IdTipoDeConta);
            return View(contasAPagar);
        }

        // POST: ContasAPagar/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Valor,IdFornecedor,IdTipoDeConta")] ContasAPagar contasAPagar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contasAPagar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "NomeFantasia", contasAPagar.IdFornecedor);
            ViewBag.IdTipoDeConta = new SelectList(db.TipoDeConta, "Id", "Descricao", contasAPagar.IdTipoDeConta);
            return View(contasAPagar);
        }

        // GET: ContasAPagar/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasAPagar contasAPagar = db.ContasAPagar.Find(id);
            if (contasAPagar == null)
            {
                return HttpNotFound();
            }
            return View(contasAPagar);
        }

        // POST: ContasAPagar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ContasAPagar contasAPagar = db.ContasAPagar.Find(id);
            db.ContasAPagar.Remove(contasAPagar);
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
