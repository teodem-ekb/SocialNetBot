using System;
using Microsoft.Extensions.DependencyInjection;
using SocialNetBot.Application;
using SocialNetBot.Ui.Infrastructure;
using SocialNetBot.Ui.Services;

namespace SocialNetBot.Ui
{
    public class SocialNetBotBuilder
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IServiceProvider _serviceProvider;

        public SocialNetBotBuilder()
        {
            _serviceCollection = new ServiceCollection();
            var startup = new Startup(AppConfiguration.GetConfiguration());
            _serviceProvider = startup.ConfigureServices(_serviceCollection);
        }

        public IBotService Build()
        {
            _serviceProvider.GetRequiredService<ISocialNetBotEventHandler>()
                .Subscribe();
            return _serviceProvider.GetRequiredService<IBotService>();
        }

        public void RunBot(IBotService botService)
        {
            botService.Run();
        }
    }
}