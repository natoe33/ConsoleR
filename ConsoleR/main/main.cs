using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ConsoleR.useful;
using RedditSharp;

namespace ConsoleR.main
{
    class Main
    {
        private Reddit reddit;
        public Main(Reddit reddit)
        {
            this.reddit = reddit;
            Console.WriteLine("Welcome to ConsoleR.\n");
            Console.WriteLine("Enter your login info");
            Console.Write("Username: ");
            string user = Console.ReadLine();
            Console.Write("Password: ");
            ConsoleKeyInfo key;
            string pass = string.Empty;
            do
            {
                key = Console.ReadKey(true);
                //Backspace shouldn't work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            var login = reddit.LogIn(user, pass);
            DoReddit doReddit = new DoReddit();
            Console.Write("Default is r/all\nPress Enter to browse all or enter another subreddit:");
            string sub = Console.ReadLine();
            bool all = sub == String.Empty;
            doReddit.GetSub(reddit, sub, all);
        }
    }
}
