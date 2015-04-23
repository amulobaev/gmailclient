using System;
using System.Linq;
using System.Web.Mvc;
using GmailClient.Data;
using GmailClient.Model;
using GmailClient.Models;

namespace GmailClient.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IRepository<Account> _accountRepository;

        public SettingsController(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            AccountSettingsModel model = new AccountSettingsModel();

            Account account = _accountRepository.GetAll().FirstOrDefault();
            if (account != null)
            {
                model.Name = account.Name;
                model.Email = account.Email;
                model.Password = account.Password; // It's just example, not using encryption
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AccountSettingsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Account account = _accountRepository.GetAll().FirstOrDefault();
            if (account == null)
            {
                account = new Account()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
                };
                _accountRepository.Create(account);
            }
            else
            {
                account.Name = model.Name;
                account.Email = model.Email;
                account.Password = model.Password;
                _accountRepository.Update(account);
            }

            return View(model);
        }
    }
}