using System;

namespace SocialNetBot.Application.Services.Interfaces
{
    public interface ISocialNetAuthorization
    {
        string ExecuteAuthorize(Uri uri, string message);
    }
}