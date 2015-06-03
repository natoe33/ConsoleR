using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using RedditSharp;

namespace ConsoleR
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Console Reddit.\n");
			GetPosts();
		}

		static void GetPosts()
		{
			var reddit = new Reddit();
			var subreddit = reddit.GetSubreddit(GetSub());
			var posts = subreddit.GetHot();
			int postIndex = 1;
			int postsViewed = 0;
			
			//int listIndex = 0;


			while (true)
			{
				Console.Clear();
				Console.WriteLine("You are now viewing {0}\n", subreddit);
				string[] postUrls = new string[50];
				string[] comments = new string[50];
				foreach (var post in posts.Skip(postsViewed).Take(5))
				{
					Console.WriteLine("{0, 5}\t{1}\n", postIndex, post.Title);
					Console.WriteLine("{0, 10} {1} \t{2} {3}\n", "By", post.AuthorName, "comments: ", post.CommentCount);
					postUrls[postIndex] = post.Url.ToString();
					comments[postIndex] = post.Permalink.ToString();
					postIndex++;
					postsViewed++;
				}

				string[] input = GetUserInput();
				if (input[0] == "" || input[0] == "next" || input[0] == "quit" || input[0] == "help" ||
					input[0] == "subreddit" || input[0] == "back")
				{
					if (input[0] == "" || input[0] == "next")
					{
						continue;
					}
					else if (input[0] == "help")
					{
						postsViewed -= 5;
						postIndex -= 5;
						PrintHelp();
						Console.ReadLine();
					}
					else if (input[0] == "quit")
					{
						Environment.Exit(0);
					}
					else if (input[0] == "subreddit")
					{
						Console.Clear();
						GetPosts();
					}
					else if (input[0] == "back")
					{
						if (postsViewed < 10 && postIndex < 10) // If less than 2 pages(5 posts per page) have been viewed
						{
							Console.Clear();
							Console.WriteLine("You can't go back any further.\n");
							Console.WriteLine("Press enter to continue.\n");
							Console.ReadLine();
							postIndex -= 5; // Make it return to the first 5 posts
							postsViewed -= 5;
						}
						else
						{
							postsViewed -= 10; // Go back a page(5 posts per page)
							postIndex -= 10;
						}
					}
				}
				else if (input[1] == "link" || input[1] == "comments")
				{
					if (input[1] == "link")
					{
						int postNum = Convert.ToInt16(input[0]);
						Process.Start(postUrls[postNum]);
						postsViewed -= 5; // keeps the console on the same 5 posts
						postIndex -= 5;

					}
					else if (input[1] == "comments")
					{
						int postNum = Convert.ToInt16(input[0]);

						WebRequest wrURL;
						wrURL = WebRequest.Create("http://www.reddit.com" + comments[postNum]);

						Stream objStream;
						objStream = wrURL.GetResponse().GetResponseStream();

						StreamReader objReader = new StreamReader(objStream);

						string sLine = "";
						int i = 0;

						while (sLine != null)
						{
							i++;
							sLine = objReader.ReadLine();
							if (sLine != null)
								Console.WriteLine("{0}:{1}", i, sLine);
						}
						Console.ReadLine();

						postsViewed -= 5;
						postIndex -= 5;
					}
				}
				else
				{
					postsViewed -= 5;
					postIndex -= 5;
					Console.WriteLine("That is not a valid input. Type 'help' for help.");
					Console.WriteLine("Press enter to retry.");
					Console.ReadLine();
				}
			}
		}

		private static string GetSub()
		{
			while (true)
			{
				Console.WriteLine("Which subreddit would you like to view?\n");
				string sub = Console.ReadLine();
				Console.Clear();
				Console.WriteLine("Fetching {0} ...", sub);
				if (IsValidSub(sub) == true)
				{
					Console.Clear();
					return sub;
				}
				else
				{
					Console.Clear();
					Console.WriteLine("That is not a valid subreddit.");
					Console.WriteLine("Please enter a valid subreddit.");
					Console.WriteLine("Hint: Don't enter r/ or /r/ before the name.\n");
					Console.ReadLine();
					Console.Clear();
				}
			}
		}

		private static bool IsValidSub(string sub)
		{
			try
			{
				HttpWebRequest request = WebRequest.Create("Http://www.reddit.com/r/" + sub) as HttpWebRequest;
				request.Method = "HEAD";
				HttpWebResponse response = request.GetResponse() as HttpWebResponse;
				return (response.StatusCode == HttpStatusCode.OK);
			}
			catch
			{
				return false;
			}
		}

		private static void PrintHelp()
		{
			Console.Clear();
			Console.WriteLine("ConsoleR help\n");
			Console.WriteLine("Commands: \n");
			Console.WriteLine();
			Console.WriteLine("\talert\t\t\tdisplay the contents of C:\\Windows\n");
			Console.WriteLine("\tquit\t\t\texit the app\n");
			Console.WriteLine("\tback\t\t\treturn to previous posts\n");
			Console.WriteLine("\t(number) comments\tshow the comments for the post number\n");
			Console.WriteLine("\t(number) link\t\topen a browser window to the link for the post\n");
			Console.WriteLine("\tsubreddit\t\tswitch to a new subreddit\n");
		}
		
		private static string[] GetUserInput()
		{
			Console.WriteLine("Enter a command. (Type 'help' for help): ");
			string[] input = Console.ReadLine().Split(' ');
			int num1;
			bool isInt = int.TryParse(input[0], out num1);
			
			return input;
		}

		private static string GetNext()
		{
			Console.WriteLine();
			Console.Write("Enter a command (Type 'help' for help) > ");
			string doNext = Console.ReadLine();
			return doNext;
		}
	}
}