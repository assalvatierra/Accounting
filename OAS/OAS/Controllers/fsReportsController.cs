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

        // GET: fsReports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrialBalance(int Mon, int Year)
        {
            var data = db1.getTrialBalance(9, 2017);
            return View(data);
        }
        public ActionResult BalanceSheet(int Mon, int Year)
        {
            var data = db1.getBalanceSheet(9, 2017);
            return View(data);
        }
        public ActionResult IncomeStatement(int Mon, int Year)
        {
            var data = db1.getBalanceSheet(9, 2017);
            return View(data);
        }
        public ActionResult JournalList(int Mon, int Year)
        {
            var data = db.fsTrxDetails
                .Where(d => d.fsTrxHdr.DtTrx.Month == 9 && d.fsTrxHdr.DtTrx.Year == 2017)
                .OrderBy(s => s.fsTrxHdr.DtTrx)
                .ToList();

            return View(data);
        }


    }
}