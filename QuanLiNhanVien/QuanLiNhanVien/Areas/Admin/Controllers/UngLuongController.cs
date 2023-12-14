using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiNhanVien.Models;

namespace QuanLiNhanVien.Areas.Admin.Controllers
{
    public class UngLuongController : Controller
    {
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        // GET: Admin/UngLuong
        public ActionResult Index()
        {
            var ungLuongs = db.UngLuongs.Include(u => u.NhanVien).Include(u => u.Luong);
            return View(ungLuongs.ToList());
        }

        // GET: Admin/UngLuong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UngLuong ungLuong = db.UngLuongs.Find(id);
            if (ungLuong == null)
            {
                return HttpNotFound();
            }
            return View(ungLuong);
        }

        // GET: Admin/UngLuong/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Name");
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri");
            return View();
        }

        // POST: Admin/UngLuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUL,SoTien,TrangThai,MaNV,Day")] UngLuong ungLuong)
        {
            if (ModelState.IsValid)
            {
                db.UngLuongs.Add(ungLuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Name", ungLuong.MaNV);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", ungLuong.MaNV);
            return View(ungLuong);
        }

        // GET: Admin/UngLuong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UngLuong ungLuong = db.UngLuongs.Find(id);
            if (ungLuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Name", ungLuong.MaNV);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", ungLuong.MaNV);
            return View(ungLuong);
        }

        // POST: Admin/UngLuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUL,SoTien,TrangThai,MaNV,Day")] UngLuong ungLuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ungLuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Name", ungLuong.MaNV);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", ungLuong.MaNV);
            return View(ungLuong);
        }

        // GET: Admin/UngLuong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UngLuong ungLuong = db.UngLuongs.Find(id);
            if (ungLuong == null)
            {
                return HttpNotFound();
            }
            return View(ungLuong);
        }

        // POST: Admin/UngLuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UngLuong ungLuong = db.UngLuongs.Find(id);
            db.UngLuongs.Remove(ungLuong);
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
