using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GmailClient.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Mail(string folder = "Inbox")
        {
            return View();
        }

        [Authorize]
        public ActionResult Settings()
        {
            return View();
        }
    }
}