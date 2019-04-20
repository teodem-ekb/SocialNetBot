using System;

namespace SocialNetBot.Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            new SocialNetBotBuilder()
                .Build()
                .Run();

            Console.ReadKey();
        }
    }
}
