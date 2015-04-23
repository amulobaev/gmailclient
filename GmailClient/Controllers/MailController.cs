using System;
using System.Net;
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

        [ChildActionOnly]
        public ActionResult Compose()
        {
            return PartialView(new ComposeMailModel());
        }

        public ActionResult Send(ComposeMailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sender sender = new Sender();
                    sender.SendMail(model.To, model.Subject, model.Message);
                    return Content("Your mail was submitted successfully.");
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Content("There was an error submitting the mail, please try again later.");
                }
            }
            else
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Content("Not valid data.");
            }
        }
    }
}