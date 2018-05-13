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
    public class FornecedorProdutoServicoController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: FornecedorProdutoServico
        public ActionResult Index()
        {
            var fornecedorProdutoServico = db.FornecedorProdutoServico.Include(f => f.Fornecedor).Include(f => f.ProdutoServico);
            return View(fornecedorProdutoServico.ToList());
        }

        // GET: FornecedorProdutoServico/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorProdutoServico fornecedorProdutoServico = db.FornecedorProdutoServico.Find(id);
            if (fornecedorProdutoServico == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorProdutoServico);
        }

        // GET: FornecedorProdutoServico/Create
        public ActionResult Create()
        {
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "NomeFantasia");
            ViewBag.IdProduto = new SelectList(db.ProdutoServico, "Id", "Nome");
            return View();
        }

        // POST: FornecedorProdutoServico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFornecedorProduto,IdFornecedor,IdProduto")] FornecedorProdutoServico fornecedorProdutoServico)
        {
            if (ModelState.IsValid)
            {
                db.FornecedorProdutoServico.Add(fornecedorProdutoServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "NomeFantasia", fornecedorProdutoServico.IdFornecedor);
            ViewBag.IdProduto = new SelectList(db.ProdutoServico, "Id", "Nome", fornecedorProdutoServico.IdProduto);
            return View(fornecedorProdutoServico);
        }

        // GET: FornecedorProdutoServico/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorProdutoServico fornecedorProdutoServico = db.FornecedorProdutoServico.Find(id);
            if (fornecedorProdutoServico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "NomeFantasia", fornecedorProdutoServico.IdFornecedor);
            ViewBag.IdProduto = new SelectList(db.ProdutoServico, "Id", "Nome", fornecedorProdutoServico.IdProduto);
            return View(fornecedorProdutoServico);
        }

        // POST: FornecedorProdutoServico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFornecedorProduto,IdFornecedor,IdProduto")] FornecedorProdutoServico fornecedorProdutoServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedorProdutoServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "Id", "NomeFantasia", fornecedorProdutoServico.IdFornecedor);
            ViewBag.IdProduto = new SelectList(db.ProdutoServico, "Id", "Nome", fornecedorProdutoServico.IdProduto);
            return View(fornecedorProdutoServico);
        }

        // GET: FornecedorProdutoServico/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorProdutoServico fornecedorProdutoServico = db.FornecedorProdutoServico.Find(id);
            if (fornecedorProdutoServico == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorProdutoServico);
        }

        // POST: FornecedorProdutoServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FornecedorProdutoServico fornecedorProdutoServico = db.FornecedorProdutoServico.Find(id);
            db.FornecedorProdutoServico.Remove(fornecedorProdutoServico);
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
