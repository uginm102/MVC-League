using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using League.Models;

namespace League.Areas.Admin.Controllers
{
    public class RefereeController : Controller
    {
        private LeagueDbContext db = new LeagueDbContext();

        // GET: /Admin/Referee/
        public async Task<ActionResult> Index()
        {
            return View(await db.Referee.ToListAsync());
        }

        // GET: /Admin/Referee/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referee referee = await db.Referee.FindAsync(id);
            if (referee == null)
            {
                return HttpNotFound();
            }
            return View(referee);
        }

        // GET: /Admin/Referee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Referee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="LastName,FirstName,DOB")] Referee referee)
        {
            if (ModelState.IsValid)
            {
                db.Referee.Add(referee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(referee);
        }

        // GET: /Admin/Referee/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referee referee = await db.Referee.FindAsync(id);
            if (referee == null)
            {
                return HttpNotFound();
            }
            return View(referee);
        }

        // POST: /Admin/Referee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,LastName,FirstName,DOB")] Referee referee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(referee);
        }

        // GET: /Admin/Referee/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referee referee = await db.Referee.FindAsync(id);
            if (referee == null)
            {
                return HttpNotFound();
            }
            return View(referee);
        }

        // POST: /Admin/Referee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Referee referee = await db.Referee.FindAsync(id);
            db.Referee.Remove(referee);
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
