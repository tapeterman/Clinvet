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
    public class FichaAnimalController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: FichaAnimal
        public async Task<ActionResult> Index()
        {
            return View(await db.FichaAnimals.ToListAsync());
        }

        // GET: FichaAnimal/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaAnimal fichaAnimal = await db.FichaAnimals.FindAsync(id);
            if (fichaAnimal == null)
            {
                return HttpNotFound();
            }
            return View(fichaAnimal);
        }

        // GET: FichaAnimal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FichaAnimal/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PesoPorteAntesDosProcedimentos,IdAnimal")] FichaAnimal fichaAnimal)
        {
            if (ModelState.IsValid)
            {
                db.FichaAnimals.Add(fichaAnimal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fichaAnimal);
        }

        // GET: FichaAnimal/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaAnimal fichaAnimal = await db.FichaAnimals.FindAsync(id);
            if (fichaAnimal == null)
            {
                return HttpNotFound();
            }
            return View(fichaAnimal);
        }

        // POST: FichaAnimal/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PesoPorteAntesDosProcedimentos,IdAnimal")] FichaAnimal fichaAnimal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichaAnimal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fichaAnimal);
        }

        // GET: FichaAnimal/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaAnimal fichaAnimal = await db.FichaAnimals.FindAsync(id);
            if (fichaAnimal == null)
            {
                return HttpNotFound();
            }
            return View(fichaAnimal);
        }

        // POST: FichaAnimal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            FichaAnimal fichaAnimal = await db.FichaAnimals.FindAsync(id);
            db.FichaAnimals.Remove(fichaAnimal);
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
