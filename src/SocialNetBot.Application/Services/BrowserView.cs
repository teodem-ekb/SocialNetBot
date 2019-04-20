using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SocialNetBot.Application.Services
{
    public class BrowserView : IBrowserView
    {
        public void Navigate(Uri uri)
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
        }
    }
}