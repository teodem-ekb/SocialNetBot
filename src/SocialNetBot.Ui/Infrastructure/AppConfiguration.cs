using System.IO;
using Microsoft.Extensions.Configuration;

namespace SocialNetBot.Ui.Infrastructure
{
    public static class AppConfiguration
    {
        private static IConfiguration _configuration;

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            return _configuration;
        }
    }
}