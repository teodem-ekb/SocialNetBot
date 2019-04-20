using System;

namespace SocialNetBot.Application.Services
{
    public interface IBrowserView
    {
        void Navigate(Uri uri);
    }
}