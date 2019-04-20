using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SocialNetBot.Application.Statistic;
using System;

namespace SocialNetBot.Application
{
    public class BotService
    {
        private readonly ISocialNetClient _socialNetClient;
        private readonly ICharStatistic _charStatistic;
        private readonly ILogger<BotService> _logger;
        private const int Count = 5;

        public BotService(ISocialNetClient socialNetClient, ICharStatistic charStatistic, ILogger<BotService> logger)
        {
            _socialNetClient = socialNetClient ?? throw new ArgumentNullException(nameof(socialNetClient));
            _charStatistic = charStatistic ?? throw new ArgumentNullException(nameof(charStatistic));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //public event ReadMessage OnReadMessage = () => string.Empty;
        //public event WriteMessage OnWriteMessage = message => { };

        public void Run()
        {
            while (true)
            {
                //OnWriteMessage("Имя пользователя, чьи посты хотите прочитать.");
                Console.WriteLine("Имя пользователя, чьи посты хотите прочитать.");
                var user = Console.ReadLine();
                if (user == " ")
                {
                    break;
                }

                if (string.IsNullOrEmpty(user))
                {
                    continue;
                }

                try
                {
                    var messages = _socialNetClient.ReadUserPosts(user, Count);
                    var statistic = _charStatistic.GetFrequency(string.Concat(messages));
                    _socialNetClient.WritePost(JsonConvert.SerializeObject(statistic));
                }
                catch (Exception ex)
                {
                    //_logger.LogError(new EventId(ex.HResult), ex, ex.Message);
                    _logger.LogError(ex.Message);
                }


            }
            Console.Write("Выход!");
            Console.ReadKey();
        }
    }
}