using QuanLiNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiNhanVien.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ThongTinNhanVien(int id)
        {
            var nhanViens = db.NhanViens.Where(nv => nv.MaNV == id);
            return View(nhanViens.First());
        }
        public ActionResult ThongTinLuong(int id)
        {
            var Luongs = db.Luongs.Where(nv => nv.MaNV == id);
            return View(Luongs.First());
        }
        public ActionResult BaoHiem(int id)
        {
            var BaoHiems = db.BaoHiems.Where(nv => nv.MaNV == id);
            return View(BaoHiems.First());
        }
        public ActionResult TangCa(int id)
        {
            var TangCas = db.TangCas.Where(nv => nv.MaNV == id);
            return View(TangCas.First());
        }
        [HttpPost]
        public ActionResult Login(Admin admin, NhanVien customer, FormCollection f)
        {
            var username = f["username"];
            var password = f["password"];

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var isAdmin = LoginAdmin(username, password);
                var isCustomer = LoginCustomer(username, password);

                if (isAdmin != null)
                {
                    Session["Admin"] = isAdmin;
                    return RedirectToAction("Index", "TrangChu", new { area = "Admin" });
                }
                else if (isCustomer != null)
                {
                    Session["NhanVien"] = isCustomer;
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    TempData["SweetAlertMessage"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                    TempData["SweetAlertType"] = "error";
                }
            }

            return RedirectToAction("Index","Home");
        }

        private Admin LoginAdmin(string username, string password)
        {
            return db.Admins.SingleOrDefault(sa => sa.TenDN.Equals(username) && sa.MatKhau.Equals(password));
        }

        private NhanVien LoginCustomer(string username, string password)
        {
            return db.NhanViens.SingleOrDefault(cus => cus.userName.Equals(username) && cus.passWord.Equals(password));
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "NhanVien");
        }
    }
}
