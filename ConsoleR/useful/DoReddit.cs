using System;
using System.Linq;
using RedditSharp;
using RedditSharp.Things;

namespace ConsoleR.useful
{
    class DoReddit
    {
        private string _sub;
        private int page = 0;

        public void GetSub(Reddit reddit, string sub, bool all = true)
        {
            this._sub = sub;
            if (all)
            {
                var subreddit = reddit.RSlashAll;
                GetFirstPosts(subreddit);
            }
            else
            {
                _sub = _sub.Replace("r/", "");
                var subreddit = reddit.GetSubreddit("r/" + _sub);
                try
                {
                    GetFirstPosts(subreddit);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void GetFirstPosts(Subreddit subreddit)
        {
            foreach (var post in subreddit.Hot.Take(5))
            {
                Console.WriteLine(post.Title + "\n");
            }
            page++;
            Console.Write("Command: ");
            string command = Console.ReadLine();
        }
    }
}
