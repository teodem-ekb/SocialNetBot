using System;
using System.Collections.Generic;
using System.Linq;
using TweetSharp;
using TwitterClient.Options;

namespace TwitterClient.Client
{
    public class TwitterClient : TwitterClientBase, ITwitterClient
    {
        private readonly TwitterClientOptions _options;
        private ITwitterService _twitterService;

        public TwitterClient(TwitterClientOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Authorize()
        {
            _twitterService = new TwitterService(_options.ConsumerKey, _options.ConsumerSecret);
            if (string.IsNullOrWhiteSpace(_options.OauthToken) && string.IsNullOrWhiteSpace(_options.OauthTokenSecret))
            {
                var requestToken = _twitterService.GetRequestToken();
                var uri = _twitterService.GetAuthenticationUrl(requestToken);

                OnShowMessageMethod("Введите PIN");
                var verifier = OnVerifyMethod(uri);

                var access = _twitterService.GetAccessToken(requestToken, verifier);
                _options.SetOauthTokens(access.Token, access.TokenSecret);
            }
            _twitterService.AuthenticateWith(_options.OauthToken, _options.OauthTokenSecret);
        }

        public IEnumerable<string> ReadTweet(string userName, int count)
        {
            try
            {
                var requestOptions = new ListTweetsOnUserTimelineOptions { ScreenName = userName, Count = count };
                var tweets = _twitterService.ListTweetsOnUserTimeline(requestOptions);

                return (tweets ?? throw new Exception("Пользователь с таким именем не найден!"))
                    .Select(t => t.Text);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void WriteTweet(string text)
        {
            if (text.Length >= 139)
            {
                var tweets = SeparateTweet(text, 139);
                WriteTweets(tweets.ToArray());
            }
            else
            {
                WriteTweets(text);
            }
        }

        private void WriteTweets(params string[] tweets)
        {
            foreach (var itemTweet in tweets)
            {
                var requestOptions = new SendTweetOptions { Status = itemTweet };
                _twitterService.SendTweet(requestOptions, (tweet, response) =>
                {
                    OnShowMessageMethod(response.StatusCode.ToString());
                });
            }
        }
    }
}