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
    public class PhuCapController : Controller
    {
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        // GET: Admin/PhuCap
        public ActionResult Index()
        {
            var phuCapNVs = db.PhuCapNVs.Include(p => p.Luong);
            return View(phuCapNVs.ToList());
        }

        // GET: Admin/PhuCap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhuCapNV phuCapNV = db.PhuCapNVs.Find(id);
            if (phuCapNV == null)
            {
                return HttpNotFound();
            }
            return View(phuCapNV);
        }

        // GET: Admin/PhuCap/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri");
            return View();
        }

        // POST: Admin/PhuCap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPC,NamePC,MaNV,SoTien,MoTa")] PhuCapNV phuCapNV)
        {
            if (ModelState.IsValid)
            {
                db.PhuCapNVs.Add(phuCapNV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", phuCapNV.MaNV);
            return View(phuCapNV);
        }

        // GET: Admin/PhuCap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhuCapNV phuCapNV = db.PhuCapNVs.Find(id);
            if (phuCapNV == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", phuCapNV.MaNV);
            return View(phuCapNV);
        }

        // POST: Admin/PhuCap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPC,NamePC,MaNV,SoTien,MoTa")] PhuCapNV phuCapNV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phuCapNV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", phuCapNV.MaNV);
            return View(phuCapNV);
        }

        // GET: Admin/PhuCap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhuCapNV phuCapNV = db.PhuCapNVs.Find(id);
            if (phuCapNV == null)
            {
                return HttpNotFound();
            }
            return View(phuCapNV);
        }

        // POST: Admin/PhuCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhuCapNV phuCapNV = db.PhuCapNVs.Find(id);
            db.PhuCapNVs.Remove(phuCapNV);
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
