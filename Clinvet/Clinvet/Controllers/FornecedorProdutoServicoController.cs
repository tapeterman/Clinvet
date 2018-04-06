using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinvet.Models;

namespace Clinvet.Controllers
{
    public class FornecedorProdutoServicoController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: FornecedorProdutoServico
        public async Task<ActionResult> Index()
        {
            return View(await db.FornecedorProdutoServicoes.ToListAsync());
        }

        // GET: FornecedorProdutoServico/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorProdutoServico fornecedorProdutoServico = await db.FornecedorProdutoServicoes.FindAsync(id);
            if (fornecedorProdutoServico == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorProdutoServico);
        }

        // GET: FornecedorProdutoServico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FornecedorProdutoServico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdFornecedorProduto,IdFornecedor,IdProduto")] FornecedorProdutoServico fornecedorProdutoServico)
        {
            if (ModelState.IsValid)
            {
                db.FornecedorProdutoServicoes.Add(fornecedorProdutoServico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fornecedorProdutoServico);
        }

        // GET: FornecedorProdutoServico/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorProdutoServico fornecedorProdutoServico = await db.FornecedorProdutoServicoes.FindAsync(id);
            if (fornecedorProdutoServico == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorProdutoServico);
        }

        // POST: FornecedorProdutoServico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdFornecedorProduto,IdFornecedor,IdProduto")] FornecedorProdutoServico fornecedorProdutoServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedorProdutoServico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fornecedorProdutoServico);
        }

        // GET: FornecedorProdutoServico/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorProdutoServico fornecedorProdutoServico = await db.FornecedorProdutoServicoes.FindAsync(id);
            if (fornecedorProdutoServico == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorProdutoServico);
        }

        // POST: FornecedorProdutoServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            FornecedorProdutoServico fornecedorProdutoServico = await db.FornecedorProdutoServicoes.FindAsync(id);
            db.FornecedorProdutoServicoes.Remove(fornecedorProdutoServico);
            await db.SaveChangesAsync();
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
