using System;
using Microsoft.Extensions.DependencyInjection;
using SocialNetBot.Application;
using SocialNetBot.Ui.Infrastructure;
using SocialNetBot.Ui.Services;

namespace SocialNetBot.Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var startup = new Startup(AppConfiguration.GetConfiguration());
            var serviceProvider = startup.ConfigureServices(serviceCollection);

            serviceProvider.GetRequiredService<ISocialNetBotEventHandler>();
            serviceProvider.GetRequiredService<BotService>().Run();

            Console.Write("Выход!");
            Console.ReadKey();
        }
    }
}
