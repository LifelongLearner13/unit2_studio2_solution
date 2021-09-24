using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace studio2
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFile;

            string str = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin.Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat.Donec sit amet suscipit metus, non lobortis massa.Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.";

            Console.WriteLine("----- Count Characters Program -----");
            Console.WriteLine("Choose one of the following options: ");
            Console.WriteLine("1. Display counts from default string");
            Console.WriteLine("2. Display counts from user entered string");
            Console.WriteLine("3. Display counts from file");

            /* Collect user's choice of option */
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                    /* Count characters in default string */
                    CountChars(str);
                    break;

                case "2":
                    /* Ask the user for a string to count */
                    Console.WriteLine("Enter string to count characters: ");
                    userInput = Console.ReadLine();
                    CountChars(userInput);
                    break;

                case "3":
                    /* Take string to count from file */
                    /* Windows users may need to change path */
                    textFile = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "../../../text_to_count.txt"));
                    CountChars(textFile);
                    break;

                default:
                    Console.WriteLine("Invalid option, terminating!");
                    break;
            }
        }

        public static void CountChars(string str)
        {
            /* Convert the string to an array of lower case chars, to 
             * allow for case-insentative comparisons */
            char[] charArr = str.ToLower().ToCharArray();

            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            foreach (char c in charArr)
            {
                /* Applies the knowledge that chars are represented by sequential character codes,
                 * see: https://en.wikipedia.org/wiki/List_of_Unicode_characters#Basic_Latin */
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    /* Ternary operatory (?:) is used to either incriment a value if it already exists in
                     * the dictionary or initialize it to 1
                     * see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator*/
                    charCounts[c] = charCounts.ContainsKey(c) ? charCounts[c] + 1 : 1;
                }
            }

            /* The keys in the dictionary are converted to a list in order to sort them in alphebetic order */
            List<char> keys = charCounts.Keys.ToList();
            keys.Sort();

            foreach (char key in keys)
            {
                /* Uses string interpolation to print the results to the console 
                 * see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated */
                Console.WriteLine($"{key}: {charCounts[key]}");
            }
        }
    }
}
