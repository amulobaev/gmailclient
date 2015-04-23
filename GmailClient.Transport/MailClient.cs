using System;
using System.Collections.Generic;
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
    public class MailClient : IMailClient
    {
        private const string Host = "imap.gmail.com";

        private readonly IAccountInfo _accountInfo;

        /// <summary>
        /// Static constructor
        /// </summary>
        static MailClient()
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
        public MailClient(IAccountInfo accountInfo)
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
            using (ImapClient client = new ImapClient())
            {
                //client.Behavior.FolderTreeBrowseMode = FolderTreeBrowseMode.Full;
                client.Behavior.ExamineFolders = false;

                if (client.Connect(Host, true))
                {
                    if (client.Login(_accountInfo.Email, _accountInfo.Password))
                    {
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
            using (ImapClient client = new ImapClient())
            {
                client.Behavior.ExamineFolders = false;
                client.Behavior.MessageFetchMode = MessageFetchMode.Minimal;

                if (client.Connect("imap.gmail.com", true))
                {
                    if (client.Login(_accountInfo.Email, _accountInfo.Password))
                    {
                        ImapX.Folder folder = client.FindFolder(folderName);
                        if (folder != null)
                        {
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

    }
}