using System;
using Microsoft.Extensions.DependencyInjection;
using SocialNetBot.Client.Options;
using SocialNetBot.Client.Twitter;

namespace SocialNetBot.Client.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddSocialNetCollectionClient(this IServiceCollection services, Action<SocialNetClientAppConfig> options)
        {
            return services
                .Configure(options)
                .AddSingleton<ITwitterClientEventHandler, TwitterClientEventHandler>()
                .AddSingleton<ISocialNetClient, TwitterSocialNetClient>();
        }
    }
}