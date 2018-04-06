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
    public class VacinaController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: Vacina
        public async Task<ActionResult> Index()
        {
            return View(await db.Vacinas.ToListAsync());
        }

        // GET: Vacina/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacina vacina = await db.Vacinas.FindAsync(id);
            if (vacina == null)
            {
                return HttpNotFound();
            }
            return View(vacina);
        }

        // GET: Vacina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacina/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Marca,Lote,Fornecedor,Validade,Custo,IdFichaAnimal,IdTiposDeVacina")] Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                db.Vacinas.Add(vacina);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vacina);
        }

        // GET: Vacina/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacina vacina = await db.Vacinas.FindAsync(id);
            if (vacina == null)
            {
                return HttpNotFound();
            }
            return View(vacina);
        }

        // POST: Vacina/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Marca,Lote,Fornecedor,Validade,Custo,IdFichaAnimal,IdTiposDeVacina")] Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacina).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vacina);
        }

        // GET: Vacina/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacina vacina = await db.Vacinas.FindAsync(id);
            if (vacina == null)
            {
                return HttpNotFound();
            }
            return View(vacina);
        }

        // POST: Vacina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Vacina vacina = await db.Vacinas.FindAsync(id);
            db.Vacinas.Remove(vacina);
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
