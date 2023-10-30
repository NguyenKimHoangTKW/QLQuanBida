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
    public class KhachHangController : Controller
    {
        private dbBidaEntities db = new dbBidaEntities();

        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            var khachHangs = db.KhachHangs.Include(k => k.CKKM).Include(k => k.GroupKH);
            return View(khachHangs.ToList());
        }

        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHang/Create
        public ActionResult Create()
        {
            ViewBag.idCKKM = new SelectList(db.CKKMs, "idCKKM", "MaCKKM");
            ViewBag.idGroupKH = new SelectList(db.GroupKHs, "idKH", "MaGroupKH");
            return View();
        }

        // POST: Admin/KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idKH,MaKH,TenKH,DiaChi,DienThoai,NgaySinh,idGroupKH,DiemTichLuy,MoTa,idCKKM")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCKKM = new SelectList(db.CKKMs, "idCKKM", "MaCKKM", khachHang.idCKKM);
            ViewBag.idGroupKH = new SelectList(db.GroupKHs, "idKH", "MaGroupKH", khachHang.idGroupKH);
            return View(khachHang);
        }

        // GET: Admin/KhachHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCKKM = new SelectList(db.CKKMs, "idCKKM", "MaCKKM", khachHang.idCKKM);
            ViewBag.idGroupKH = new SelectList(db.GroupKHs, "idKH", "MaGroupKH", khachHang.idGroupKH);
            return View(khachHang);
        }

        // POST: Admin/KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idKH,MaKH,TenKH,DiaChi,DienThoai,NgaySinh,idGroupKH,DiemTichLuy,MoTa,idCKKM")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCKKM = new SelectList(db.CKKMs, "idCKKM", "MaCKKM", khachHang.idCKKM);
            ViewBag.idGroupKH = new SelectList(db.GroupKHs, "idKH", "MaGroupKH", khachHang.idGroupKH);
            return View(khachHang);
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
