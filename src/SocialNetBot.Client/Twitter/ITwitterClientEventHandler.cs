using System;
using SocialNetBot.Client.Delegates;
using TwitterClient.Delegates;

namespace SocialNetBot.Client.Twitter
{
    public interface ITwitterClientEventHandler
    {
        event ReadMessage OnReadMessage;

        event WriteMessage OnWriteMessage;

        string Verify(Uri uri);

        void ShowMessage(string message);
    }
}