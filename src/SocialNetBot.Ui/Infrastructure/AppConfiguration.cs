using System.IO;
using Microsoft.Extensions.Configuration;

namespace SocialNetBot.Ui.Infrastructure
{
    public static class AppConfiguration
    {
        private static IConfiguration Configuration;

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            return Configuration;
        }
    }
}