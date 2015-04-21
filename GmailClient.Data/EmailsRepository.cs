using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmailClient.Model;

namespace GmailClient.Data
{
    public class EmailsRepository
    {
        private static readonly List<Email> Container;

        static EmailsRepository()
        {
            Container = new List<Email>
            {
                new Email {Subject = "Hello, I'm first message", Message = "First message body"},
                new Email {Subject = "Hello, I'm second message", Message = "Second message body"}
            };
        }

        public IEnumerable<Email> GetAll()
        {
            return Container;
        }

    }
}