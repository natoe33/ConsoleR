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
		    Console.Title = @"ConsoleR";
            var doReddit = new DoReddit();
            doReddit.Begin(reddit);
		}
	}
}