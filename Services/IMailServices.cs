namespace DungeonForceWoW.Services
{
    public interface IMailServices
    {
        void SendMessage(string to, string subject, string body);
    }
}