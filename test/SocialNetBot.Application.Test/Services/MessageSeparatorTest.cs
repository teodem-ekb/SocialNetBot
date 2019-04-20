using FluentAssertions;
using SocialNetBot.Application.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SocialNetBot.Application.Test.Services
{
    public class MessageSeparatorTest
    {
        [Theory(DisplayName = nameof(SeparateTest))]
        [MemberData(nameof(GetDataForTest))]
        public void SeparateTest(string text, int limit, IEnumerable<string> result)
        {
            var messageSeparator = new MessageSeparatorService();
            var texts = messageSeparator.Separate(text, limit);
            Assert.Equal(result.Count(), texts.Count());
            texts.Should().BeEquivalentTo(result);
        }

        public static IEnumerable<object[]> GetDataForTest()
        {
            yield return new object[]
            {
                "qwertyuiopasdfghjkl",
                5,
                new List<string>
                {
                    {"qwert"},
                    {"yuiop"},
                    {"asdfg"},
                    {"hjkl"}
                }

            };

            yield return new object[]
            {
                "testing text",
                13,
                new List<string>
                {
                    {"testing text"}
                }

            };
        }
    }
}