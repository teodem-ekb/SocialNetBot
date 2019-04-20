namespace SocialNetBot.Ui.Services
{
    public interface ISocialNetBotEventHandler
    {
        string Read();
        void Write(string message);
    }
}