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
    public class KhenThuongController : Controller
    {
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        // GET: Admin/KhenThuong
        public ActionResult Index()
        {
            var khenThuongs = db.KhenThuongs.Include(k => k.Luong);
            return View(khenThuongs.ToList());
        }

        // GET: Admin/KhenThuong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhenThuong khenThuong = db.KhenThuongs.Find(id);
            if (khenThuong == null)
            {
                return HttpNotFound();
            }
            return View(khenThuong);
        }

        // GET: Admin/KhenThuong/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri");
            return View();
        }

        // POST: Admin/KhenThuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKT,NameKT,MaNV,SoTien,MoTa")] KhenThuong khenThuong)
        {
            if (ModelState.IsValid)
            {
                db.KhenThuongs.Add(khenThuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", khenThuong.MaNV);
            return View(khenThuong);
        }

        // GET: Admin/KhenThuong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhenThuong khenThuong = db.KhenThuongs.Find(id);
            if (khenThuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", khenThuong.MaNV);
            return View(khenThuong);
        }

        // POST: Admin/KhenThuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKT,NameKT,MaNV,SoTien,MoTa")] KhenThuong khenThuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khenThuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", khenThuong.MaNV);
            return View(khenThuong);
        }

        // GET: Admin/KhenThuong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhenThuong khenThuong = db.KhenThuongs.Find(id);
            if (khenThuong == null)
            {
                return HttpNotFound();
            }
            return View(khenThuong);
        }

        // POST: Admin/KhenThuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhenThuong khenThuong = db.KhenThuongs.Find(id);
            db.KhenThuongs.Remove(khenThuong);
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
