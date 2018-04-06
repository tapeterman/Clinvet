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
    public class ProdutoServicoController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: ProdutoServico
        public async Task<ActionResult> Index()
        {
            return View(await db.ProdutoServicoes.ToListAsync());
        }

        // GET: ProdutoServico/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServico produtoServico = await db.ProdutoServicoes.FindAsync(id);
            if (produtoServico == null)
            {
                return HttpNotFound();
            }
            return View(produtoServico);
        }

        // GET: ProdutoServico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoServico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Marca,PrecoDeVenda,PrecoDeCompra,Validade,Lote,IdTipo")] ProdutoServico produtoServico)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoServicoes.Add(produtoServico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(produtoServico);
        }

        // GET: ProdutoServico/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServico produtoServico = await db.ProdutoServicoes.FindAsync(id);
            if (produtoServico == null)
            {
                return HttpNotFound();
            }
            return View(produtoServico);
        }

        // POST: ProdutoServico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Marca,PrecoDeVenda,PrecoDeCompra,Validade,Lote,IdTipo")] ProdutoServico produtoServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoServico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(produtoServico);
        }

        // GET: ProdutoServico/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServico produtoServico = await db.ProdutoServicoes.FindAsync(id);
            if (produtoServico == null)
            {
                return HttpNotFound();
            }
            return View(produtoServico);
        }

        // POST: ProdutoServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ProdutoServico produtoServico = await db.ProdutoServicoes.FindAsync(id);
            db.ProdutoServicoes.Remove(produtoServico);
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
