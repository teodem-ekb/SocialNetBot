using Microsoft.Extensions.DependencyInjection;
using SocialNetBot.Application.Factories;
using SocialNetBot.Application.Options;
using SocialNetBot.Application.Services;
using SocialNetBot.Application.Services.Interfaces;
using SocialNetBot.Application.Statistic;
using System;


namespace SocialNetBot.Application.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddSocialNetCollectionClient(this IServiceCollection services, Action<SocialNetClientAppConfig> options)
        {
            return services
                .Configure(options)
                .AddScoped<ISocialNetBotEventService, SocialNetBotEventService>()
                .AddScoped<IBrowserView, BrowserView>()
                .AddScoped<ICharStatistic, CharStatistic>()
                .AddScoped<IMessageSeparatorService, MessageSeparatorService>()
                .AddScoped<ISocialNetAuthorization, SocialNetAuthorization>()
                .AddSingleton<ISocialNetClientFactory, SocialNetClientFactory>();
        }
    }
}