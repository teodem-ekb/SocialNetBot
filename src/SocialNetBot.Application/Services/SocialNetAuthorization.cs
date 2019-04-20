using System;

namespace SocialNetBot.Application.Services
{
    public class SocialNetAuthorization : ISocialNetAuthorization
    {
        private readonly IBrowserView _browserView;

        public SocialNetAuthorization(IBrowserView browserView)
        {
            _browserView = browserView ?? throw new ArgumentNullException(nameof(browserView));
        }

        public string ExecuteAuthorize(Uri uri, string message)
        {
            Console.WriteLine(message);
            _browserView.Navigate(uri);
            return Console.ReadLine();
        }
    }
}