using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Школьное_расписание.Models;

namespace Школьное_расписание.Controllers
{
    public class HomeController : Controller
    {
        private DataManager _DataManager;

        public HomeController(DataManager DM)
        {
            _DataManager = DM;
        }

        public ActionResult Index()
        {
            return View();
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