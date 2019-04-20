using SocialNetBot.Application.Delegates;

namespace SocialNetBot.Application.Services.Interfaces
{
    public interface ISocialNetBotEventService
    {
        event ReadMessage OnReadMessage;
        event WriteMessage OnWriteMessage;

        string Read();
        void Write(string message);
    }
}