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
    public class ChamCongController : Controller
    {
        private dbBidaEntities db = new dbBidaEntities();

        // GET: Admin/ChamCong
        public ActionResult Index()
        {
            var chamCongs = db.ChamCongs.Include(c => c.NhanVien);
            return View(chamCongs.ToList());
        }

        // GET: Admin/ChamCong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // GET: Admin/ChamCong/Create
        public ActionResult Create()
        {
            ViewBag.idNV = new SelectList(db.NhanViens, "idNV", "MaNV");
            return View();
        }

        // POST: Admin/ChamCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idChamCong,NgayLam,VaoLam,TanLam,idNV,CaLam")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.ChamCongs.Add(chamCong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNV = new SelectList(db.NhanViens, "idNV", "MaNV", chamCong.idNV);
            return View(chamCong);
        }

        // GET: Admin/ChamCong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNV = new SelectList(db.NhanViens, "idNV", "MaNV", chamCong.idNV);
            return View(chamCong);
        }

        // POST: Admin/ChamCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idChamCong,NgayLam,VaoLam,TanLam,idNV,CaLam")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamCong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNV = new SelectList(db.NhanViens, "idNV", "MaNV", chamCong.idNV);
            return View(chamCong);
        }

        // GET: Admin/ChamCong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // POST: Admin/ChamCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChamCong chamCong = db.ChamCongs.Find(id);
            db.ChamCongs.Remove(chamCong);
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
