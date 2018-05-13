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
    public class ProdutoServicoVendaServicoController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: ProdutoServicoVendaServico
        public ActionResult Index()
        {
            var produtoServicoVendaServico = db.ProdutoServicoVendaServico.Include(p => p.ProdutoServico).Include(p => p.VendaServico);
            return View(produtoServicoVendaServico.ToList());
        }

        // GET: ProdutoServicoVendaServico/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServicoVendaServico produtoServicoVendaServico = db.ProdutoServicoVendaServico.Find(id);
            if (produtoServicoVendaServico == null)
            {
                return HttpNotFound();
            }
            return View(produtoServicoVendaServico);
        }

        // GET: ProdutoServicoVendaServico/Create
        public ActionResult Create()
        {
            ViewBag.IdProdutoServico = new SelectList(db.ProdutoServico, "Id", "Nome");
            ViewBag.IdVendaServico = new SelectList(db.VendaServico, "Id", "Descricao");
            return View();
        }

        // POST: ProdutoServicoVendaServico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProdutoServicoVendaServico,IdProdutoServico,IdVendaServico,QuantidadeProduto,ValorProduto")] ProdutoServicoVendaServico produtoServicoVendaServico)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoServicoVendaServico.Add(produtoServicoVendaServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProdutoServico = new SelectList(db.ProdutoServico, "Id", "Nome", produtoServicoVendaServico.IdProdutoServico);
            ViewBag.IdVendaServico = new SelectList(db.VendaServico, "Id", "Descricao", produtoServicoVendaServico.IdVendaServico);
            return View(produtoServicoVendaServico);
        }

        // GET: ProdutoServicoVendaServico/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServicoVendaServico produtoServicoVendaServico = db.ProdutoServicoVendaServico.Find(id);
            if (produtoServicoVendaServico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProdutoServico = new SelectList(db.ProdutoServico, "Id", "Nome", produtoServicoVendaServico.IdProdutoServico);
            ViewBag.IdVendaServico = new SelectList(db.VendaServico, "Id", "Descricao", produtoServicoVendaServico.IdVendaServico);
            return View(produtoServicoVendaServico);
        }

        // POST: ProdutoServicoVendaServico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProdutoServicoVendaServico,IdProdutoServico,IdVendaServico,QuantidadeProduto,ValorProduto")] ProdutoServicoVendaServico produtoServicoVendaServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoServicoVendaServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProdutoServico = new SelectList(db.ProdutoServico, "Id", "Nome", produtoServicoVendaServico.IdProdutoServico);
            ViewBag.IdVendaServico = new SelectList(db.VendaServico, "Id", "Descricao", produtoServicoVendaServico.IdVendaServico);
            return View(produtoServicoVendaServico);
        }

        // GET: ProdutoServicoVendaServico/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServicoVendaServico produtoServicoVendaServico = db.ProdutoServicoVendaServico.Find(id);
            if (produtoServicoVendaServico == null)
            {
                return HttpNotFound();
            }
            return View(produtoServicoVendaServico);
        }

        // POST: ProdutoServicoVendaServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProdutoServicoVendaServico produtoServicoVendaServico = db.ProdutoServicoVendaServico.Find(id);
            db.ProdutoServicoVendaServico.Remove(produtoServicoVendaServico);
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
