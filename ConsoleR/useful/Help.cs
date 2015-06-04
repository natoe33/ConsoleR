using System;

namespace ConsoleR.useful
{
    class Help
    {
        public static void GetHelp()
        {
            Console.Clear();
            Console.WriteLine("Welcome to ConsoleR Help:\nPress any key to go back\n\n");

            Console.WriteLine("General Commands:");
            Console.WriteLine("\tr          - Enter a new subreddit to browse");
            Console.WriteLine("\tb          - Boss mode (display contents of C:\\Windows");
            Console.WriteLine("\tq          - Exit");
            Console.WriteLine("While viewing stories:");
            Console.WriteLine("\tEnter      - Get next 5 posts");
            Console.WriteLine("\tp          - Go back 5 posts");
            Console.WriteLine("\t<number>   - Shows the URL <or self-text for self posts");
            Console.WriteLine("\tc <number> - Shows the post comments");
            Console.WriteLine("\to <number> - Open the story in a browser window");
            Console.WriteLine("While viewing comments:");
            Console.WriteLine("\tEnter      - Get the next 5 comments");
            Console.WriteLine("\ts          - Switch back to stories");
            Console.Write(">");
            string command = Console.ReadLine();
            if(command == "b")
                boss.BossMode();
        }
    }
}
