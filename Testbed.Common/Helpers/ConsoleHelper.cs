using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed.Common.Helpers
{
    public static class ConsoleHelper
    {
        /// <summary>
        /// Just adds some blank space on the console for readability
        /// </summary>
        /// <param name="numberOfLines">number of blank lines to print out</param>
        public static void AddConsolePadding(int numberOfLines)
        {
            for (int count = 0; count < numberOfLines; count++)
            {
                Console.WriteLine();
            }
        }

        public static void AddDottedLine(int numberOfCharacters = 40)
        {
            string dottedLine = string.Empty;
            for (int count = 0; count < numberOfCharacters; count++)
            {
                dottedLine += "-";
            }
            Console.WriteLine(dottedLine);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        public static void OutputError(string errorMessage)
        {
            ConsoleHelper.AddConsolePadding(1);
            ConsoleHelper.AddDottedLine();
            System.Console.WriteLine("-------------------- ERROR -------------------");
            ConsoleHelper.AddDottedLine();
            System.Console.WriteLine(errorMessage);
            ConsoleHelper.AddDottedLine();
            ConsoleHelper.AddConsolePadding(1);
        }
    }
}
