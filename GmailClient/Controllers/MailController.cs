using System;
using System.Net;
using System.Web.Mvc;
using GmailClient.Models;
using GmailClient.Transport;

namespace GmailClient.Controllers
{
    /// <summary>
    /// Mail MVC controller
    /// </summary>
    [Authorize]
    public class MailController : Controller
    {
        private readonly IMailSender _sender;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="sender">Mail sender implementation</param>
        public MailController(IMailSender sender)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");
            _sender = sender;
        }

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
                    _sender.SendMail(model.To, model.Subject, model.Message);
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
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("Not valid data.");
            }
        }
    }
}