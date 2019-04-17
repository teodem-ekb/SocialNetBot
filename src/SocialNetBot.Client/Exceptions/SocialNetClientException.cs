using System;

namespace SocialNetBot.Client.Exceptions
{
    public class SocialNetClientException : Exception
    {
        public SocialNetClientException()
        {
        }

        public SocialNetClientException(string message)
            : base(message)
        {
        }
    }
}