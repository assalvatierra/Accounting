using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAS.Controllers
{
    public class fsReportsController : Controller
    {
        Models.OasDBContainer db = new Models.OasDBContainer();
        Models.DBClasses db1 = new Models.DBClasses();
        Models.WebClasses wb = new Models.WebClasses();

        // GET: fsReports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrialBalance(int Mon, int Year)
        {
            int entId = wb.getEntityId(this.HttpContext);
            var data = db1.getTrialBalance(Mon, Year, entId);
            return View(data);
        }
        public ActionResult BalanceSheet(int Mon, int Year)
        {
            int entId = wb.getEntityId(this.HttpContext);
            var data = db1.getBalanceSheet(Mon, Year, entId);
            return View(data);
        }
        public ActionResult IncomeStatement(int Mon, int Year)
        {
            int entId = wb.getEntityId(this.HttpContext);
            var data = db1.getBalanceSheet(Mon, Year, entId);
            return View(data);
        }
        public ActionResult JournalList(int Mon, int Year)
        {
            int entId = wb.getEntityId(this.HttpContext);
            var data = db.fsTrxDetails
                .Where(d => d.fsTrxHdr.DtTrx.Month == Mon && d.fsTrxHdr.DtTrx.Year == Year && d.fsTrxHdr.fsEntityId==entId)
                .OrderBy(s => s.fsTrxHdr.DtTrx)
                .ToList();

            return View(data);
        }
        public ActionResult CashFlow(int Mon, int Year)
        {
            int entId = wb.getEntityId(this.HttpContext);
            var accnts = db.fsRptCatAccnts.Where(d => d.fsRptCat.RptCatName == "CASH").Select( s => s.fsAccount.AccntNo);
            var data = db1.getTrialBalance(Mon, Year, entId).Where(d => accnts.Contains(d.AccntNo) );

            return View(data);
        }

    }
}