using System;

namespace SocialNetBot.Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Имя пользователя, чьи посты хотите прочитать.");
                var user = Console.ReadLine();
                if (user == " ")
                {
                    break;
                }

                if (!string.IsNullOrEmpty(user))
                {
                    
                }
            }
            Console.Write("Выход!");
            Console.ReadKey();
        }
    }
}
