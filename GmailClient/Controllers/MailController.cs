using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GmailClient.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return RedirectToAction("Inbox");
        }

        public ActionResult Inbox()
        {
            return View();
        }
    }
}