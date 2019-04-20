using System.Collections.Generic;
using FluentAssertions;
using TwitterClient.Exceptions;
using TwitterClient.Options;
using Xunit;

namespace TwitterClient.Test.Options
{
    public class TwitterClientOptionsTest
    {
        [Theory(DisplayName = nameof(ConstructorTwoParametersSuccess))]
        [MemberData(nameof(GetDataForConstructorTwoParametersSuccess))]
        public void ConstructorTwoParametersSuccess(string consumerKey, string consumerSecret)
        {
            var result = new TwitterClientOptions(consumerKey, consumerSecret);
            result.ConsumerKey.Should().Be(consumerKey);
            result.ConsumerSecret.Should().Be(consumerSecret);
            result.OauthToken.Should().BeNullOrEmpty();
            result.OauthTokenSecret.Should().BeNullOrEmpty();
        }

        [Theory(DisplayName = nameof(ConstructorTwoParametersFailed))]
        [MemberData(nameof(GetDataConstructorTwoParametersFailed))]
        public void ConstructorTwoParametersFailed(string consumerKey, string consumerSecret, string errorMessage)
        {
            var ex = Assert.Throws<TwitterClientException>(()
                => new TwitterClientOptions(consumerKey, consumerSecret));
            Assert.Equal(errorMessage, ex.Message);
        }

        [Theory(DisplayName = nameof(SetOauthTokensSuccess))]
        [MemberData(nameof(GetDataForSetOauthTokensSuccess))]
        public void SetOauthTokensSuccess(string oauthToken, string oauthTokenSecret)
        {
            var result = new TwitterClientOptions("consumerKey", "consumerSecret");
            result.SetOauthTokens(oauthToken, oauthTokenSecret);
            result.OauthToken.Should().Be(oauthToken);
            result.OauthTokenSecret.Should().Be(oauthTokenSecret);
        }

        [Theory(DisplayName = nameof(SetOauthTokensFailed))]
        [MemberData(nameof(GetDataSetOauthTokensFailed))]
        public void SetOauthTokensFailed(string oauthToken, string oauthTokenSecret, string errorMessage)
        {
            var result = new TwitterClientOptions("consumerKey", "consumerSecret");
            var ex = Assert.Throws<TwitterClientException>(()
                => result.SetOauthTokens(oauthToken, oauthTokenSecret));
            Assert.Equal(errorMessage, ex.Message);

        }

        public static IEnumerable<object[]> GetDataForConstructorTwoParametersSuccess()
        {
            yield return new object[]
            {
                "qwertyuiopasdfghjkl",
                "zxvcbfgdfgdfdhrtyuytjghghjgiuyuiy"

            };

            yield return new object[]
            {
                "consumerKey",
                "consumerSecret"

            };
        }

        public static IEnumerable<object[]> GetDataConstructorTwoParametersFailed()
        {
            yield return new object[]
            {
                "qwertyuiopasdfghjkl",
                " ",
                "Incorrect value: consumerSecret"
            };

            yield return new object[]
            {
                " ",
                "zxvcbfgdfgdfdhrtyuytjghghjgiuyuiy",
                "Incorrect value: consumerKey"

            };
            yield return new object[]
            {
                "qwertyuiopasdfghjkl",
                string.Empty,
                "Incorrect value: consumerSecret"

            };
            yield return new object[]
            {
                string.Empty,
                "zxvcbfgdfgdfdhrtyuytjghghjgiuyuiy",
                "Incorrect value: consumerKey"

            };
            yield return new object[]
            {
                "qwertyuiopasdfghjkl",
                null,
                "Incorrect value: consumerSecret"

            };
            yield return new object[]
            {
                null,
                "zxvcbfgdfgdfdhrtyuytjghghjgiuyuiy",
                "Incorrect value: consumerKey"

            };
        }

        public static IEnumerable<object[]> GetDataForSetOauthTokensSuccess()
        {
            yield return new object[]
            {
                "qwertyuiopasdfghjkl",
                "zxvcbfgdfgdfdhrtyuytjghghjgiuyuiy"

            };

            yield return new object[]
            {
                "consumerKey",
                "consumerSecret"

            };
        }

        public static IEnumerable<object[]> GetDataSetOauthTokensFailed()
        {
            yield return new object[]
            {
                "qwertyuiopasdfghjkl",
                " ",
                "Incorrect value: oauthTokenSecret"
            };

            yield return new object[]
            {
                " ",
                "zxvcbfgdfgdfdhrtyuytjghghjgiuyuiy",
                "Incorrect value: oauthToken"

            };
            yield return new object[]
            {
                "qwertyuiopasdfghjkl",
                string.Empty,
                "Incorrect value: oauthTokenSecret"

            };
            yield return new object[]
            {
                string.Empty,
                "zxvcbfgdfgdfdhrtyuytjghghjgiuyuiy",
                "Incorrect value: oauthToken"

            };
            yield return new object[]
            {
                "qwertyuiopasdfghjkl",
                null,
                "Incorrect value: oauthTokenSecret"

            };
            yield return new object[]
            {
                null,
                "zxvcbfgdfgdfdhrtyuytjghghjgiuyuiy",
                "Incorrect value: oauthToken"

            };
        }
    }
}