using System.Collections.Generic;

namespace TwitterClient.Client
{
    public interface ITwitterClient
    {
        void Authorize();

        IEnumerable<string> ReadTweet(string userName, int count);

        void WriteTweet(string text);
    }
}