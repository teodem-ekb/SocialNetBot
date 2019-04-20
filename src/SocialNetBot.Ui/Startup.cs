using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SocialNetBot.Application;
using SocialNetBot.Application.Extensions;
using SocialNetBot.Application.Statistic;
using SocialNetBot.Application.Twitter;
using SocialNetBot.Ui.Services;
using System;

namespace SocialNetBot.Ui
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging(x => x.AddConsole());

            services.AddSocialNetCollectionClient(o =>
            {
                Configuration.GetSection("ApplicationConfig").Bind(o);
            });

            services.AddSingleton<ISocialNetBotEventHandler, SocialNetBotEventHandler>();
            services.AddTransient<IBotService, BotService>();
            return services.BuildServiceProvider();
        }

    }
}