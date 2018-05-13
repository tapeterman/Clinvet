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
    public class VendaServicoController : Controller
    {
        private ClinvetContext db = new ClinvetContext();

        // GET: VendaServico
        public ActionResult Index()
        {
            var vendaServico = db.VendaServico.Include(v => v.Cliente).Include(v => v.Funcionario);
            return View(vendaServico.ToList());
        }

        // GET: VendaServico/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaServico vendaServico = db.VendaServico.Find(id);
            if (vendaServico == null)
            {
                return HttpNotFound();
            }
            return View(vendaServico);
        }

        // GET: VendaServico/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome");
            ViewBag.IdFuncionario = new SelectList(db.Funcionario, "Id", "Nome");
            return View();
        }

        // POST: VendaServico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ValorTotal,Descricao,IdFuncionario,IdCliente,DataServico")] VendaServico vendaServico)
        {
            if (ModelState.IsValid)
            {
                db.VendaServico.Add(vendaServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", vendaServico.IdCliente);
            ViewBag.IdFuncionario = new SelectList(db.Funcionario, "Id", "Nome", vendaServico.IdFuncionario);
            return View(vendaServico);
        }

        // GET: VendaServico/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaServico vendaServico = db.VendaServico.Find(id);
            if (vendaServico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", vendaServico.IdCliente);
            ViewBag.IdFuncionario = new SelectList(db.Funcionario, "Id", "Nome", vendaServico.IdFuncionario);
            return View(vendaServico);
        }

        // POST: VendaServico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ValorTotal,Descricao,IdFuncionario,IdCliente,DataServico")] VendaServico vendaServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendaServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nome", vendaServico.IdCliente);
            ViewBag.IdFuncionario = new SelectList(db.Funcionario, "Id", "Nome", vendaServico.IdFuncionario);
            return View(vendaServico);
        }

        // GET: VendaServico/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaServico vendaServico = db.VendaServico.Find(id);
            if (vendaServico == null)
            {
                return HttpNotFound();
            }
            return View(vendaServico);
        }

        // POST: VendaServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VendaServico vendaServico = db.VendaServico.Find(id);
            db.VendaServico.Remove(vendaServico);
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
