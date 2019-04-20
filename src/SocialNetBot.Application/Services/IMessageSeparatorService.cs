using System.Collections.Generic;

namespace SocialNetBot.Application.Services
{
    public interface IMessageSeparatorService
    {
        IEnumerable<string> Separate(string message, int length);
    }
}