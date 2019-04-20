using System.Collections.Generic;
using FluentAssertions;
using SocialNetBot.Application.Statistic;
using Xunit;

namespace SocialNetBot.Application.Test.Statistic
{
    public class CharStatisticTest
    {
        [Theory(DisplayName=nameof(GetFrequencyTest))]
        [MemberData(nameof(GetDataForTest))]
        public void GetFrequencyTest(string text, Dictionary<char, double> result)
        {
            var charStatistic = new CharStatistic();

            var frequency = charStatistic.GetFrequency(text);

            Assert.Equal(result.Count, frequency.Count);
            frequency.Should().BeEquivalentTo(result);
        }

        public static IEnumerable<object[]> GetDataForTest()
        {
            yield return new object[]
            {
                "Testing Text 1",
                new Dictionary<char, double>
                {
                    {'T', 0.182},
                    {'e', 0.182},
                    {'g', 0.091},
                    {'i', 0.091},
                    {'n', 0.091},
                    {'s', 0.091},
                    {'t', 0.182},
                    {'x', 0.091}
                }

            };
            yield return new object[]
            {
                "qwerty",
                new Dictionary<char, double>
                {
                    {'e', 0.167},
                    {'q', 0.167},
                    {'r', 0.167},
                    {'t', 0.167},
                    {'w', 0.167},
                    {'y', 0.167}
                }
            };
        }
    }
}