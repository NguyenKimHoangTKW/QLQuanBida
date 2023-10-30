using QLQuanBida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLQuanBida.Controllers
{
    public class UsersController : Controller
    {
        private dbBidaEntities db = new dbBidaEntities();
        // GET: Users
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(UserAdmin admin)
        {
            var isLoginAdmin = db.UserAdmins.SingleOrDefault(ad => ad.uSername.Equals(admin.uSername) && ad.pAssWord.Equals(admin.pAssWord));
            if (isLoginAdmin != null)
            {
                Session["Admin"] = isLoginAdmin;
                return RedirectToAction("Index", "HomeAdmin", new {area = "Admin"});
            }
            else
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không chính xác, vui lòng kiểm tra và đăng nhập lại";
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}