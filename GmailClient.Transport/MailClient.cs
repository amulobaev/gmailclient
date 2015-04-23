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
    /// My custom IMAP client implementation
    /// </summary>
    public class MailClient
    {
        private readonly IAccountInfo _accountInfo;

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
        /// Constructor
        /// </summary>
        /// <param name="accountInfo">Mail account info (email, password)</param>
        public MailClient(IAccountInfo accountInfo)
        {
            if (accountInfo == null)
                throw new ArgumentNullException("accountInfo");
            _accountInfo = accountInfo;
        }

        public IEnumerable<Folder> GetFolders()
        {
            using (ImapClient client = new ImapClient())
            {
                //client.Behavior.FolderTreeBrowseMode = FolderTreeBrowseMode.Full;
                client.Behavior.ExamineFolders = false;

                if (client.Connect("imap.gmail.com", true))
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