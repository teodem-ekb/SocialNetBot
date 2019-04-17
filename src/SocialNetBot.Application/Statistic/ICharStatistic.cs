using System.Collections.Generic;

namespace SocialNetBot.Application.Statistic
{
    public interface ICharStatistic
    {
        IDictionary<char, double> GetFrequency(string text);
    }
}