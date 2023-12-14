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
    public class ChamCongController : Controller
    {
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        // GET: Admin/ChamCong
        public ActionResult Index()
        {
            var chamCongs = db.ChamCongs.Include(c => c.LoaiCong).Include(c => c.Luong);
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
            ViewBag.IDLC = new SelectList(db.LoaiCongs, "IDLC", "NameLC");
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri");
            return View();
        }

        // POST: Admin/ChamCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCC,IDLC,MaNV,Day")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.ChamCongs.Add(chamCong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLC = new SelectList(db.LoaiCongs, "IDLC", "NameLC", chamCong.IDLC);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", chamCong.MaNV);
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
            ViewBag.IDLC = new SelectList(db.LoaiCongs, "IDLC", "NameLC", chamCong.IDLC);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", chamCong.MaNV);
            return View(chamCong);
        }

        // POST: Admin/ChamCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCC,IDLC,MaNV,Day")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamCong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLC = new SelectList(db.LoaiCongs, "IDLC", "NameLC", chamCong.IDLC);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", chamCong.MaNV);
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
