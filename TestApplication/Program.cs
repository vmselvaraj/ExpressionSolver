using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string t = "-x-y=10";
            MatchCollection matches = Regex.Matches(t, @"([-]?([0-9]*\.[0-9]+|[0-9]+)|[-]|[a-zA-Z]+|=)");
            for(int i = 0; i < matches.Count;i++)
            {
                Console.WriteLine(matches[i].Value);
            }

            Console.ReadLine();
        }
    }
}
