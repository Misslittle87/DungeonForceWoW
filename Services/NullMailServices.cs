namespace DungeonForceWoW.Services
{
    public class NullMailServices : IMailServices
    {
        private readonly ILogger<NullMailServices> logger;

        public NullMailServices(ILogger<NullMailServices> logger)
        {
            this.logger = logger;
        }

        public void SendMessage(string to, string subject, string body)
        {
            logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}
