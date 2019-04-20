using System.Collections.Generic;
using TwitterClient.Client;

namespace SocialNetBot.Client.Twitter
{
    public abstract class TwitterSocialNetClientBase : ISocialNetClient
    {
        protected TwitterClientBase TwitterClientBase;
        protected ITwitterClientEventHandler EventHandler;

        public abstract IEnumerable<string> ReadUserPosts(string userName, int count);

        public abstract void WritePost(string text);

        protected void SubscribeOnEvent()
        {
            TwitterClientBase.OnVerify += EventHandler.Verify;
            TwitterClientBase.OnShowMessage += EventHandler.ShowMessage;
        }

        public void UnsubscribeOnEvent()
        {
            TwitterClientBase.OnVerify -= EventHandler.Verify;
            TwitterClientBase.OnShowMessage -= EventHandler.ShowMessage;
        }
    }
}