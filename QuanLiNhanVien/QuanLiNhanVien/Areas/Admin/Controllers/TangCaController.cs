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
    public class TangCaController : Controller
    {
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        // GET: Admin/TangCa
        public ActionResult Index()
        {
            var tangCas = db.TangCas.Include(t => t.LoaiCa).Include(t => t.Luong);
            return View(tangCas.ToList());
        }

        // GET: Admin/TangCa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TangCa tangCa = db.TangCas.Find(id);
            if (tangCa == null)
            {
                return HttpNotFound();
            }
            return View(tangCa);
        }

        // GET: Admin/TangCa/Create
        public ActionResult Create()
        {
            ViewBag.IDLC = new SelectList(db.LoaiCas, "IDLC", "NameLC");
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri");
            return View();
        }

        // POST: Admin/TangCa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTC,Day,SoGio,IDLC,MaNV")] TangCa tangCa)
        {
            if (ModelState.IsValid)
            {
                db.TangCas.Add(tangCa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLC = new SelectList(db.LoaiCas, "IDLC", "NameLC", tangCa.IDLC);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", tangCa.MaNV);
            return View(tangCa);
        }

        // GET: Admin/TangCa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TangCa tangCa = db.TangCas.Find(id);
            if (tangCa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLC = new SelectList(db.LoaiCas, "IDLC", "NameLC", tangCa.IDLC);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", tangCa.MaNV);
            return View(tangCa);
        }

        // POST: Admin/TangCa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTC,Day,SoGio,IDLC,MaNV")] TangCa tangCa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tangCa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLC = new SelectList(db.LoaiCas, "IDLC", "NameLC", tangCa.IDLC);
            ViewBag.MaNV = new SelectList(db.Luongs, "MaNV", "ViTri", tangCa.MaNV);
            return View(tangCa);
        }

        // GET: Admin/TangCa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TangCa tangCa = db.TangCas.Find(id);
            if (tangCa == null)
            {
                return HttpNotFound();
            }
            return View(tangCa);
        }

        // POST: Admin/TangCa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TangCa tangCa = db.TangCas.Find(id);
            db.TangCas.Remove(tangCa);
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
