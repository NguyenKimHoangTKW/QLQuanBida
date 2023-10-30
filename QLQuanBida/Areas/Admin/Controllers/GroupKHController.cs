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
    public class GroupKHController : Controller
    {
        private dbBidaEntities db = new dbBidaEntities();

        // GET: Admin/GroupKH
        public ActionResult Index()
        {
            return View(db.GroupKHs.ToList());
        }

        // GET: Admin/GroupKH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupKH groupKH = db.GroupKHs.Find(id);
            if (groupKH == null)
            {
                return HttpNotFound();
            }
            return View(groupKH);
        }

        // GET: Admin/GroupKH/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GroupKH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idKH,MaGroupKH,TenNhom,MoTa")] GroupKH groupKH)
        {
            if (ModelState.IsValid)
            {
                db.GroupKHs.Add(groupKH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupKH);
        }

        // GET: Admin/GroupKH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupKH groupKH = db.GroupKHs.Find(id);
            if (groupKH == null)
            {
                return HttpNotFound();
            }
            return View(groupKH);
        }

        // POST: Admin/GroupKH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idKH,MaGroupKH,TenNhom,MoTa")] GroupKH groupKH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupKH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupKH);
        }

        // GET: Admin/GroupKH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupKH groupKH = db.GroupKHs.Find(id);
            if (groupKH == null)
            {
                return HttpNotFound();
            }
            return View(groupKH);
        }

        // POST: Admin/GroupKH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupKH groupKH = db.GroupKHs.Find(id);
            db.GroupKHs.Remove(groupKH);
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
