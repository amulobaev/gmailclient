using System;
using Microsoft.AspNet.Identity;

namespace GmailClient.Model
{
    public class ApplicationUser : IUser
    {
        public ApplicationUser(string name)
        {
            Id = Guid.NewGuid().ToString();
            UserName = name;
        }

        public ApplicationUser(string id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public ApplicationUser(string id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public string Id { get; private set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}