using System;
using System.Collections.Generic;

namespace TwitterClient.Client
{
    public interface ITwitterClient
    {
        void Authorize(Func<Uri, string, string> func);

        IEnumerable<string> ReadTweet(string userName, int count);

        void WriteTweet(string text);
    }
}