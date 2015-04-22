using System.Web.Mvc;

namespace GmailClient.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

    }
}