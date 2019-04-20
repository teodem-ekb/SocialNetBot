using System;
using SocialNetBot.Application.Services.Interfaces;

namespace SocialNetBot.Ui.Services
{
    public class SocialNetBotEventHandler : ISocialNetBotEventHandler
    {
        private readonly ISocialNetBotEventService _socialNetBotEventService;

        public SocialNetBotEventHandler(ISocialNetBotEventService socialNetBotEventService)
        {
            _socialNetBotEventService = socialNetBotEventService ?? throw new ArgumentNullException(nameof(socialNetBotEventService));
        }

        public void Subscribe()
        {
            _socialNetBotEventService.OnReadMessage += Read;
            _socialNetBotEventService.OnWriteMessage += Write;
        }
        private static string Read()
        {
            return Console.ReadLine();
        }

        private static void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}