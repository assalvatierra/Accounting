using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAS.Controllers
{
    public class HomeController : Controller
    {
        Models.DBClasses db1 = new Models.DBClasses();

        public ActionResult Index()
        {
            if (!this.HttpContext.User.Identity.IsAuthenticated)
                Session["UserEntity"] = null;

            var fsEnt = db1.getUserEntities(this.HttpContext.User.Identity.Name);

            if(fsEnt.Count==1)
            {
                var tmp = fsEnt.FirstOrDefault();
                Session["UserEntity"] = tmp;
            }

            if(fsEnt.Count > 0 )
            {
                if (Session["UserEntity"] == null)
                {
                    return RedirectToAction("EntityList");
                }
                else
                {
                    Models.fsEntity tmp = (Models.fsEntity)Session["UserEntity"];
                    if (!fsEnt.Select(s => s.Name).ToList().Contains(tmp.Name)) 
                    {
                        return RedirectToAction("EntityList");
                    }
                }
            }

            ViewBag.Entity = Session["UserEntity"];
            return View();
        }

        public ActionResult EntityList()
        {
            var fsEnt = db1.getUserEntities(this.HttpContext.User.Identity.Name);
            return View(fsEnt);
        }

        public ActionResult SelectEntity(int? id)
        {
            Session["UserEntity"] = db1.getEntity( (int)id );
            return RedirectToAction("index");
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

        public ActionResult BalanceSheet()
        {
            int iMon = System.DateTime.Today.Month;
            int iYear = System.DateTime.Today.Year;
            return RedirectToAction("BalanceSheet", "fsReports", new { Mon = iMon, Year = iYear });
        }

        public ActionResult IncomeStatement()
        {
            int iMon = System.DateTime.Today.Month;
            int iYear = System.DateTime.Today.Year;
            return RedirectToAction("IncomeStatement", "fsReports", new { Mon = iMon, Year = iYear });
        }

        public ActionResult JournalList()
        {
            int iMon = System.DateTime.Today.Month;
            int iYear = System.DateTime.Today.Year;
            return RedirectToAction("JournalList", "fsReports", new { Mon = iMon, Year = iYear });
        }
        public ActionResult CashFlow()
        {
            int iMon = System.DateTime.Today.Month;
            int iYear = System.DateTime.Today.Year;
            return RedirectToAction("CashFlow", "fsReports", new { Mon = iMon, Year = iYear });
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