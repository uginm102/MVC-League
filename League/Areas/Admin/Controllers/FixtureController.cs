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
    public class FixtureController : Controller
    {
        private LeagueDbContext db = new LeagueDbContext();

        // GET: /Admin/Fixture/
        public async Task<ActionResult> Index()
        {
            return View(await db.Fixture.ToListAsync());
        }

        // GET: /Admin/Fixture/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = await db.Fixture.FindAsync(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // GET: /Admin/Fixture/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Fixture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,KickOff")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Fixture.Add(fixture);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fixture);
        }

        // GET: /Admin/Fixture/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = await db.Fixture.FindAsync(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // POST: /Admin/Fixture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,KickOff")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixture).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fixture);
        }

        // GET: /Admin/Fixture/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = await db.Fixture.FindAsync(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // POST: /Admin/Fixture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fixture fixture = await db.Fixture.FindAsync(id);
            db.Fixture.Remove(fixture);
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
