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