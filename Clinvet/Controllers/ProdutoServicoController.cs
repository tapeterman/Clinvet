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
    public class ProdutoServicoController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: ProdutoServico
        public ActionResult Index()
        {
            var produtoServico = db.ProdutoServico.Include(p => p.Tipo);
            return View(produtoServico.ToList());
        }

        // GET: ProdutoServico/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServico produtoServico = db.ProdutoServico.Find(id);
            if (produtoServico == null)
            {
                return HttpNotFound();
            }
            return View(produtoServico);
        }

        // GET: ProdutoServico/Create
        public ActionResult Create()
        {
            ViewBag.IdTipo = new SelectList(db.Tipo, "Id", "Descricao");
            return View();
        }

        // POST: ProdutoServico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Marca,PrecoDeVenda,PrecoDeCompra,Validade,Lote,IdTipo")] ProdutoServico produtoServico)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoServico.Add(produtoServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipo = new SelectList(db.Tipo, "Id", "Descricao", produtoServico.IdTipo);
            return View(produtoServico);
        }

        // GET: ProdutoServico/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServico produtoServico = db.ProdutoServico.Find(id);
            if (produtoServico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipo = new SelectList(db.Tipo, "Id", "Descricao", produtoServico.IdTipo);
            return View(produtoServico);
        }

        // POST: ProdutoServico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Marca,PrecoDeVenda,PrecoDeCompra,Validade,Lote,IdTipo")] ProdutoServico produtoServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipo = new SelectList(db.Tipo, "Id", "Descricao", produtoServico.IdTipo);
            return View(produtoServico);
        }

        // GET: ProdutoServico/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServico produtoServico = db.ProdutoServico.Find(id);
            if (produtoServico == null)
            {
                return HttpNotFound();
            }
            return View(produtoServico);
        }

        // POST: ProdutoServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProdutoServico produtoServico = db.ProdutoServico.Find(id);
            db.ProdutoServico.Remove(produtoServico);
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
