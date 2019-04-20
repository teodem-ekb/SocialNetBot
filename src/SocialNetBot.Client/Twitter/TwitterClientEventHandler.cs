using SocialNetBot.Client.Delegates;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SocialNetBot.Client.Twitter
{
    public class TwitterClientEventHandler : ITwitterClientEventHandler
    {
        public event ReadMessage OnReadMessage = () => string.Empty;
        public event WriteMessage OnWriteMessage = message => { };

        public string Verify(Uri uri)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c start {uri.ToString()}"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", uri.ToString());
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", uri.ToString());
            }
            return OnReadMessage();
        }

        public void ShowMessage(string message)
        {
            OnWriteMessage(message);
        }
    }
}