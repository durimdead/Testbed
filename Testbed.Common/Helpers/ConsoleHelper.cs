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
    }
}
