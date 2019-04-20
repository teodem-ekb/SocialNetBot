using Microsoft.Extensions.Options;
using SocialNetBot.Application.Options;
using SocialNetBot.Application.Services.Interfaces;
using SocialNetBot.Application.Twitter;
using System;

namespace SocialNetBot.Application.Factories
{
    public class SocialNetClientFactory : ISocialNetClientFactory
    {

        private readonly IOptions<SocialNetClientAppConfig> _options;
        private readonly IMessageSeparatorService _messageSeparator;
        private readonly ISocialNetAuthorization _socialNetAuthorization;

        public SocialNetClientFactory(
            IOptions<SocialNetClientAppConfig> options,
            IMessageSeparatorService messageSeparator,
            ISocialNetAuthorization socialNetAuthorization)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _messageSeparator = messageSeparator ?? throw new ArgumentNullException(nameof(messageSeparator));
            _socialNetAuthorization = socialNetAuthorization ?? throw new ArgumentNullException(nameof(socialNetAuthorization));
        }

        public ISocialNetClient GetTwitterSocialNetClient()
        {
            return new TwitterSocialNetClient(_options, _messageSeparator, _socialNetAuthorization);
        }
    }
}