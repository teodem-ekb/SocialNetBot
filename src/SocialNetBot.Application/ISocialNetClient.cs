using System.Collections.Generic;

namespace SocialNetBot.Application
{
    public interface ISocialNetClient
    {
        IEnumerable<string> ReadUserPosts(string userName, int count);

        void WritePost(string text);
    }
}