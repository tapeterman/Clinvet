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
    public class VacinaController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: Vacina
        public ActionResult Index()
        {
            var vacina = db.Vacina.Include(v => v.FichaAnimal).Include(v => v.TiposDeVacina);
            return View(vacina.ToList());
        }

        // GET: Vacina/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacina vacina = db.Vacina.Find(id);
            if (vacina == null)
            {
                return HttpNotFound();
            }
            return View(vacina);
        }

        // GET: Vacina/Create
        public ActionResult Create()
        {
            ViewBag.IdFichaAnimal = new SelectList(db.FichaAnimal, "Id", "PesoPorteAntesDosProcedimentos");
            ViewBag.IdTiposDeVacina = new SelectList(db.TiposDeVacina, "Id", "Descricao");
            return View();
        }

        // POST: Vacina/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marca,Lote,Fornecedor,Validade,Custo,IdFichaAnimal,IdTiposDeVacina")] Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                db.Vacina.Add(vacina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFichaAnimal = new SelectList(db.FichaAnimal, "Id", "PesoPorteAntesDosProcedimentos", vacina.IdFichaAnimal);
            ViewBag.IdTiposDeVacina = new SelectList(db.TiposDeVacina, "Id", "Descricao", vacina.IdTiposDeVacina);
            return View(vacina);
        }

        // GET: Vacina/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacina vacina = db.Vacina.Find(id);
            if (vacina == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFichaAnimal = new SelectList(db.FichaAnimal, "Id", "PesoPorteAntesDosProcedimentos", vacina.IdFichaAnimal);
            ViewBag.IdTiposDeVacina = new SelectList(db.TiposDeVacina, "Id", "Descricao", vacina.IdTiposDeVacina);
            return View(vacina);
        }

        // POST: Vacina/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marca,Lote,Fornecedor,Validade,Custo,IdFichaAnimal,IdTiposDeVacina")] Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFichaAnimal = new SelectList(db.FichaAnimal, "Id", "PesoPorteAntesDosProcedimentos", vacina.IdFichaAnimal);
            ViewBag.IdTiposDeVacina = new SelectList(db.TiposDeVacina, "Id", "Descricao", vacina.IdTiposDeVacina);
            return View(vacina);
        }

        // GET: Vacina/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacina vacina = db.Vacina.Find(id);
            if (vacina == null)
            {
                return HttpNotFound();
            }
            return View(vacina);
        }

        // POST: Vacina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Vacina vacina = db.Vacina.Find(id);
            db.Vacina.Remove(vacina);
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
