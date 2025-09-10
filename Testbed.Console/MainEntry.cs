using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Animals;
using Testbed.Common.Models.Interfaces;
using Testbed.Common.Services.Animals;
using Testbed.Common.Services.Interfaces;
using Testbed.Common.Services;
using Testbed.Common.Models;

namespace Testbed.Console
{
    /// <summary>
    /// The name of this class sucks, but I needed something like this for the application
    /// </summary>
    public static class MainEntry
    {
        private static List<UserOption> _userOptions = new List<UserOption>();

        /// <summary>
        /// The main entry point of the application where the user decides on what they are going to do.
        /// </summary>
        public static void Start()
        {
            System.Console.WriteLine("Welcome to the application!");
            PopulateUserOptions();
            bool isExiting = false;
            do
            {
                // show the options and get the user's choice
                AddConsolePadding(3);
                ShowOptions();
                bool wasValidInput = true;
                string? userInput = System.Console.ReadLine();
                int userChoice = 0;
                AddConsolePadding(2);

                // ensure the input was an integer and a valid choice
                if (!(Int32.TryParse(userInput, out userChoice) && (userChoice >= 1 && userChoice <= _userOptions.Count)))
                {
                    wasValidInput = false;
                }

                // input was valid, so perform the action requested
                if (wasValidInput)
                {
                    // if the last option was chosen, the user is exiting the application
                    if (userChoice == _userOptions.Count)
                    {
                        isExiting = true;
                    }
                    _userOptions.Single(x => x.UserOptionId == userChoice).Start();
                }
            } while (!isExiting);
        }

        /// <summary>
        /// Shows all options the user can choose along with their associated numbers
        /// </summary>
        private static void ShowOptions()
        {
            System.Console.WriteLine("What would you like to do?: ");
            int currentOptionNumber = 1;
            foreach (UserOption currentOption in _userOptions)
            {
                System.Console.WriteLine(currentOption.UserOptionId.ToString() + ") " + currentOption.UserOptionDescription);
                currentOptionNumber++;
            }
        }

        /// <summary>
        /// Does an initial population of userOptions based on the class functionalities for each option.
        /// </summary>
        private static void PopulateUserOptions()
        {
            // grab all subClasses of UserOption
            var userOptions = CommonService.GetAllSubClasses(typeof(UserOption), "Testbed.Common");
            int counter = 1;

            // populates an option for each child of UserOption class
            foreach (var currentUserOption in userOptions)
            {
                UserOption userOption = (UserOption)Activator.CreateInstance(currentUserOption, counter)!;
                _userOptions.Add(userOption);
                counter++;
            }

            // adds a final option for exiting the application
            _userOptions.Add(new UserOption(counter, "Exit Application", "Exit"));
        }

        /// <summary>
        /// Just adds some blank space on the console for readability
        /// </summary>
        /// <param name="numberOfLines">number of blank lines to print out</param>
        private static void AddConsolePadding(int numberOfLines)
        {
            for (int count = 0; count < numberOfLines; count++)
            {
                System.Console.WriteLine();
            }
        }
    }
}
