namespace GmailClient.Model
{
    public interface IAccountInfo
    {
        string Name { get; }
        
        string Email { get; }
        
        string Password { get; }
    }
}