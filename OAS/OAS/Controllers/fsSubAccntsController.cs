using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OAS.Models;

namespace OAS.Controllers
{
    public class fsSubAccntsController : Controller
    {
        private OasDBContainer db = new OasDBContainer();

        // GET: fsSubAccnts
        public ActionResult Index()
        {
            var fsSubAccnts = db.fsSubAccnts.Include(f => f.fsAccount);
            return View(fsSubAccnts.ToList());
        }

        // GET: fsSubAccnts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsSubAccnt fsSubAccnt = db.fsSubAccnts.Find(id);
            if (fsSubAccnt == null)
            {
                return HttpNotFound();
            }
            return View(fsSubAccnt);
        }

        // GET: fsSubAccnts/Create
        public ActionResult Create()
        {
            ViewBag.fsAccountId = new SelectList(db.fsAccounts, "Id", "AccntNo");
            return View();
        }

        // POST: fsSubAccnts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fsAccountId,Name,Remarks")] fsSubAccnt fsSubAccnt)
        {
            if (ModelState.IsValid)
            {
                db.fsSubAccnts.Add(fsSubAccnt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fsAccountId = new SelectList(db.fsAccounts, "Id", "AccntNo", fsSubAccnt.fsAccountId);
            return View(fsSubAccnt);
        }

        // GET: fsSubAccnts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsSubAccnt fsSubAccnt = db.fsSubAccnts.Find(id);
            if (fsSubAccnt == null)
            {
                return HttpNotFound();
            }
            ViewBag.fsAccountId = new SelectList(db.fsAccounts, "Id", "AccntNo", fsSubAccnt.fsAccountId);
            return View(fsSubAccnt);
        }

        // POST: fsSubAccnts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fsAccountId,Name,Remarks")] fsSubAccnt fsSubAccnt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fsSubAccnt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fsAccountId = new SelectList(db.fsAccounts, "Id", "AccntNo", fsSubAccnt.fsAccountId);
            return View(fsSubAccnt);
        }

        // GET: fsSubAccnts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsSubAccnt fsSubAccnt = db.fsSubAccnts.Find(id);
            if (fsSubAccnt == null)
            {
                return HttpNotFound();
            }
            return View(fsSubAccnt);
        }

        // POST: fsSubAccnts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fsSubAccnt fsSubAccnt = db.fsSubAccnts.Find(id);
            db.fsSubAccnts.Remove(fsSubAccnt);
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
