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
    public class fsTrxHdrsController : Controller
    {
        private OasDBContainer db = new OasDBContainer();
        private WebClasses wb = new WebClasses();

        // GET: fsTrxHdrs
        public ActionResult Index()
        {
            var fsTrxHdrs = db.fsTrxHdrs.Include(f => f.fsTrxStatus);
            fsTrxHdrs.Where(d => d.fsEntityId== wb.getEntityId(this.HttpContext) );
            return View(fsTrxHdrs.ToList());
        }

        // GET: fsTrxHdrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsTrxHdr fsTrxHdr = db.fsTrxHdrs.Find(id);
            if (fsTrxHdr == null)
            {
                return HttpNotFound();
            }
            return View(fsTrxHdr);
        }

        // GET: fsTrxHdrs/Create
        public ActionResult Create()
        {
            var newtrx = new Models.fsTrxHdr();
            newtrx.DtTrx = System.DateTime.Now;
            newtrx.dtEntry = System.DateTime.Now;
            newtrx.EnteredBy = HttpContext.User.Identity.Name;

            ViewBag.fsTrxStatusId = new SelectList(db.fsTrxStatus, "Id", "Status");
            return View(newtrx);
        }

        // POST: fsTrxHdrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DtTrx,trxRemarks,dtEntry,EnteredBy,dtEdit,EditedBy,fsTrxStatusId")] fsTrxHdr fsTrxHdr)
        {
            if (Session["UserEntity"] != null)
            {
                var temp = (fsEntity)Session["UserEntity"];
                fsTrxHdr.fsEntityId = temp.Id;
            }

            if (ModelState.IsValid)
            {
                db.fsTrxHdrs.Add(fsTrxHdr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fsTrxStatusId = new SelectList(db.fsTrxStatus, "Id", "Status", fsTrxHdr.fsTrxStatusId);
            return View(fsTrxHdr);
        }

        // GET: fsTrxHdrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsTrxHdr fsTrxHdr = db.fsTrxHdrs.Find(id);
            if (fsTrxHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.fsTrxStatusId = new SelectList(db.fsTrxStatus, "Id", "Status", fsTrxHdr.fsTrxStatusId);
            return View(fsTrxHdr);
        }

        // POST: fsTrxHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DtTrx,trxRemarks,dtEntry,EnteredBy,dtEdit,EditedBy,fsTrxStatusId")] fsTrxHdr fsTrxHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fsTrxHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fsTrxStatusId = new SelectList(db.fsTrxStatus, "Id", "Status", fsTrxHdr.fsTrxStatusId);
            return View(fsTrxHdr);
        }

        // GET: fsTrxHdrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsTrxHdr fsTrxHdr = db.fsTrxHdrs.Find(id);
            if (fsTrxHdr == null)
            {
                return HttpNotFound();
            }
            return View(fsTrxHdr);
        }

        // POST: fsTrxHdrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fsTrxHdr fsTrxHdr = db.fsTrxHdrs.Find(id);
            db.fsTrxHdrs.Remove(fsTrxHdr);
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
