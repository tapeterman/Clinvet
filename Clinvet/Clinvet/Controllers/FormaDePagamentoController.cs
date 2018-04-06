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
    public class FormaDePagamentoController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: FormaDePagamento
        public async Task<ActionResult> Index()
        {
            return View(await db.FormaDePagamentoes.ToListAsync());
        }

        // GET: FormaDePagamento/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDePagamento formaDePagamento = await db.FormaDePagamentoes.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao")] FormaDePagamento formaDePagamento)
        {
            if (ModelState.IsValid)
            {
                db.FormaDePagamentoes.Add(formaDePagamento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(formaDePagamento);
        }

        // GET: FormaDePagamento/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDePagamento formaDePagamento = await db.FormaDePagamentoes.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao")] FormaDePagamento formaDePagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formaDePagamento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(formaDePagamento);
        }

        // GET: FormaDePagamento/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDePagamento formaDePagamento = await db.FormaDePagamentoes.FindAsync(id);
            if (formaDePagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaDePagamento);
        }

        // POST: FormaDePagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            FormaDePagamento formaDePagamento = await db.FormaDePagamentoes.FindAsync(id);
            db.FormaDePagamentoes.Remove(formaDePagamento);
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
