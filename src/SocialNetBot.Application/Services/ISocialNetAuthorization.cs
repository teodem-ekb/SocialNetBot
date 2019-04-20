using System;

namespace SocialNetBot.Application.Services
{
    public interface ISocialNetAuthorization
    {
        string ExecuteAuthorize(Uri uri, string message);
    }
}