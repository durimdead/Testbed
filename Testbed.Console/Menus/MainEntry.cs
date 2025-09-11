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
using Testbed.Common.Models;
using Testbed.Common.Helpers;

namespace Testbed.Console.Menus
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
                ConsoleHelper.AddConsolePadding(3);
                ShowOptions();
                bool wasValidInput = true;
                string? userInput = System.Console.ReadLine();
                int userChoice = 0;
                ConsoleHelper.AddConsolePadding(2);

                // ensure the input was an integer and a valid choice
                if (!(int.TryParse(userInput, out userChoice) && userChoice >= 1 && userChoice <= _mainMenuOptions.Count))
                {
                    wasValidInput = false;
                    System.Console.WriteLine(userInput + " is not a valid choice. Please Choose again!");
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
            foreach (MainMenuOption currentOption in _mainMenuOptions)
            {
                System.Console.WriteLine(currentOption.MainMenuOptionId.ToString() + ") " + currentOption.MainMenuOptionDescription);
            }
        }

        /// <summary>
        /// Does an initial population of MainMenuOptions based on the class functionalities for each option.
        /// </summary>
        private static void PopulateMainMenuOptions()
        {
            // grab all subClasses of MainMenuOption
            var mainMenuOptions = CommonHelper.GetAllSubClasses(typeof(MainMenuOption), "Testbed.Console");
            int counter = 1;

            // populates an option for each child of MainMenuOption class
            foreach (var currentMenuOption in mainMenuOptions)
            {
                MainMenuOption mainMenuOption = (MainMenuOption)Activator.CreateInstance(currentMenuOption, counter, null)!;
                _mainMenuOptions.Add(mainMenuOption);
                counter++;
            }

            // adds a final option for exiting the application
            _mainMenuOptions.Add(new MainMenuOption(counter, "Exit Application", "Exit"));
        }
    }
}
