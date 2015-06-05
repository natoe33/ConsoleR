using System;
using System.Linq;
using RedditSharp;
using RedditSharp.Things;

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
                //It's late. Figure out where to put the next couple lines in order to do what you want.
                Console.WriteLine("Welcome to ConsoleR.\nPress \"h\" for help.\n");
                Console.Write(">");
                string command = Console.ReadLine();
                Console.Clear();
                if (string.IsNullOrEmpty(command))
                    GetPosts(page++, subreddit);
                else
                {
                    var com = command.ToCharArray();
                    switch (com[0])
                    {
                        case 'h':
                            Help.GetHelp();
                            continue;
                        case 'b':
                            boss.BossMode();
                            continue;
                        case 'r':
                        {
                            subreddit = GetSubreddit(reddit);
                            page = 0;
                            GetPosts(page++, subreddit);
                            continue;
                        }
                        case 'q':
                            Environment.Exit(0);
                            break;
                        case 'c':
                            GetComments(command, subreddit);
                            continue;
                    }
                }
            }
        }

        private void GetComments(string command, Subreddit subreddit)
        {
            Console.Clear();
            int num = int.Parse(command.Replace("c", "").Replace(" ", ""));
            int com = 0;
            Post post = null;
            foreach (var title in subreddit.Hot.Skip(num - 1).Take(1))
            {
                post = title;
            }
            PostComments(com, post);
        }

        private void PostComments(int num, Post post)
        {
            int comm = num;
            bool exit = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Now viewing comments for: " + post.Title + "\n");
                foreach (var comment in post.Comments.Take(5).Skip(comm))
                    Console.WriteLine("{0}\t" + comment.Body + "\n", comm++);
                Console.Write(">");
                string command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                    // ReSharper disable once RedundantJumpStatement
                    continue;
                var com = command.ToCharArray();
                switch (com[0])
                {
                    case 's':
                        exit = true;
                        break;
                    case 'b':
                        boss.BossMode();
                        comm = comm - 5;
                        continue;
                }
                if (exit)
                    break;
            }
        }

        private Subreddit GetSubreddit(Reddit reddit)
        {
            Console.Clear();
            Console.Write("Enter a subreddit. We'll try to find it >");
            var sub = Console.ReadLine();
            if (sub != null)
            {
                sub = sub.Replace("r/", "");
                Subreddit subreddit = reddit.GetSubreddit("r/" + sub) ?? reddit.RSlashAll;
                return subreddit;
            }
            return reddit.RSlashAll;
        }

        private static void GetPosts(int page, Subreddit subreddit)
        {
            Console.Clear();
            int num = (page*5) + 1;
            Console.WriteLine("You are browsing: " + subreddit.Title);
            Console.WriteLine("Press 'h' for help\n");
            foreach (var post in subreddit.Hot.Skip(page*5).Take(5))
                Console.WriteLine("\n {0}\t" + post.Title + "\t" + post.CommentCount + " comments\n", num++);
        }
    }
}
