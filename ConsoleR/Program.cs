using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ConsoleR.main;
using RedditSharp;

namespace ConsoleR
{
	class Program
	{
		public static void Main(string[] args)
		{
            var program = new Program(args);
            program.Run();
		}

        public Program(string [] args)
        {

        }

        public void Run()
        {
            var reddit = new Reddit();
            var main = new Main(reddit);
        }
	}
}