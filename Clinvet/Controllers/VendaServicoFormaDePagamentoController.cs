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
    public class VendaServicoFormaDePagamentoController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: VendaServicoFormaDePagamento
        public ActionResult Index()
        {
            var vendaServicoFormaDePagamento = db.VendaServicoFormaDePagamento.Include(v => v.FormaDePagamento).Include(v => v.VendaServico);
            return View(vendaServicoFormaDePagamento.ToList());
        }

        // GET: VendaServicoFormaDePagamento/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaServicoFormaDePagamento vendaServicoFormaDePagamento = db.VendaServicoFormaDePagamento.Find(id);
            if (vendaServicoFormaDePagamento == null)
            {
                return HttpNotFound();
            }
            return View(vendaServicoFormaDePagamento);
        }

        // GET: VendaServicoFormaDePagamento/Create
        public ActionResult Create()
        {
            ViewBag.IdFormaDePagamento = new SelectList(db.FormaDePagamento, "Id", "Descricao");
            ViewBag.IdVendaServico = new SelectList(db.VendaServico, "Id", "Descricao");
            return View();
        }

        // POST: VendaServicoFormaDePagamento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVendaServicoFormaDePagamento,IdVendaServico,IdFormaDePagamento")] VendaServicoFormaDePagamento vendaServicoFormaDePagamento)
        {
            if (ModelState.IsValid)
            {
                db.VendaServicoFormaDePagamento.Add(vendaServicoFormaDePagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFormaDePagamento = new SelectList(db.FormaDePagamento, "Id", "Descricao", vendaServicoFormaDePagamento.IdFormaDePagamento);
            ViewBag.IdVendaServico = new SelectList(db.VendaServico, "Id", "Descricao", vendaServicoFormaDePagamento.IdVendaServico);
            return View(vendaServicoFormaDePagamento);
        }

        // GET: VendaServicoFormaDePagamento/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaServicoFormaDePagamento vendaServicoFormaDePagamento = db.VendaServicoFormaDePagamento.Find(id);
            if (vendaServicoFormaDePagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFormaDePagamento = new SelectList(db.FormaDePagamento, "Id", "Descricao", vendaServicoFormaDePagamento.IdFormaDePagamento);
            ViewBag.IdVendaServico = new SelectList(db.VendaServico, "Id", "Descricao", vendaServicoFormaDePagamento.IdVendaServico);
            return View(vendaServicoFormaDePagamento);
        }

        // POST: VendaServicoFormaDePagamento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVendaServicoFormaDePagamento,IdVendaServico,IdFormaDePagamento")] VendaServicoFormaDePagamento vendaServicoFormaDePagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendaServicoFormaDePagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFormaDePagamento = new SelectList(db.FormaDePagamento, "Id", "Descricao", vendaServicoFormaDePagamento.IdFormaDePagamento);
            ViewBag.IdVendaServico = new SelectList(db.VendaServico, "Id", "Descricao", vendaServicoFormaDePagamento.IdVendaServico);
            return View(vendaServicoFormaDePagamento);
        }

        // GET: VendaServicoFormaDePagamento/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaServicoFormaDePagamento vendaServicoFormaDePagamento = db.VendaServicoFormaDePagamento.Find(id);
            if (vendaServicoFormaDePagamento == null)
            {
                return HttpNotFound();
            }
            return View(vendaServicoFormaDePagamento);
        }

        // POST: VendaServicoFormaDePagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VendaServicoFormaDePagamento vendaServicoFormaDePagamento = db.VendaServicoFormaDePagamento.Find(id);
            db.VendaServicoFormaDePagamento.Remove(vendaServicoFormaDePagamento);
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
