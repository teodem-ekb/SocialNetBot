using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SocialNetBot.Client.Exceptions;
using SocialNetBot.Client.Options;
using TwitterClient.Client;
using TwitterClient.Options;

namespace SocialNetBot.Client.Twitter
{
    public class TwitterSocialNetClient : TwitterSocialNetClientBase
    {
        private readonly ITwitterClient _twitterClient;
        private readonly IOptions<SocialNetClientAppConfig> _options;
        private readonly ILogger<TwitterSocialNetClient> _logger;
        private readonly ITwitterClientEventHandler _twitterClientEventHandler;

        public TwitterSocialNetClient(IOptions<SocialNetClientAppConfig> options, ILogger<TwitterSocialNetClient> logger, ITwitterClientEventHandler twitterClientEventHandler)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _twitterClientEventHandler = twitterClientEventHandler ?? throw new ArgumentNullException(nameof(twitterClientEventHandler));
            _twitterClient = InitializeClient();
        }

        public override IEnumerable<string> ReadUserPosts(string userName, int count)
        {
            try
            {
                return _twitterClient.ReadTweet(userName, count);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(ex.HResult), ex, ex.Message);
                throw new SocialNetClientException(ex.Message);
            }

        }

        public override void WritePost(string text)
        {
            try
            {
                _twitterClient.WriteTweet(text);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(ex.HResult), ex, ex.Message);
                throw new SocialNetClientException(ex.Message);
            }
        }

        private ITwitterClient InitializeClient()
        {
            try
            {
                var twitterOptions = new TwitterClientOptions(_options.Value.OpenKey, _options.Value.SecretKey);
                var result = new TwitterClient.Client.TwitterClient(twitterOptions);
                EventHandler = _twitterClientEventHandler;
                TwitterClientBase = result;
                SubscribeOnEvent();
                result.Authorize();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(ex.HResult), ex, ex.Message);
                throw new SocialNetClientException(ex.Message);
            }
        }
    }
}