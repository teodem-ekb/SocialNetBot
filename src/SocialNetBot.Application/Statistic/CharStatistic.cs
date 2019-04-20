using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetBot.Application.Statistic
{
    public class CharStatistic : ICharStatistic
    {
        public IDictionary<char, double> GetFrequency(string text)
        {
            var chars = text.Where(char.IsLetter).ToList();

            return chars.GroupBy(ch => ch).Select(ch => new
                {
                    ch.Key,
                    value = Frequency(ch.Count(), chars.Count)
                }).OrderBy(ch => ch.Key)
                .ToDictionary(ch => ch.Key, ch => ch.value);
        }

        private static double Frequency(int countChar, double countAllChar)
            => Math.Round((countChar / countAllChar), 3);
    }
}