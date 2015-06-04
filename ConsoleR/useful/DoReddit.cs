using System;
using System.Linq;
using RedditSharp;
using RedditSharp.Things;
using ConsoleR.useful;

namespace ConsoleR.useful
{
    internal class DoReddit
    {
        public void Begin(Reddit reddit)
        {
            var subreddit = reddit.RSlashAll;
            int page = 0;
            while (true)
            {
                Console.Write(">");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "h":
                        Help.GetHelp();
                        continue;
                    case "b":
                        boss.BossMode();
                        continue;
                    case "":
                        GetPosts(page++, subreddit);
                        continue;
                    case "r":
                    {
                        subreddit = GetSubreddit(reddit);
                        continue;
                    }
                }
            }
        }

        private Subreddit GetSubreddit(Reddit reddit)
        {
            Console.Write("Enter a subreddit. We'll try to find it >");
            var sub = Console.ReadLine();
            if (sub != null)
            {
                sub = sub.Replace("r/", "");
                return reddit.GetSubreddit("r/" + sub);
            }
        }

        private static void GetPosts(int page, Subreddit subreddit)
        {
            Console.Clear();
            int num = (page*5) + 1;
            Console.WriteLine("");
            foreach (var post in subreddit.Hot.Skip(page*5).Take(5))
            {
                Console.WriteLine("\n {0}\t" + post.Title + "\t" + post.CommentCount + " comments\n", num++);
            }
        }
    }
}
