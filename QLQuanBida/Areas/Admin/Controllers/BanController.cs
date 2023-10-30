using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLQuanBida.Models;

namespace QLQuanBida.Areas.Admin.Controllers
{
    public class BanController : Controller
    {
        private dbBidaEntities db = new dbBidaEntities();

        // GET: Admin/Ban
        public ActionResult Index()
        {
            var bans = db.Bans.Include(b => b.KhuVuc);
            return View(bans.ToList());
        }

        // GET: Admin/Ban/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ban ban = db.Bans.Find(id);
            if (ban == null)
            {
                return HttpNotFound();
            }
            return View(ban);
        }

        // GET: Admin/Ban/Create
        public ActionResult Create()
        {
            ViewBag.IDKV = new SelectList(db.KhuVucs, "IDKV", "MaKV");
            return View();
        }

        // POST: Admin/Ban/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBan,TenBan,IDKV")] Ban ban)
        {
            if (ModelState.IsValid)
            {
                db.Bans.Add(ban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDKV = new SelectList(db.KhuVucs, "IDKV", "MaKV", ban.IDKV);
            return View(ban);
        }

        // GET: Admin/Ban/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ban ban = db.Bans.Find(id);
            if (ban == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKV = new SelectList(db.KhuVucs, "IDKV", "MaKV", ban.IDKV);
            return View(ban);
        }

        // POST: Admin/Ban/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBan,TenBan,IDKV")] Ban ban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKV = new SelectList(db.KhuVucs, "IDKV", "MaKV", ban.IDKV);
            return View(ban);
        }

        // GET: Admin/Ban/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ban ban = db.Bans.Find(id);
            if (ban == null)
            {
                return HttpNotFound();
            }
            return View(ban);
        }

        // POST: Admin/Ban/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ban ban = db.Bans.Find(id);
            db.Bans.Remove(ban);
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
