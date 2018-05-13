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
    public class ProdutoServicoAgendamentoConsultaController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: ProdutoServicoAgendamentoConsulta
        public ActionResult Index()
        {
            var produtoServicoAgendamentoConsultas = db.ProdutoServicoAgendamentoConsultas.Include(p => p.Agendamentoconsulta).Include(p => p.ProdutoServico);
            return View(produtoServicoAgendamentoConsultas.ToList());
        }

        // GET: ProdutoServicoAgendamentoConsulta/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas = db.ProdutoServicoAgendamentoConsultas.Find(id);
            if (produtoServicoAgendamentoConsultas == null)
            {
                return HttpNotFound();
            }
            return View(produtoServicoAgendamentoConsultas);
        }

        // GET: ProdutoServicoAgendamentoConsulta/Create
        public ActionResult Create()
        {
            ViewBag.IdAgendamentoConsulta = new SelectList(db.AgendamentoConsulta, "Id", "Descricao");
            ViewBag.IdProdutoServico = new SelectList(db.ProdutoServico, "Id", "Nome");
            return View();
        }

        // POST: ProdutoServicoAgendamentoConsulta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProdutoServicoAgendamentoConsulta,IdProdutoServico,IdAgendamentoConsulta")] ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoServicoAgendamentoConsultas.Add(produtoServicoAgendamentoConsultas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAgendamentoConsulta = new SelectList(db.AgendamentoConsulta, "Id", "Descricao", produtoServicoAgendamentoConsultas.IdAgendamentoConsulta);
            ViewBag.IdProdutoServico = new SelectList(db.ProdutoServico, "Id", "Nome", produtoServicoAgendamentoConsultas.IdProdutoServico);
            return View(produtoServicoAgendamentoConsultas);
        }

        // GET: ProdutoServicoAgendamentoConsulta/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas = db.ProdutoServicoAgendamentoConsultas.Find(id);
            if (produtoServicoAgendamentoConsultas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAgendamentoConsulta = new SelectList(db.AgendamentoConsulta, "Id", "Descricao", produtoServicoAgendamentoConsultas.IdAgendamentoConsulta);
            ViewBag.IdProdutoServico = new SelectList(db.ProdutoServico, "Id", "Nome", produtoServicoAgendamentoConsultas.IdProdutoServico);
            return View(produtoServicoAgendamentoConsultas);
        }

        // POST: ProdutoServicoAgendamentoConsulta/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProdutoServicoAgendamentoConsulta,IdProdutoServico,IdAgendamentoConsulta")] ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoServicoAgendamentoConsultas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAgendamentoConsulta = new SelectList(db.AgendamentoConsulta, "Id", "Descricao", produtoServicoAgendamentoConsultas.IdAgendamentoConsulta);
            ViewBag.IdProdutoServico = new SelectList(db.ProdutoServico, "Id", "Nome", produtoServicoAgendamentoConsultas.IdProdutoServico);
            return View(produtoServicoAgendamentoConsultas);
        }

        // GET: ProdutoServicoAgendamentoConsulta/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas = db.ProdutoServicoAgendamentoConsultas.Find(id);
            if (produtoServicoAgendamentoConsultas == null)
            {
                return HttpNotFound();
            }
            return View(produtoServicoAgendamentoConsultas);
        }

        // POST: ProdutoServicoAgendamentoConsulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProdutoServicoAgendamentoConsultas produtoServicoAgendamentoConsultas = db.ProdutoServicoAgendamentoConsultas.Find(id);
            db.ProdutoServicoAgendamentoConsultas.Remove(produtoServicoAgendamentoConsultas);
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
