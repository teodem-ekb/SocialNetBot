using TwitterClient.Exceptions;

namespace TwitterClient.Options
{
    public class TwitterClientOptions
    {
        public TwitterClientOptions(string consumerKey, string consumerSecret)
        {
            ConsumerKey = !string.IsNullOrWhiteSpace(consumerKey)
                ? consumerKey
                : throw new TwitterClientException($"Incorrect value: {nameof(consumerKey)}");
            ConsumerSecret = !string.IsNullOrWhiteSpace(consumerSecret)
                ? consumerSecret
                : throw new TwitterClientException($"Incorrect value: {nameof(consumerSecret)}");
        }

        //public TwitterClientOptions(string consumerKey, string consumerSecret, string oauthToken, string oauthTokenSecret)
        //{
        //    ConsumerKey = !string.IsNullOrWhiteSpace(consumerKey)
        //        ? consumerKey
        //        : throw new TwitterClientException($"Incorrect value: {nameof(consumerKey)}");
        //    ConsumerSecret = !string.IsNullOrWhiteSpace(consumerSecret)
        //        ? consumerSecret
        //        : throw new TwitterClientException($"Incorrect value: {nameof(consumerSecret)}");
        //    OauthToken = !string.IsNullOrWhiteSpace(oauthToken)
        //        ? oauthToken
        //        : throw new TwitterClientException($"Incorrect value: {nameof(oauthToken)}");
        //    OauthTokenSecret = !string.IsNullOrWhiteSpace(oauthTokenSecret)
        //        ? oauthTokenSecret
        //        : throw new TwitterClientException($"Incorrect value: {nameof(oauthTokenSecret)}");
        //}

        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }
        public string OauthToken { get; private set; }
        public string OauthTokenSecret { get; private set; }

        public void SetOauthTokens(string oauthToken, string oauthTokenSecret)
        {
            OauthToken = !string.IsNullOrWhiteSpace(oauthToken)
                ? oauthToken
                : throw new TwitterClientException($"Incorrect value: {nameof(oauthToken)}");
            OauthTokenSecret = !string.IsNullOrWhiteSpace(oauthTokenSecret)
                ? oauthTokenSecret
                : throw new TwitterClientException($"Incorrect value: {nameof(oauthTokenSecret)}");
        }
    }
}