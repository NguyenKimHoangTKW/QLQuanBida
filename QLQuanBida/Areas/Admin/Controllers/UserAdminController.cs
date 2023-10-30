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
    public class UserAdminController : Controller
    {
        private dbBidaEntities db = new dbBidaEntities();

        // GET: Admin/UserAdmin
        public ActionResult Index()
        {
            return View(db.UserAdmins.ToList());
        }

        // GET: Admin/UserAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            if (userAdmin == null)
            {
                return HttpNotFound();
            }
            return View(userAdmin);
        }

        // GET: Admin/UserAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,uSername,pAssWord,SuDung,tenAdmin,diaChi,sdt")] UserAdmin userAdmin)
        {
            if (ModelState.IsValid)
            {
                db.UserAdmins.Add(userAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAdmin);
        }

        // GET: Admin/UserAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            if (userAdmin == null)
            {
                return HttpNotFound();
            }
            return View(userAdmin);
        }

        // POST: Admin/UserAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,uSername,pAssWord,SuDung,tenAdmin,diaChi,sdt")] UserAdmin userAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAdmin);
        }

        // GET: Admin/UserAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            if (userAdmin == null)
            {
                return HttpNotFound();
            }
            return View(userAdmin);
        }

        // POST: Admin/UserAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            db.UserAdmins.Remove(userAdmin);
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
