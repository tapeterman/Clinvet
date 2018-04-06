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
    public class TipoDeContaController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: TipoDeConta
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoDeContas.ToListAsync());
        }

        // GET: TipoDeConta/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeConta tipoDeConta = await db.TipoDeContas.FindAsync(id);
            if (tipoDeConta == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeConta);
        }

        // GET: TipoDeConta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeConta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao")] TipoDeConta tipoDeConta)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeContas.Add(tipoDeConta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoDeConta);
        }

        // GET: TipoDeConta/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeConta tipoDeConta = await db.TipoDeContas.FindAsync(id);
            if (tipoDeConta == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeConta);
        }

        // POST: TipoDeConta/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao")] TipoDeConta tipoDeConta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeConta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoDeConta);
        }

        // GET: TipoDeConta/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeConta tipoDeConta = await db.TipoDeContas.FindAsync(id);
            if (tipoDeConta == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeConta);
        }

        // POST: TipoDeConta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            TipoDeConta tipoDeConta = await db.TipoDeContas.FindAsync(id);
            db.TipoDeContas.Remove(tipoDeConta);
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
