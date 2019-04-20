using System.Collections.Generic;
using SocialNetBot.Application.Services.Interfaces;

namespace SocialNetBot.Application.Services
{
    public class MessageSeparatorService : IMessageSeparatorService
    {
        public IEnumerable<string> Separate(string message, int length)
        {
            var textLength = message.Length;
            for (var i = 0; i < textLength; i += length)
            {
                if (i + length >= textLength)
                {
                    length = textLength - i;
                }
                yield return message.Substring(i, length);
            }
        }
    }
}