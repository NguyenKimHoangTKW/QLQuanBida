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
    public class NhomMatHangController : Controller
    {
        private dbBidaEntities db = new dbBidaEntities();

        // GET: Admin/NhomMatHang
        public ActionResult Index()
        {
            return View(db.NhomMatHangs.ToList());
        }

        // GET: Admin/NhomMatHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomMatHang nhomMatHang = db.NhomMatHangs.Find(id);
            if (nhomMatHang == null)
            {
                return HttpNotFound();
            }
            return View(nhomMatHang);
        }

        // GET: Admin/NhomMatHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhomMatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNhomMH,MaNhomMH,TenNhomMH,MoTa")] NhomMatHang nhomMatHang)
        {
            if (ModelState.IsValid)
            {
                db.NhomMatHangs.Add(nhomMatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomMatHang);
        }

        // GET: Admin/NhomMatHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomMatHang nhomMatHang = db.NhomMatHangs.Find(id);
            if (nhomMatHang == null)
            {
                return HttpNotFound();
            }
            return View(nhomMatHang);
        }

        // POST: Admin/NhomMatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNhomMH,MaNhomMH,TenNhomMH,MoTa")] NhomMatHang nhomMatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomMatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomMatHang);
        }

        // GET: Admin/NhomMatHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomMatHang nhomMatHang = db.NhomMatHangs.Find(id);
            if (nhomMatHang == null)
            {
                return HttpNotFound();
            }
            return View(nhomMatHang);
        }

        // POST: Admin/NhomMatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhomMatHang nhomMatHang = db.NhomMatHangs.Find(id);
            db.NhomMatHangs.Remove(nhomMatHang);
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
