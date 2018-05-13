using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinvet.Models;

namespace Clinvet.Controllers
{
    public class AnamneseController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: Anamnese
        public ActionResult Index()
        {
            var anamnese = db.Anamnese.Include(a => a.FichaAnimal);
            return View(anamnese.ToList());
        }

        // GET: Anamnese/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anamnese anamnese = db.Anamnese.Find(id);
            if (anamnese == null)
            {
                return HttpNotFound();
            }
            return View(anamnese);
        }

        // GET: Anamnese/Create
        public ActionResult Create()
        {
            ViewBag.IdFichaAnimal = new SelectList(db.FichaAnimal, "Id", "PesoPorteAntesDosProcedimentos");
            return View();
        }

        // POST: Anamnese/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Diagnostico,Anamnese1,Medicamentos,ProcedimentosRealizados,IdFichaAnimal")] Anamnese anamnese)
        {
            if (ModelState.IsValid)
            {
                db.Anamnese.Add(anamnese);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFichaAnimal = new SelectList(db.FichaAnimal, "Id", "PesoPorteAntesDosProcedimentos", anamnese.IdFichaAnimal);
            return View(anamnese);
        }

        // GET: Anamnese/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anamnese anamnese = db.Anamnese.Find(id);
            if (anamnese == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFichaAnimal = new SelectList(db.FichaAnimal, "Id", "PesoPorteAntesDosProcedimentos", anamnese.IdFichaAnimal);
            return View(anamnese);
        }

        // POST: Anamnese/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Diagnostico,Anamnese1,Medicamentos,ProcedimentosRealizados,IdFichaAnimal")] Anamnese anamnese)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anamnese).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFichaAnimal = new SelectList(db.FichaAnimal, "Id", "PesoPorteAntesDosProcedimentos", anamnese.IdFichaAnimal);
            return View(anamnese);
        }

        // GET: Anamnese/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anamnese anamnese = db.Anamnese.Find(id);
            if (anamnese == null)
            {
                return HttpNotFound();
            }
            return View(anamnese);
        }

        // POST: Anamnese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Anamnese anamnese = db.Anamnese.Find(id);
            db.Anamnese.Remove(anamnese);
            db.SaveChanges();
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
