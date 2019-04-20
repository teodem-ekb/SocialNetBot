using Moq;
using SocialNetBot.Application.Services;
using SocialNetBot.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace SocialNetBot.Application.Test.Services
{
    public class SocialNetAuthorizationTest
    {
        [Theory(DisplayName = nameof(ExecuteAuthorizeTest))]
        [InlineData("123456789")]
        public void ExecuteAuthorizeTest(string response)
        {
            var browserViewMock = new Mock<IBrowserView>();
            var socialNetBotEventServiceMock = new Mock<ISocialNetBotEventService>();

            var socialNetAuthorization =
                new SocialNetAuthorization(browserViewMock.Object, socialNetBotEventServiceMock.Object);

            browserViewMock.Setup(x => x.Navigate(It.IsAny<Uri>())).Verifiable();
            socialNetBotEventServiceMock.Setup(x => x.Write(It.IsAny<string>())).Verifiable();
            socialNetBotEventServiceMock.Setup(x => x.Read()).Returns(response);
            var result = socialNetAuthorization.ExecuteAuthorize(new Uri("http://localhost"), "message");

            browserViewMock.Verify();
            Assert.Equal(response, result);

        }

        [Theory(DisplayName = nameof(ConstructorSuccess))]
        [MemberData(nameof(GetDataConstructorSuccess))]
        public void ConstructorSuccess(IBrowserView browserView, ISocialNetBotEventService socialNetBotEventService)
        {
            var socialNetAuthorization =
                new SocialNetAuthorization(browserView, socialNetBotEventService);
            Assert.NotNull(socialNetAuthorization);

        }

        [Theory(DisplayName = nameof(ConstructorFailed))]
        [MemberData(nameof(GetDataConstructorFailed))]
        public void ConstructorFailed(
            IBrowserView browserView,
            ISocialNetBotEventService socialNetBotEventService)
        {
            Assert.Throws<ArgumentNullException>(()
                => new SocialNetAuthorization(browserView, socialNetBotEventService));
        }

        public static IEnumerable<object[]> GetDataConstructorSuccess()
        {
            yield return new object[]
            {
                new Mock<IBrowserView>().Object,
                new Mock<ISocialNetBotEventService>().Object

            };
        }

        public static IEnumerable<object[]> GetDataConstructorFailed()
        {
            yield return new object[]
            {
                new Mock<IBrowserView>().Object,
                null
            };

            yield return new object[]
            {
                null,
                new Mock<ISocialNetBotEventService>().Object
            };
        }

    }
}