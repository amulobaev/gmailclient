using System.Web.Mvc;
using GmailClient.Models;
using GmailClient.Transport;

namespace GmailClient.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index(string folder = "INBOX")
        {
            return View(new MailModel() { Folder = folder });
        }

        public ActionResult Compose()
        {
            return View();
        }

        public ActionResult Send(ComposeMailModel model)
        {
            if (ModelState.IsValid)
            {
                Sender sender = new Sender();
                sender.SendMail(model.To, model.Subject, model.Message);
                return Content("Success");
            }
            else
            {
                return Content("Error");
            }
        }
    }
}