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
    public class fsAccountsController : Controller
    {
        private OasDBContainer db = new OasDBContainer();

        // GET: fsAccounts
        public ActionResult Index()
        {
            var fsAccounts = db.fsAccounts.Include(f => f.fsAccntCategory);
            return View(fsAccounts.ToList());
        }

        // GET: fsAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsAccount fsAccount = db.fsAccounts.Find(id);
            if (fsAccount == null)
            {
                return HttpNotFound();
            }
            return View(fsAccount);
        }

        // GET: fsAccounts/Create
        public ActionResult Create()
        {
            ViewBag.fsAccntCategoryId = new SelectList(db.fsAccntCategories, "Id", "Name");
            return View();
        }

        // POST: fsAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccntNo,AccntTitle,Description,IncreaseCode,fsAccntCategoryId")] fsAccount fsAccount)
        {
            if (ModelState.IsValid)
            {
                db.fsAccounts.Add(fsAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fsAccntCategoryId = new SelectList(db.fsAccntCategories, "Id", "Name", fsAccount.fsAccntCategoryId);
            return View(fsAccount);
        }

        // GET: fsAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsAccount fsAccount = db.fsAccounts.Find(id);
            if (fsAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.fsAccntCategoryId = new SelectList(db.fsAccntCategories, "Id", "Name", fsAccount.fsAccntCategoryId);
            return View(fsAccount);
        }

        // POST: fsAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccntNo,AccntTitle,Description,IncreaseCode,fsAccntCategoryId")] fsAccount fsAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fsAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fsAccntCategoryId = new SelectList(db.fsAccntCategories, "Id", "Name", fsAccount.fsAccntCategoryId);
            return View(fsAccount);
        }

        // GET: fsAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fsAccount fsAccount = db.fsAccounts.Find(id);
            if (fsAccount == null)
            {
                return HttpNotFound();
            }
            return View(fsAccount);
        }

        // POST: fsAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fsAccount fsAccount = db.fsAccounts.Find(id);
            db.fsAccounts.Remove(fsAccount);
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
