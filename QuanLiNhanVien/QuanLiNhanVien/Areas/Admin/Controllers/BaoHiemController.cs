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
    public class BaoHiemController : Controller
    {
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        // GET: Admin/BaoHiem
        public ActionResult Index()
        {
            var baoHiems = db.BaoHiems.Include(b => b.NhanVien);
            return View(baoHiems.ToList());
        }

        // GET: Admin/BaoHiem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoHiem baoHiem = db.BaoHiems.Find(id);
            if (baoHiem == null)
            {
                return HttpNotFound();
            }
            return View(baoHiem);
        }

        // GET: Admin/BaoHiem/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Name");
            return View();
        }

        // POST: Admin/BaoHiem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBH,MaNV,NameBH,SoTien,MoTa")] BaoHiem baoHiem)
        {
            if (ModelState.IsValid)
            {
                db.BaoHiems.Add(baoHiem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Name", baoHiem.MaNV);
            return View(baoHiem);
        }

        // GET: Admin/BaoHiem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoHiem baoHiem = db.BaoHiems.Find(id);
            if (baoHiem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Name", baoHiem.MaNV);
            return View(baoHiem);
        }

        // POST: Admin/BaoHiem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBH,MaNV,NameBH,SoTien,MoTa")] BaoHiem baoHiem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baoHiem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Name", baoHiem.MaNV);
            return View(baoHiem);
        }

        // GET: Admin/BaoHiem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoHiem baoHiem = db.BaoHiems.Find(id);
            if (baoHiem == null)
            {
                return HttpNotFound();
            }
            return View(baoHiem);
        }

        // POST: Admin/BaoHiem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaoHiem baoHiem = db.BaoHiems.Find(id);
            db.BaoHiems.Remove(baoHiem);
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
