using System.Collections.Generic;
using GmailClient.Model;

namespace GmailClient.Transport
{
    /// <summary>
    /// Mail client interface
    /// </summary>
    public interface IMailClient
    {
        /// <summary>
        /// Get folders
        /// </summary>
        /// <returns></returns>
        IEnumerable<Folder> GetFolders();
        
        /// <summary>
        /// Get messages from folder
        /// </summary>
        /// <param name="folderName">Folder name</param>
        /// <returns></returns>
        IEnumerable<Message> GetMessages(string folderName);
    }
}