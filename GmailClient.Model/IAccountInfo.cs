namespace GmailClient.Model
{
    /// <summary>
    /// Mail account info
    /// </summary>
    public interface IAccountInfo
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Email
        /// </summary>
        string Email { get; }
        
        /// <summary>
        /// Password
        /// </summary>
        string Password { get; }
    }
}