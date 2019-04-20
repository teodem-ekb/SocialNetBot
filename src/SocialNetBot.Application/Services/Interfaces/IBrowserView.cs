using System;

namespace SocialNetBot.Application.Services.Interfaces
{
    public interface IBrowserView
    {
        void Navigate(Uri uri);
    }
}