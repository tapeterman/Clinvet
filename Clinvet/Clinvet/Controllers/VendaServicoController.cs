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
    public class VendaServicoController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: VendaServico
        public async Task<ActionResult> Index()
        {
            return View(await db.VendaServicoes.ToListAsync());
        }

        // GET: VendaServico/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaServico vendaServico = await db.VendaServicoes.FindAsync(id);
            if (vendaServico == null)
            {
                return HttpNotFound();
            }
            return View(vendaServico);
        }

        // GET: VendaServico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendaServico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ValorTotal,Descricao,IdFuncionario,IdCliente,DataServico")] VendaServico vendaServico)
        {
            if (ModelState.IsValid)
            {
                db.VendaServicoes.Add(vendaServico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vendaServico);
        }

        // GET: VendaServico/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaServico vendaServico = await db.VendaServicoes.FindAsync(id);
            if (vendaServico == null)
            {
                return HttpNotFound();
            }
            return View(vendaServico);
        }

        // POST: VendaServico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ValorTotal,Descricao,IdFuncionario,IdCliente,DataServico")] VendaServico vendaServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendaServico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vendaServico);
        }

        // GET: VendaServico/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaServico vendaServico = await db.VendaServicoes.FindAsync(id);
            if (vendaServico == null)
            {
                return HttpNotFound();
            }
            return View(vendaServico);
        }

        // POST: VendaServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            VendaServico vendaServico = await db.VendaServicoes.FindAsync(id);
            db.VendaServicoes.Remove(vendaServico);
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
