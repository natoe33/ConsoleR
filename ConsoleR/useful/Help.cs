using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleR.useful
{
    class Help
    {
        public void GetHelp()
        {
            Console.Clear();
            Console.WriteLine("Welcome to ConsoleR\n\n");
            Console.WriteLine("Commands:");
            Console.WriteLine("\tEnter - Get next 5 posts");
            Console.WriteLine("\tb or back - Go back 5 posts");
        }
    }
}
