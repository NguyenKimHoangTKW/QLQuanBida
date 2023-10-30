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
    public class MatHangController : Controller
    {
        private dbBidaEntities db = new dbBidaEntities();

        // GET: Admin/MatHang
        public ActionResult Index()
        {
            var matHangs = db.MatHangs.Include(m => m.DonViTinh).Include(m => m.NhomMatHang);
            return View(matHangs.ToList());
        }

        // GET: Admin/MatHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // GET: Admin/MatHang/Create
        public ActionResult Create()
        {
            ViewBag.IDDVT = new SelectList(db.DonViTinhs, "IDDVT", "MaDVT");
            ViewBag.IDNhomMH = new SelectList(db.NhomMatHangs, "IDNhomMH", "MaNhomMH");
            return View();
        }

        // POST: Admin/MatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMH,MaHang,TenHang,IDDVT,IDNhomMH,Gia,MoTa")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.MatHangs.Add(matHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDVT = new SelectList(db.DonViTinhs, "IDDVT", "MaDVT", matHang.IDDVT);
            ViewBag.IDNhomMH = new SelectList(db.NhomMatHangs, "IDNhomMH", "MaNhomMH", matHang.IDNhomMH);
            return View(matHang);
        }

        // GET: Admin/MatHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDVT = new SelectList(db.DonViTinhs, "IDDVT", "MaDVT", matHang.IDDVT);
            ViewBag.IDNhomMH = new SelectList(db.NhomMatHangs, "IDNhomMH", "MaNhomMH", matHang.IDNhomMH);
            return View(matHang);
        }

        // POST: Admin/MatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMH,MaHang,TenHang,IDDVT,IDNhomMH,Gia,MoTa")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDVT = new SelectList(db.DonViTinhs, "IDDVT", "MaDVT", matHang.IDDVT);
            ViewBag.IDNhomMH = new SelectList(db.NhomMatHangs, "IDNhomMH", "MaNhomMH", matHang.IDNhomMH);
            return View(matHang);
        }

        // GET: Admin/MatHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // POST: Admin/MatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatHang matHang = db.MatHangs.Find(id);
            db.MatHangs.Remove(matHang);
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
