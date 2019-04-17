using System;
using System.Collections.Generic;
using TwitterClient.Delegates;

namespace TwitterClient.Client
{
    public class TwitterClientBase
    {
        public event Verify OnVerify = uri => string.Empty;
        public event ShowMessage OnShowMessage = message => { };

        protected string OnVerifyMethod(Uri uri)
        {
            return OnVerify(uri);
        }

        protected void OnShowMessageMethod(string message)
        {
            OnShowMessage(message);
        }

        protected IEnumerable<string> SeparateTweet(string text, int limit)
        {
            var textLength = text.Length;
            for (var i = 0; i < textLength; i += limit)
            {
                if (i + limit >= textLength)
                {
                    limit = textLength - i;
                }
                yield return text.Substring(i, limit);
            }
        }
    }
}