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
    public class PlayerController : Controller
    {
        private LeagueDbContext db = new LeagueDbContext();

        // GET: /Admin/Player/
        public async Task<ActionResult> Index()
        {
            return View(await db.Player.ToListAsync());
        }

        // GET: /Admin/Player/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Player.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: /Admin/Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,LastName,FirstName,DOB")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Player.Add(player);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: /Admin/Player/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Player.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: /Admin/Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,LastName,FirstName,DOB")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: /Admin/Player/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Player.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: /Admin/Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Player player = await db.Player.FindAsync(id);
            db.Player.Remove(player);
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
