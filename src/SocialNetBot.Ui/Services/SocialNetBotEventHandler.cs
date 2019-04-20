using System;

namespace SocialNetBot.Ui.Services
{
    public class SocialNetBotEventHandler : ISocialNetBotEventHandler
    {
        //private readonly ITwitterClientEventHandler TwitterClientEventHandler;

        //public SocialNetBotEventHandler(ITwitterClientEventHandler twitterClientEventHandler)
        //{
        //    TwitterClientEventHandler = twitterClientEventHandler ?? throw new ArgumentNullException(nameof(twitterClientEventHandler));
        //    Subscribe();
        //}

        //private void Subscribe()
        //{
        //    TwitterClientEventHandler.OnReadMessage += Read;
        //    TwitterClientEventHandler.OnWriteMessage += Write;
        //}

        //public string Read()
        //{
        //    return Console.ReadLine();
        //}

        //public void Write(string message)
        //{
        //    Console.WriteLine(message);
        //}
        public string Read()
        {
            throw new NotImplementedException();
        }

        public void Write(string message)
        {
            throw new NotImplementedException();
        }
    }
}