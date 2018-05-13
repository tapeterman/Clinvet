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
    public class AgendamentoConsultaController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: AgendamentoConsulta
        public ActionResult Index()
        {
            var agendamentoConsulta = db.AgendamentoConsulta.Include(a => a.Cliente);
            return View(agendamentoConsulta.ToList());
        }

        // GET: AgendamentoConsulta/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendamentoConsulta agendamentoConsulta = db.AgendamentoConsulta.Find(id);
            if (agendamentoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(agendamentoConsulta);
        }

        // GET: AgendamentoConsulta/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome");
            return View();
        }

        // POST: AgendamentoConsulta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataDeAgendamento,Descricao,Status,IdCliente")] AgendamentoConsulta agendamentoConsulta)
        {
            if (ModelState.IsValid)
            {
                db.AgendamentoConsulta.Add(agendamentoConsulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", agendamentoConsulta.IdCliente);
            return View(agendamentoConsulta);
        }

        // GET: AgendamentoConsulta/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendamentoConsulta agendamentoConsulta = db.AgendamentoConsulta.Find(id);
            if (agendamentoConsulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", agendamentoConsulta.IdCliente);
            return View(agendamentoConsulta);
        }

        // POST: AgendamentoConsulta/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataDeAgendamento,Descricao,Status,IdCliente")] AgendamentoConsulta agendamentoConsulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamentoConsulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", agendamentoConsulta.IdCliente);
            return View(agendamentoConsulta);
        }

        // GET: AgendamentoConsulta/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendamentoConsulta agendamentoConsulta = db.AgendamentoConsulta.Find(id);
            if (agendamentoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(agendamentoConsulta);
        }

        // POST: AgendamentoConsulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AgendamentoConsulta agendamentoConsulta = db.AgendamentoConsulta.Find(id);
            db.AgendamentoConsulta.Remove(agendamentoConsulta);
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
