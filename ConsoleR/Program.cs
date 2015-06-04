using System;
using ConsoleR.useful;
using RedditSharp;

namespace ConsoleR
{
	class Program
	{
		public static void Main(string[] args)
		{
            var reddit = new Reddit();
            Console.WriteLine("Welcome to ConsoleR.\nPress \"h\" for help.\n");
            var doReddit = new DoReddit();
            doReddit.Begin(reddit);
		}
	}
}