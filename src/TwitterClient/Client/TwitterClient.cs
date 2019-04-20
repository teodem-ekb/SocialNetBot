using System;
using System.Collections.Generic;
using System.Linq;
using TweetSharp;
using TwitterClient.Exceptions;
using TwitterClient.Options;

namespace TwitterClient.Client
{
    public class TwitterClient : ITwitterClient
    {
        private readonly TwitterClientOptions _options;
        private ITwitterService _twitterService;

        public TwitterClient(TwitterClientOptions options)
        {
            _options = options ?? throw new TwitterClientException($"Incorrect value: {nameof(options)}");
        }

        public void Authorize(Func<Uri,string,string> func)
        {
            _twitterService = new TwitterService(_options.ConsumerKey, _options.ConsumerSecret);
            if (string.IsNullOrWhiteSpace(_options.OauthToken) && string.IsNullOrWhiteSpace(_options.OauthTokenSecret))
            {
                var requestToken = _twitterService.GetRequestToken();
                var uri = _twitterService.GetAuthenticationUrl(requestToken);
               
                var verifier = func(uri, "Введите PIN");
                var access = _twitterService.GetAccessToken(requestToken, verifier);
                _options.SetOauthTokens(access.Token, access.TokenSecret);
            }
            _twitterService.AuthenticateWith(_options.OauthToken, _options.OauthTokenSecret);
        }

        public IEnumerable<string> ReadTweet(string userName, int count)
        {

            var requestOptions = new ListTweetsOnUserTimelineOptions { ScreenName = userName, Count = count };
            var tweets = _twitterService.ListTweetsOnUserTimeline(requestOptions);

            if (tweets != null)
            {
                return tweets.Select(x => x.Text);
            }
            throw new TwitterClientException("Пользователь с таким именем не найден!");
        }

        public string WriteTweet(string text)
        {
            var statusCode = string.Empty;
            var requestOptions = new SendTweetOptions { Status = text };
            _twitterService.SendTweet(requestOptions, (tweet, response) =>
            {
                statusCode = response.StatusCode.ToString();
            });
            return statusCode;
        }
    }
}