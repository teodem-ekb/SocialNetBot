using SocialNetBot.Application.Delegates;
using SocialNetBot.Application.Services.Interfaces;

namespace SocialNetBot.Application.Services
{
    public class SocialNetBotEventService : ISocialNetBotEventService
    {
        public event ReadMessage OnReadMessage = () => string.Empty;
        public event WriteMessage OnWriteMessage = message => { };

        public string Read()
        {
            return OnReadMessage();
        }

        public void Write(string message)
        {
            OnWriteMessage(message);
        }
    }
}