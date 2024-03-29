﻿using System;
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
        private WebClasses wb = new WebClasses();

        // Get: Details by HdrId
        public ActionResult TrxDetails( int? hdrid)
        {
            if (hdrid == null) hdrid = (int)Session["TRXHDRID"];
            Session["TRXHDRID"] = hdrid;

            var details = db.fsTrxDetails.Where(d => d.fsTrxHdrId == hdrid).ToList();
            var Header = db.fsTrxHdrs.Find(hdrid);

            ViewBag.header = Header;

            return View(details);
        }

        // GET: fsTrxDetails
        public ActionResult Index()
        {
            return RedirectToAction("Index", "fsTrxHdrs");
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
            int hdrid = (int)Session["TRXHDRID"];

            Models.fsTrxDetail dtl = new fsTrxDetail();
            dtl.fsTrxHdrId = hdrid;
            dtl.Debit = 0;
            dtl.Credit = 0;
            dtl.fsSubAccntId = 0;

            int entId = wb.getEntityId(this.HttpContext);
            ViewBag.fsAccountId = new SelectList(db.fsAccounts.Where(w=>w.fsEntityId==entId).Select( d => new { Id = d.Id, Text = d.AccntNo + "-" + d.Description + "["+ d.IncreaseCode +"]"}), "Id", "Text");
            ViewBag.fsTrxHdrId = new SelectList(db.fsTrxHdrs, "Id", "trxRemarks", hdrid);
            ViewBag.fsSubAccntId = new SelectList(db.fsSubAccnts.Where(w => w.fsEntityId == entId).Select( d => new { Id = d.Id, Text = d.Id + "-" + d.Name }), "Id", "Text");

            return View(dtl);
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
                return RedirectToAction("TrxDetails");
            }

            int entId = wb.getEntityId(this.HttpContext);
            ViewBag.fsAccountId = new SelectList(db.fsAccounts.Where(w => w.fsEntityId == entId).Select(d => new { Id = d.Id, Text = d.AccntNo + "-" + d.Description + "[" + d.IncreaseCode + "]" }), "Id", "Text", fsTrxDetail.fsAccountId);
            ViewBag.fsTrxHdrId = new SelectList(db.fsTrxHdrs, "Id", "trxRemarks", fsTrxDetail.fsTrxHdrId);
            ViewBag.fsSubAccntId = new SelectList(db.fsSubAccnts.Where(w => w.fsEntityId == entId).Select(d => new { Id = d.Id, Text = d.Id + "-" + d.Name }), "Id", "Text", fsTrxDetail.fsSubAccntId);
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
            int entId = wb.getEntityId(this.HttpContext);
            ViewBag.fsAccountId = new SelectList(db.fsAccounts.Where(w => w.fsEntityId == entId).Select(d => new { Id = d.Id, Text = d.AccntNo + "-" + d.Description + "[" + d.IncreaseCode + "]" }), "Id", "Text", fsTrxDetail.fsAccountId);
            ViewBag.fsTrxHdrId = new SelectList(db.fsTrxHdrs, "Id", "trxRemarks", fsTrxDetail.fsTrxHdrId);
            ViewBag.fsSubAccntId = new SelectList(db.fsSubAccnts.Where(w => w.fsEntityId == entId).Select(d => new { Id = d.Id, Text = d.Id + "-" + d.Name }), "Id", "Text", fsTrxDetail.fsSubAccntId);
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
                return RedirectToAction("TrxDetails");
            }
            int entId = wb.getEntityId(this.HttpContext);
            ViewBag.fsAccountId = new SelectList(db.fsAccounts.Where(w => w.fsEntityId == entId).Select(d => new { Id = d.Id, Text = d.AccntNo + "-" + d.Description + "[" + d.IncreaseCode + "]" }), "Id", "Text", fsTrxDetail.fsAccountId);
            ViewBag.fsTrxHdrId = new SelectList(db.fsTrxHdrs, "Id", "trxRemarks", fsTrxDetail.fsTrxHdrId);
            ViewBag.fsSubAccntId = new SelectList(db.fsSubAccnts.Where(w => w.fsEntityId == entId).Select(d => new { Id = d.Id, Text = d.Id + "-" + d.Name }), "Id", "Text", fsTrxDetail.fsSubAccntId);
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
            return RedirectToAction("TrxDetails");
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
