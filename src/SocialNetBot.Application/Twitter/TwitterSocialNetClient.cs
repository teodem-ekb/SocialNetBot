using Microsoft.Extensions.Options;
using SocialNetBot.Application.Options;
using SocialNetBot.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TwitterClient.Client;
using TwitterClient.Options;

namespace SocialNetBot.Application.Twitter
{
    public class TwitterSocialNetClient : ISocialNetClient
    {
        private const int LimitCharsOnTweet = 139;
        private readonly ITwitterClient _twitterClient;
        private readonly IOptions<SocialNetClientAppConfig> _options;
        private readonly IMessageSeparatorService _messageSeparator;
        private readonly ISocialNetAuthorization _socialNetAuthorization;

        public TwitterSocialNetClient(IOptions<SocialNetClientAppConfig> options, IMessageSeparatorService messageSeparator, ISocialNetAuthorization socialNetAuthorization)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _messageSeparator = messageSeparator ?? throw new ArgumentNullException(nameof(messageSeparator));
            _socialNetAuthorization = socialNetAuthorization ?? throw new ArgumentNullException(nameof(socialNetAuthorization));
            _twitterClient = InitializeClient();
        }

        public IEnumerable<string> ReadUserPosts(string userName, int count)
        {
            return _twitterClient.ReadTweet(userName, count);
        }

        public void WritePost(string text)
        {
            if (text.Length >= LimitCharsOnTweet)
            {
                var tweets = _messageSeparator.Separate(text, LimitCharsOnTweet).ToList();
                var s = tweets.Select(x => _twitterClient.WriteTweet(x));
            }
            else
            {
                var s = _twitterClient.WriteTweet(text);
            }

            Console.WriteLine("Ok");
        }

        private ITwitterClient InitializeClient()
        {

            var twitterOptions = new TwitterClientOptions(_options.Value.OpenKey, _options.Value.SecretKey);
            var result = new TwitterClient.Client.TwitterClient(twitterOptions);
            result.Authorize(_socialNetAuthorization.ExecuteAuthorize);
            return result;
        }
    }
}