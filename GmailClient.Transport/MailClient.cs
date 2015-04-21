using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ImapX;
using ImapX.Collections;
using ImapX.Enums;
using Folder = GmailClient.Model.Folder;
using Message = GmailClient.Model.Message;

namespace GmailClient.Transport
{
    public class MailClient
    {
        private readonly string _login;
        private readonly string _password;

        static MailClient()
        {
            Mapper.CreateMap<ImapX.Folder, Folder>();
            Mapper.CreateMap<ImapX.Message, Message>();
        }

        public MailClient(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public IEnumerable<Folder> GetFolders()
        {
            using (ImapClient client = new ImapClient())
            {
                //client.Behavior.FolderTreeBrowseMode = FolderTreeBrowseMode.Full;
                client.Behavior.ExamineFolders = false;

                if (client.Connect("imap.gmail.com", true))
                {
                    if (client.Login(_login, _password))
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
                client.Behavior.MessageFetchMode = MessageFetchMode.Tiny;

                if (client.Connect("imap.gmail.com", true))
                {
                    if (client.Login(_login, _password))
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