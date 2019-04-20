using Microsoft.Extensions.DependencyInjection;
using SocialNetBot.Application.Options;
using SocialNetBot.Application.Services;
using SocialNetBot.Application.Twitter;
using System;
using SocialNetBot.Application.Services.Interfaces;


namespace SocialNetBot.Application.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddSocialNetCollectionClient(this IServiceCollection services, Action<SocialNetClientAppConfig> options)
        {
            return services
                .Configure(options)
                .AddScoped<IBrowserView, BrowserView>()
                .AddScoped<IMessageSeparatorService, MessageSeparatorService>()
                .AddScoped<ISocialNetAuthorization, SocialNetAuthorization>()
                .AddSingleton<ISocialNetClient, TwitterSocialNetClient>();
        }
    }
}