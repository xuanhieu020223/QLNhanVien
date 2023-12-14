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
    public class BoPhanController : Controller
    {
        private QuanLyNhanVienEntities db = new QuanLyNhanVienEntities();

        // GET: Admin/BoPhan
        public ActionResult Index()
        {
            return View(db.BoPhans.ToList());
        }

        // GET: Admin/BoPhan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoPhan boPhan = db.BoPhans.Find(id);
            if (boPhan == null)
            {
                return HttpNotFound();
            }
            return View(boPhan);
        }

        // GET: Admin/BoPhan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BoPhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBP,NameBP")] BoPhan boPhan)
        {
            if (ModelState.IsValid)
            {
                db.BoPhans.Add(boPhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boPhan);
        }

        // GET: Admin/BoPhan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoPhan boPhan = db.BoPhans.Find(id);
            if (boPhan == null)
            {
                return HttpNotFound();
            }
            return View(boPhan);
        }

        // POST: Admin/BoPhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBP,NameBP")] BoPhan boPhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boPhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boPhan);
        }

        // GET: Admin/BoPhan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoPhan boPhan = db.BoPhans.Find(id);
            if (boPhan == null)
            {
                return HttpNotFound();
            }
            return View(boPhan);
        }

        // POST: Admin/BoPhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoPhan boPhan = db.BoPhans.Find(id);
            db.BoPhans.Remove(boPhan);
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
