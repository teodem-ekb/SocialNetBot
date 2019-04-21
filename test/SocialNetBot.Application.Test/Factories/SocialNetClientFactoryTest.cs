using Microsoft.Extensions.Options;
using Moq;
using SocialNetBot.Application.Factories;
using SocialNetBot.Application.Options;
using SocialNetBot.Application.Services.Interfaces;
using SocialNetBot.Application.Test.Mock;
using System;
using System.Collections.Generic;
using Xunit;

namespace SocialNetBot.Application.Test.Factories
{
    public class SocialNetClientFactoryTest
    {
        [Fact(DisplayName = nameof(GetTwitterSocialNetClientTest))]
        public void GetTwitterSocialNetClientTest()
        {
            var optionsMock = new Mock<IOptions<SocialNetClientAppConfig>>();
            optionsMock.SetupGet(x => x.Value)
                .Returns(SocialNetClientAppConfigMock.Get(2));
            var messageSeparatorServiceMock = new Mock<IMessageSeparatorService>();
            var socialNetAuthorizationMock = new Mock<ISocialNetAuthorization>();

            var socialNetClientFactory = new SocialNetClientFactory(
                optionsMock.Object,
                messageSeparatorServiceMock.Object,
                socialNetAuthorizationMock.Object);

            var result = socialNetClientFactory.GetTwitterSocialNetClient();

            Assert.NotNull(result);
        }

        [Theory(DisplayName = nameof(ConstructorSuccess))]
        [MemberData(nameof(GetDataConstructorSuccess))]
        public void ConstructorSuccess(
            IOptions<SocialNetClientAppConfig> options,
            IMessageSeparatorService messageSeparatorService,
            ISocialNetAuthorization socialNetAuthorization)
        {
            var socialNetClientFactory =
                new SocialNetClientFactory(options,
                    messageSeparatorService,
                    socialNetAuthorization);
            Assert.NotNull(socialNetClientFactory);

        }

        [Theory(DisplayName = nameof(ConstructorFailed))]
        [MemberData(nameof(GetDataConstructorFailed))]
        public void ConstructorFailed(
            IOptions<SocialNetClientAppConfig> options,
            IMessageSeparatorService messageSeparatorService,
            ISocialNetAuthorization socialNetAuthorization)
        {
            Assert.Throws<ArgumentNullException>(()
                => new SocialNetClientFactory(options,
                    messageSeparatorService,
                    socialNetAuthorization));
        }

        public static IEnumerable<object[]> GetDataConstructorSuccess()
        {
            yield return new object[]
            {
                GetOptions(),
                new Mock<IMessageSeparatorService>().Object,
                new Mock<ISocialNetAuthorization>().Object

            };
        }



        public static IEnumerable<object[]> GetDataConstructorFailed()
        {
            yield return new object[]
            {
                GetOptions(),
                null,
                new Mock<ISocialNetAuthorization>().Object

            };
            yield return new object[]
            {
               null,
                new Mock<IMessageSeparatorService>().Object,
                new Mock<ISocialNetAuthorization>().Object

            };
            yield return new object[]
            {
                GetOptions(),
                new Mock<IMessageSeparatorService>().Object,
                null

            };
        }

        private static IOptions<SocialNetClientAppConfig> GetOptions()
        {
            var optionsMock = new Mock<IOptions<SocialNetClientAppConfig>>();
            optionsMock.SetupGet(x => x.Value)
                .Returns(SocialNetClientAppConfigMock.Get(2));
            return optionsMock.Object;
        }
    }
}