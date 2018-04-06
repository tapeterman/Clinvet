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
    public class AgendamentoConsultaController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: AgendamentoConsulta
        public async Task<ActionResult> Index()
        {
            return View(await db.AgendamentoConsultas.ToListAsync());
        }

        // GET: AgendamentoConsulta/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendamentoConsulta agendamentoConsulta = await db.AgendamentoConsultas.FindAsync(id);
            if (agendamentoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(agendamentoConsulta);
        }

        // GET: AgendamentoConsulta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendamentoConsulta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DataDeAgendamento,Descricao,Status,IdCliente")] AgendamentoConsulta agendamentoConsulta)
        {
            if (ModelState.IsValid)
            {
                db.AgendamentoConsultas.Add(agendamentoConsulta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(agendamentoConsulta);
        }

        // GET: AgendamentoConsulta/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendamentoConsulta agendamentoConsulta = await db.AgendamentoConsultas.FindAsync(id);
            if (agendamentoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(agendamentoConsulta);
        }

        // POST: AgendamentoConsulta/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DataDeAgendamento,Descricao,Status,IdCliente")] AgendamentoConsulta agendamentoConsulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamentoConsulta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(agendamentoConsulta);
        }

        // GET: AgendamentoConsulta/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendamentoConsulta agendamentoConsulta = await db.AgendamentoConsultas.FindAsync(id);
            if (agendamentoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(agendamentoConsulta);
        }

        // POST: AgendamentoConsulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            AgendamentoConsulta agendamentoConsulta = await db.AgendamentoConsultas.FindAsync(id);
            db.AgendamentoConsultas.Remove(agendamentoConsulta);
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
