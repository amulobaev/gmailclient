using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GmailClient.Model;
using ImapX;
using ImapX.Enums;
using Folder = GmailClient.Model.Folder;
using Message = GmailClient.Model.Message;

namespace GmailClient.Transport
{
    /// <summary>
    /// My custom IMAP client implementation for Gmail
    /// </summary>
    public class GmailClient : IMailClient
    {
        private const string Host = "imap.gmail.com";

        private readonly IAccountInfo _accountInfo;

        /// <summary>
        /// Static constructor
        /// </summary>
        static GmailClient()
        {
            // Set mappings
            Mapper.CreateMap<ImapX.Folder, Folder>();
            Mapper.CreateMap<ImapX.Message, Message>()
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date.HasValue ? src.Date.Value.ToShortDateString() : String.Empty))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body.Text));
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="accountInfo">Mail account info (email, password)</param>
        public GmailClient(IAccountInfo accountInfo)
        {
            if (accountInfo == null)
                throw new ArgumentNullException("accountInfo");
            _accountInfo = accountInfo;
        }

        /// <summary>
        /// Get folders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Folder> GetFolders()
        {
            // Create IMAP client
            using (ImapClient client = new ImapClient())
            {
                client.Behavior.ExamineFolders = false;
                client.Behavior.MessageFetchMode = MessageFetchMode.None;

                // Connect
                if (client.Connect(Host, true))
                {
                    // Login
                    if (client.Login(_accountInfo.Email, _accountInfo.Password))
                    {
                        // Get all folders
                        List<ImapX.Folder> folders = client.AllFolders();
                        return Mapper.Map<List<ImapX.Folder>, List<Folder>>(folders);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Get messages from folder
        /// </summary>
        /// <param name="folderName">Folder name</param>
        /// <returns></returns>
        public IEnumerable<Message> GetMessages(string folderName)
        {
            // // Create IMAP client
            using (ImapClient client = new ImapClient())
            {
                client.Behavior.ExamineFolders = false;
                client.Behavior.MessageFetchMode = MessageFetchMode.Minimal;

                // Connect
                if (client.Connect(Host, true))
                {
                    // Login
                    if (client.Login(_accountInfo.Email, _accountInfo.Password))
                    {
                        // Find folder
                        ImapX.Folder folder = client.FindFolder(folderName);
                        if (folder != null)
                        {
                            // Download messages
                            folder.Messages.Download(mode: MessageFetchMode.Minimal);
                            List<Message> messages =
                                Mapper.Map<IEnumerable<ImapX.Message>, List<Message>>(folder.Messages);
                            return messages;
                        }
                    }
                }
            }

            return null;
        }

        public void DeleteMessage(int id)
        {
            // // Create IMAP client
            using (ImapClient client = new ImapClient())
            {
                client.Behavior.ExamineFolders = false;
                //client.Behavior.MessageFetchMode = MessageFetchMode.Minimal;

                // Connect
                if (client.Connect(Host, true))
                {
                    // Login
                    if (client.Login(_accountInfo.Email, _accountInfo.Password))
                    {
                        // Find folder
                        ImapX.Folder folder = client.FindFolder("All Mail");
                        if (folder != null)
                        {
                            var messages = folder.Search(new[] { (long)id });
                            if (messages.Any())
                                messages[0].Remove();
                        }
                    }
                }
            }
        }
    }
}