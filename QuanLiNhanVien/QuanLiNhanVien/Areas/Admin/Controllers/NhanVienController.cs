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
    public class NhanVienController : Controller
    {
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.BoPhan).Include(n => n.ChucVu).Include(n => n.Luong).Include(n => n.PhongBan).Include(n => n.TrinhDo);
            return View(nhanViens.ToList());
        }

        // GET: Admin/NhanVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Create
        public ActionResult Create()
        {
            ViewBag.IDPB = new SelectList(db.BoPhans, "IDBP", "NameBP");
            ViewBag.IDCV = new SelectList(db.ChucVus, "IDCV", "NameCV");
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri");
            ViewBag.IDBP = new SelectList(db.PhongBans, "IDPB", "NamePB");
            ViewBag.IDTD = new SelectList(db.TrinhDoes, "IDTD", "NameTD");
            return View();
        }

        // POST: Admin/NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,Name,Gender,Date,Anh,Phone,CCCD,Address,IDPB,IDBP,IDCV,IDTD,userName,passWord")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPB = new SelectList(db.BoPhans, "IDBP", "NameBP", nhanVien.IDPB);
            ViewBag.IDCV = new SelectList(db.ChucVus, "IDCV", "NameCV", nhanVien.IDCV);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", nhanVien.MaNV);
            ViewBag.IDBP = new SelectList(db.PhongBans, "IDPB", "NamePB", nhanVien.IDBP);
            ViewBag.IDTD = new SelectList(db.TrinhDoes, "IDTD", "NameTD", nhanVien.IDTD);
            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPB = new SelectList(db.BoPhans, "IDBP", "NameBP", nhanVien.IDPB);
            ViewBag.IDCV = new SelectList(db.ChucVus, "IDCV", "NameCV", nhanVien.IDCV);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", nhanVien.MaNV);
            ViewBag.IDBP = new SelectList(db.PhongBans, "IDPB", "NamePB", nhanVien.IDBP);
            ViewBag.IDTD = new SelectList(db.TrinhDoes, "IDTD", "NameTD", nhanVien.IDTD);
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,Name,Gender,Date,Anh,Phone,CCCD,Address,IDPB,IDBP,IDCV,IDTD,userName,passWord")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPB = new SelectList(db.BoPhans, "IDBP", "NameBP", nhanVien.IDPB);
            ViewBag.IDCV = new SelectList(db.ChucVus, "IDCV", "NameCV", nhanVien.IDCV);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", nhanVien.MaNV);
            ViewBag.IDBP = new SelectList(db.PhongBans, "IDPB", "NamePB", nhanVien.IDBP);
            ViewBag.IDTD = new SelectList(db.TrinhDoes, "IDTD", "NameTD", nhanVien.IDTD);
            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
