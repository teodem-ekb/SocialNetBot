using System;

namespace SocialNetBot.Application.Exceptions
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