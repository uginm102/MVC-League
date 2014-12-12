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
    public class SeasonController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Admin/Season/
        public ActionResult Index()
        {
            return View(db.Season.ToList());
        }

        // GET: /Admin/Season/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = db.Season.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // GET: /Admin/Season/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Season/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Start,Stop")] Season season)
        {
            if (ModelState.IsValid)
            {
                db.Season.Add(season);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(season);
        }

        // GET: /Admin/Season/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = db.Season.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // POST: /Admin/Season/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Start,Stop")] Season season)
        {
            if (ModelState.IsValid)
            {
                db.Entry(season).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(season);
        }

        // GET: /Admin/Season/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = db.Season.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // POST: /Admin/Season/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Season season = db.Season.Find(id);
            db.Season.Remove(season);
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
