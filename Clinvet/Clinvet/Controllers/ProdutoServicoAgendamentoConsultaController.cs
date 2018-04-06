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
    public class ProdutoServicoAgendamentoConsultaController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: ProdutoServicoAgendamentoConsulta
        public async Task<ActionResult> Index()
        {
            return View(await db.ProdutoServicoAgendamentoConsultas.ToListAsync());
        }

        // GET: ProdutoServicoAgendamentoConsulta/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas = await db.ProdutoServicoAgendamentoConsultas.FindAsync(id);
            if (produtoServicoAgendamentoConsultas == null)
            {
                return HttpNotFound();
            }
            return View(produtoServicoAgendamentoConsultas);
        }

        // GET: ProdutoServicoAgendamentoConsulta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoServicoAgendamentoConsulta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdProdutoServicoAgendamentoConsulta,IdProdutoServico,IdAgendamentoConsulta")] ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoServicoAgendamentoConsultas.Add(produtoServicoAgendamentoConsultas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(produtoServicoAgendamentoConsultas);
        }

        // GET: ProdutoServicoAgendamentoConsulta/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas = await db.ProdutoServicoAgendamentoConsultas.FindAsync(id);
            if (produtoServicoAgendamentoConsultas == null)
            {
                return HttpNotFound();
            }
            return View(produtoServicoAgendamentoConsultas);
        }

        // POST: ProdutoServicoAgendamentoConsulta/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdProdutoServicoAgendamentoConsulta,IdProdutoServico,IdAgendamentoConsulta")] ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoServicoAgendamentoConsultas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(produtoServicoAgendamentoConsultas);
        }

        // GET: ProdutoServicoAgendamentoConsulta/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas = await db.ProdutoServicoAgendamentoConsultas.FindAsync(id);
            if (produtoServicoAgendamentoConsultas == null)
            {
                return HttpNotFound();
            }
            return View(produtoServicoAgendamentoConsultas);
        }

        // POST: ProdutoServicoAgendamentoConsulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas = await db.ProdutoServicoAgendamentoConsultas.FindAsync(id);
            db.ProdutoServicoAgendamentoConsultas.Remove(produtoServicoAgendamentoConsultas);
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
