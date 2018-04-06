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
    public class ContasAPagarController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: ContasAPagar
        public async Task<ActionResult> Index()
        {
            return View(await db.ContasAPagars.ToListAsync());
        }

        // GET: ContasAPagar/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasAPagar contasAPagar = await db.ContasAPagars.FindAsync(id);
            if (contasAPagar == null)
            {
                return HttpNotFound();
            }
            return View(contasAPagar);
        }

        // GET: ContasAPagar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContasAPagar/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Data,Valor,IdFornecedor,IdTipoDeConta")] ContasAPagar contasAPagar)
        {
            if (ModelState.IsValid)
            {
                db.ContasAPagars.Add(contasAPagar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contasAPagar);
        }

        // GET: ContasAPagar/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasAPagar contasAPagar = await db.ContasAPagars.FindAsync(id);
            if (contasAPagar == null)
            {
                return HttpNotFound();
            }
            return View(contasAPagar);
        }

        // POST: ContasAPagar/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Data,Valor,IdFornecedor,IdTipoDeConta")] ContasAPagar contasAPagar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contasAPagar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contasAPagar);
        }

        // GET: ContasAPagar/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasAPagar contasAPagar = await db.ContasAPagars.FindAsync(id);
            if (contasAPagar == null)
            {
                return HttpNotFound();
            }
            return View(contasAPagar);
        }

        // POST: ContasAPagar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ContasAPagar contasAPagar = await db.ContasAPagars.FindAsync(id);
            db.ContasAPagars.Remove(contasAPagar);
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
