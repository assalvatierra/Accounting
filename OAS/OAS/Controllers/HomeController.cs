using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TransactionList()
        {
            return RedirectToAction("index", "fsTrxHdrs");
        }

        public ActionResult AccountsList()
        {
            return RedirectToAction("Index", "fsAccounts");
        }

        public ActionResult SubAccountsList()
        {
            return RedirectToAction("index", "fsSubAccnts");
        }

        public ActionResult TrialBalance()
        {
            int iMon = System.DateTime.Today.Month;
            int iYear = System.DateTime.Today.Year;
            return RedirectToAction("TrialBalance", "fsReports", new { Mon = iMon, Year = iYear });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}