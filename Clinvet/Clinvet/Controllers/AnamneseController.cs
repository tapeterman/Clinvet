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
    public class AnamneseController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: Anamnese
        public async Task<ActionResult> Index()
        {
            return View(await db.Anamnese.ToListAsync());
        }

        // GET: Anamnese/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anamnese anamnese = await db.Anamnese.FindAsync(id);
            if (anamnese == null)
            {
                return HttpNotFound();
            }
            return View(anamnese);
        }

        // GET: Anamnese/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anamnese/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Diagnostico,Anamnese1,Medicamentos,ProcedimentosRealizados,IdFichaAnimal")] Anamnese anamnese)
        {
            if (ModelState.IsValid)
            {
                db.Anamnese.Add(anamnese);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(anamnese);
        }

        // GET: Anamnese/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anamnese anamnese = await db.Anamnese.FindAsync(id);
            if (anamnese == null)
            {
                return HttpNotFound();
            }
            return View(anamnese);
        }

        // POST: Anamnese/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Diagnostico,Anamnese1,Medicamentos,ProcedimentosRealizados,IdFichaAnimal")] Anamnese anamnese)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anamnese).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(anamnese);
        }

        // GET: Anamnese/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anamnese anamnese = await db.Anamnese.FindAsync(id);
            if (anamnese == null)
            {
                return HttpNotFound();
            }
            return View(anamnese);
        }

        // POST: Anamnese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Anamnese anamnese = await db.Anamnese.FindAsync(id);
            db.Anamnese.Remove(anamnese);
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
