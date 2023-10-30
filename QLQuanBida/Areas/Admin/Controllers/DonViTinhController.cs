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
    public class DonViTinhController : Controller
    {
        private dbBidaEntities db = new dbBidaEntities();

        // GET: Admin/DonViTinh
        public ActionResult Index()
        {
            return View(db.DonViTinhs.ToList());
        }

        // GET: Admin/DonViTinh/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return HttpNotFound();
            }
            return View(donViTinh);
        }

        // GET: Admin/DonViTinh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DonViTinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDVT,MaDVT,TenDVT,MoTa")] DonViTinh donViTinh)
        {
            if (ModelState.IsValid)
            {
                db.DonViTinhs.Add(donViTinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donViTinh);
        }

        // GET: Admin/DonViTinh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return HttpNotFound();
            }
            return View(donViTinh);
        }

        // POST: Admin/DonViTinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDVT,MaDVT,TenDVT,MoTa")] DonViTinh donViTinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donViTinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donViTinh);
        }

        // GET: Admin/DonViTinh/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return HttpNotFound();
            }
            return View(donViTinh);
        }

        // POST: Admin/DonViTinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            db.DonViTinhs.Remove(donViTinh);
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
