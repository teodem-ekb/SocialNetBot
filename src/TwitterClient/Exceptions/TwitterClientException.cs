using System;

namespace TwitterClient.Exceptions
{
    public class TwitterClientException : Exception
    {
        public TwitterClientException()
        {
        }

        public TwitterClientException(string message)
            : base(message)
        {
        }

        public TwitterClientException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}