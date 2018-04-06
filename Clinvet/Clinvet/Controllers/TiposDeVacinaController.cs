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
    public class TiposDeVacinaController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: TiposDeVacina
        public async Task<ActionResult> Index()
        {
            return View(await db.TiposDeVacinas.ToListAsync());
        }

        // GET: TiposDeVacina/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDeVacina tiposDeVacina = await db.TiposDeVacinas.FindAsync(id);
            if (tiposDeVacina == null)
            {
                return HttpNotFound();
            }
            return View(tiposDeVacina);
        }

        // GET: TiposDeVacina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposDeVacina/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao")] TiposDeVacina tiposDeVacina)
        {
            if (ModelState.IsValid)
            {
                db.TiposDeVacinas.Add(tiposDeVacina);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tiposDeVacina);
        }

        // GET: TiposDeVacina/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDeVacina tiposDeVacina = await db.TiposDeVacinas.FindAsync(id);
            if (tiposDeVacina == null)
            {
                return HttpNotFound();
            }
            return View(tiposDeVacina);
        }

        // POST: TiposDeVacina/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao")] TiposDeVacina tiposDeVacina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposDeVacina).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tiposDeVacina);
        }

        // GET: TiposDeVacina/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDeVacina tiposDeVacina = await db.TiposDeVacinas.FindAsync(id);
            if (tiposDeVacina == null)
            {
                return HttpNotFound();
            }
            return View(tiposDeVacina);
        }

        // POST: TiposDeVacina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            TiposDeVacina tiposDeVacina = await db.TiposDeVacinas.FindAsync(id);
            db.TiposDeVacinas.Remove(tiposDeVacina);
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
