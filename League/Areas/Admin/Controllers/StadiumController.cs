using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using League.Models;

namespace League.Areas.Admin.Controllers
{
    public class StadiumController : Controller
    {
        private LeagueDbContext db = new LeagueDbContext();

        // GET: /Admin/Stadium/
        public ActionResult Index()
        {
            return View(db.Stadium.ToList());
        }

        // GET: /Admin/Stadium/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stadium stadium = db.Stadium.Find(id);
            if (stadium == null)
            {
                return HttpNotFound();
            }
            return View(stadium);
        }

        // GET: /Admin/Stadium/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Stadium/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Address")] Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                db.Stadium.Add(stadium);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stadium);
        }

        // GET: /Admin/Stadium/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stadium stadium = db.Stadium.Find(id);
            if (stadium == null)
            {
                return HttpNotFound();
            }
            return View(stadium);
        }

        // POST: /Admin/Stadium/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Address")] Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stadium).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stadium);
        }

        // GET: /Admin/Stadium/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stadium stadium = db.Stadium.Find(id);
            if (stadium == null)
            {
                return HttpNotFound();
            }
            return View(stadium);
        }

        // POST: /Admin/Stadium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stadium stadium = db.Stadium.Find(id);
            db.Stadium.Remove(stadium);
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
