using System;
using SocialNetBot.Application.Services.Interfaces;

namespace SocialNetBot.Application.Services
{
    public class SocialNetAuthorization : ISocialNetAuthorization
    {
        private readonly IBrowserView _browserView;
        private readonly ISocialNetBotEventService _eventService;

        public SocialNetAuthorization(IBrowserView browserView, ISocialNetBotEventService eventService)
        {
            _browserView = browserView ?? throw new ArgumentNullException(nameof(browserView));
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
        }

        public string ExecuteAuthorize(Uri uri, string message)
        {
            _eventService.Write(message);
            _browserView.Navigate(uri);
            return _eventService.Read();
        }
    }
}