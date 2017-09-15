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
    public class fsTrxDetailsController : Controller
    {
        private OasDBContainer db = new OasDBContainer();

        // Get: Details by HdrId
        public ActionResult TrxDetails( int? hdrid)
        {
            var details = db.fsTrxDetails.Where(d => d.fsTrxHdrId == hdrid).ToList();
            var Header = db.fsTrxHdrs.Find(hdrid);

            ViewBag.header = Header;

            return View(details);
        }

        // GET: fsTrxDetails
        public ActionResult Index()
        {
            var fsTrxDetails = db.fsTrxDetails.Include(f => f.fsAccount).Include(f => f.fsTrxHdr).Include(f => f.fsSubAccnt);
            return View(fsTrxDetails.ToList());
        }

        // GET: fsTrxDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsTrxDetail fsTrxDetail = db.fsTrxDetails.Find(id);
            if (fsTrxDetail == null)
            {
                return HttpNotFound();
            }
            return View(fsTrxDetail);
        }

        // GET: fsTrxDetails/Create
        public ActionResult Create()
        {
            ViewBag.fsAccountId = new SelectList(db.fsAccounts, "Id", "AccntNo");
            ViewBag.fsTrxHdrId = new SelectList(db.fsTrxHdrs, "Id", "trxRemarks");
            ViewBag.fsSubAccntId = new SelectList(db.fsSubAccnts, "Id", "Name");
            return View();
        }

        // POST: fsTrxDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fsTrxHdrId,fsAccountId,fsSubAccntId,Description,Debit,Credit")] fsTrxDetail fsTrxDetail)
        {
            if (ModelState.IsValid)
            {
                db.fsTrxDetails.Add(fsTrxDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fsAccountId = new SelectList(db.fsAccounts, "Id", "AccntNo", fsTrxDetail.fsAccountId);
            ViewBag.fsTrxHdrId = new SelectList(db.fsTrxHdrs, "Id", "trxRemarks", fsTrxDetail.fsTrxHdrId);
            ViewBag.fsSubAccntId = new SelectList(db.fsSubAccnts, "Id", "Name", fsTrxDetail.fsSubAccntId);
            return View(fsTrxDetail);
        }

        // GET: fsTrxDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsTrxDetail fsTrxDetail = db.fsTrxDetails.Find(id);
            if (fsTrxDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.fsAccountId = new SelectList(db.fsAccounts, "Id", "AccntNo", fsTrxDetail.fsAccountId);
            ViewBag.fsTrxHdrId = new SelectList(db.fsTrxHdrs, "Id", "trxRemarks", fsTrxDetail.fsTrxHdrId);
            ViewBag.fsSubAccntId = new SelectList(db.fsSubAccnts, "Id", "Name", fsTrxDetail.fsSubAccntId);
            return View(fsTrxDetail);
        }

        // POST: fsTrxDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fsTrxHdrId,fsAccountId,fsSubAccntId,Description,Debit,Credit")] fsTrxDetail fsTrxDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fsTrxDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fsAccountId = new SelectList(db.fsAccounts, "Id", "AccntNo", fsTrxDetail.fsAccountId);
            ViewBag.fsTrxHdrId = new SelectList(db.fsTrxHdrs, "Id", "trxRemarks", fsTrxDetail.fsTrxHdrId);
            ViewBag.fsSubAccntId = new SelectList(db.fsSubAccnts, "Id", "Name", fsTrxDetail.fsSubAccntId);
            return View(fsTrxDetail);
        }

        // GET: fsTrxDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsTrxDetail fsTrxDetail = db.fsTrxDetails.Find(id);
            if (fsTrxDetail == null)
            {
                return HttpNotFound();
            }
            return View(fsTrxDetail);
        }

        // POST: fsTrxDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fsTrxDetail fsTrxDetail = db.fsTrxDetails.Find(id);
            db.fsTrxDetails.Remove(fsTrxDetail);
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
