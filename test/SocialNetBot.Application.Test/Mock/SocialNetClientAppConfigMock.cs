using Bogus;
using SocialNetBot.Application.Options;

namespace SocialNetBot.Application.Test.Mock
{
    public static class SocialNetClientAppConfigMock
    {
        public static SocialNetClientAppConfig Get(int mockSeed)
        {
            return new Faker<SocialNetClientAppConfig>()
                 .UseSeed(mockSeed)
                 .RuleFor(s => s.OpenKey, f => f.Locale)
                 .RuleFor(x => x.SecretKey, f => f.Locale);
        }
    }
}