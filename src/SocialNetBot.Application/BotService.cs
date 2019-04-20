using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SocialNetBot.Application.Factories;
using SocialNetBot.Application.Services.Interfaces;
using SocialNetBot.Application.Statistic;
using System;

namespace SocialNetBot.Application
{
    public class BotService : IBotService
    {
        private readonly ISocialNetClient _socialNetClient;
        private readonly ICharStatistic _charStatistic;
        private readonly ILogger<BotService> _logger;
        private readonly ISocialNetBotEventService _eventService;
        private const int Count = 5;

        public BotService(
            ISocialNetClientFactory socialNetClientFactory,
            ICharStatistic charStatistic,
            ILogger<BotService> logger,
            ISocialNetBotEventService eventService)
        {
            _socialNetClient = socialNetClientFactory.GetTwitterSocialNetClient()
                               ?? throw new ArgumentNullException(nameof(socialNetClientFactory));
            _charStatistic = charStatistic ?? throw new ArgumentNullException(nameof(charStatistic));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
        }

        public void Run()
        {
            while (true)
            {
                _eventService.Write("Имя пользователя, чьи посты хотите прочитать.");
                var user = _eventService.Read();
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

                    _eventService.Write($"{_socialNetClient.WritePost(JsonConvert.SerializeObject(statistic))}" +
                                        $": {JsonConvert.SerializeObject(statistic)}");
                }
                catch (Exception ex)
                {
                    //_logger.LogError(new EventId(ex.HResult), ex, ex.Message);
                    _logger.LogError(ex.Message);
                }

                _eventService.Write("Выход!");
            }

        }
    }
}