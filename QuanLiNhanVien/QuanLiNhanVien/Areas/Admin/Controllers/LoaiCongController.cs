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
    public class LoaiCongController : Controller
    {
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        // GET: Admin/LoaiCong
        public ActionResult Index()
        {
            return View(db.LoaiCongs.ToList());
        }

        // GET: Admin/LoaiCong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiCong loaiCong = db.LoaiCongs.Find(id);
            if (loaiCong == null)
            {
                return HttpNotFound();
            }
            return View(loaiCong);
        }

        // GET: Admin/LoaiCong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLC,NameLC,HeSo,MoTa")] LoaiCong loaiCong)
        {
            if (ModelState.IsValid)
            {
                db.LoaiCongs.Add(loaiCong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiCong);
        }

        // GET: Admin/LoaiCong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiCong loaiCong = db.LoaiCongs.Find(id);
            if (loaiCong == null)
            {
                return HttpNotFound();
            }
            return View(loaiCong);
        }

        // POST: Admin/LoaiCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLC,NameLC,HeSo,MoTa")] LoaiCong loaiCong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiCong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiCong);
        }

        // GET: Admin/LoaiCong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiCong loaiCong = db.LoaiCongs.Find(id);
            if (loaiCong == null)
            {
                return HttpNotFound();
            }
            return View(loaiCong);
        }

        // POST: Admin/LoaiCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiCong loaiCong = db.LoaiCongs.Find(id);
            db.LoaiCongs.Remove(loaiCong);
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
