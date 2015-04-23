using System;
using System.Collections.Generic;
using System.Linq;
using ImapX;
using ImapX.Collections;

namespace GmailClient.Transport
{
    /// <summary>
    /// Some usefull extensions
    /// </summary>
    public static class Extensions
    {
        public static List<Folder> AllFolders(this ImapClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            List<Folder> folders = new List<Folder>();

            foreach (Folder folder in client.Folders)
            {
                GetFolders(folder, folders);
            }

            return folders;
        }

        private static void GetFolders(Folder folder, List<Folder> folders)
        {
            if (folder.Selectable)
                folders.Add(folder);

            if (folder.HasChildren)
            {
                foreach (Folder subFolder in folder.SubFolders)
                {
                    GetFolders(subFolder, folders);
                }
            }
        }

        public static Folder FindFolder(this ImapClient client, string name)
        {
            return FindFolder(client.Folders, name);
        }

        private static Folder FindFolder(FolderCollection folderCollection, string name)
        {
            Folder folder = folderCollection.FirstOrDefault(x => x.Name == name);
            if (folder != null)
                return folder;

            foreach (Folder folder1 in folderCollection)
            {
                Folder folder2 = FindFolder(folder1.SubFolders, name);
                if (folder2 != null)
                    return folder2;
            }

            return null;
        }

    }
}
