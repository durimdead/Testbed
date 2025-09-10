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
        private static List<MainMenuOption> _mainMenuOptions = new List<MainMenuOption>();

        /// <summary>
        /// The main entry point of the application where the user decides on what they are going to do.
        /// </summary>
        public static void Start()
        {
            System.Console.WriteLine("Welcome to the application!");
            PopulateMainMenuOptions();
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
                if (!(Int32.TryParse(userInput, out userChoice) && (userChoice >= 1 && userChoice <= _mainMenuOptions.Count)))
                {
                    wasValidInput = false;
                }

                // input was valid, so perform the action requested
                if (wasValidInput)
                {
                    // if the last option was chosen, the user is exiting the application
                    if (userChoice == _mainMenuOptions.Count)
                    {
                        isExiting = true;
                    }
                    // execute the action for the user choice
                    _mainMenuOptions.Single(x => x.MainMenuOptionId == userChoice).Start();
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
            foreach (MainMenuOption currentOption in _mainMenuOptions)
            {
                System.Console.WriteLine(currentOption.MainMenuOptionId.ToString() + ") " + currentOption.MainMenuOptionDescription);
                currentOptionNumber++;
            }
        }

        /// <summary>
        /// Does an initial population of MainMenuOptions based on the class functionalities for each option.
        /// </summary>
        private static void PopulateMainMenuOptions()
        {
            // grab all subClasses of MainMenuOption
            var mainMenuOptions = CommonService.GetAllSubClasses(typeof(MainMenuOption), "Testbed.Common");
            int counter = 1;

            // populates an option for each child of MainMenuOption class
            foreach (var currentMenuOption in mainMenuOptions)
            {
                MainMenuOption mainMenuOption = (MainMenuOption)Activator.CreateInstance(currentMenuOption, counter)!;
                _mainMenuOptions.Add(mainMenuOption);
                counter++;
            }

            // adds a final option for exiting the application
            _mainMenuOptions.Add(new MainMenuOption(counter, "Exit Application", "Exit"));
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
