using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace AkatsukiBotSharp
{
    class Bot
    {
        private static VkApi vkApi = new VkApi();
        static void Main(string[] args)
        {
            Console.Title = "Akatsuki VK Bot";
            AuthVk();
            ShatatMadaru();
            Console.ReadKey(true);

        }


        public static void AuthVk()
        {
            Console.WriteLine("Введи API Key группы: ");
            var apikey = Console.ReadLine();
            ApiAuthParams api = new ApiAuthParams()
            {
                AccessToken = apikey,
                Settings = Settings.All
            };

            try
            {
                vkApi.Authorize(api);
                if (vkApi.IsAuthorized)
                    Console.WriteLine("Получил ключ!");
                else
                    Console.WriteLine("Нет ключа блять");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            };
            
        }

        public static void ShatatMadaru()
        {
            var spamthismessage = new List<string> { "АААААА МАДАРА !!! "};
            Console.WriteLine("Укажи интревал спама: ");
            var delayforspam = int.Parse(Console.ReadLine());
            Console.WriteLine("Укажи номер чата с мадарой: ");
            var chatIdId = long.Parse(Console.ReadLine());

            while (true)
            {
                vkApi.Messages.Send(new MessagesSendParams()
                {
                    ChatId = chatIdId,
                    Message = spamthismessage.ToString(),
                    RandomId = new Random().Next()
                });

                Thread.Sleep(delayforspam);
            }
        }
    }
}
