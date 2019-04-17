namespace TwitterClient.Options
{
    public class TwitterClientOptions
    {
        public TwitterClientOptions(string consumerKey, string consumerSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
        }

        public TwitterClientOptions(string consumerKey, string consumerSecret, string oauthToken, string oauthTokenSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            OauthToken = oauthToken;
            OauthTokenSecret = oauthTokenSecret;
        }

        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }
        public string OauthToken { get; private set; }
        public string OauthTokenSecret { get; private set; }

        public void SetOauthTokens(string oauthToken, string oauthTokenSecret)
        {
            OauthToken = oauthToken;
            OauthTokenSecret = oauthTokenSecret;
        }
    }
}