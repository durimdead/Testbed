using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Interfaces;
using Testbed.Common.Services.Animals;
using Testbed.Common.Services.Interfaces;

namespace Testbed.Console
{
    /// <summary>
    /// The name of this class sucks, but I needed something like this for the application
    /// </summary>
    public static class MainEntry
    {
        private static List<string> userOptions = new List<string>();
        public static void Start()
        {
            System.Console.WriteLine("Welcome to the application!");
            PopulateUserOptions();
            bool isExiting = false;
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine();
                System.Console.WriteLine();
                
                ShowOptions();
                bool wasValidInput = true;
                string userInput = System.Console.ReadLine();
                int userChoice = 0;

                System.Console.WriteLine();
                System.Console.WriteLine();

                if (!Int32.TryParse(userInput, out userChoice))
                {
                    wasValidInput = false;
                }
                if (userChoice < 1 || userChoice > userOptions.Count)
                {
                    wasValidInput = false;
                }

                if (wasValidInput)
                {
                    switch (userChoice)
                    {
                        case 1:
                            PlayWithAnimals();
                            break;
                        case 2:
                            isExiting = true;
                            break;
                        default:
                            isExiting = true;
                            break;
                    }
                }
            } while (!isExiting);
        }

        private static void ShowOptions()
        {
            System.Console.WriteLine("What would you like to do?: ");
            int currentOptionNumber = 1;
            foreach (string currentOption in userOptions)
            {
                System.Console.WriteLine(currentOptionNumber.ToString() + ") " + currentOption);
                currentOptionNumber++;
            }
        }

        private static void PopulateUserOptions()
        {
            userOptions.Add("Work with the animals");
            userOptions.Add("Exit");
        }

        private static void PlayWithAnimals()
        {
            // Create a random set of animals and then interact with them
            IAnimalFunctionality animalService = new AnimalFunctionalityService();
            var randomAnimals = animalService.CreateRandomSetOfAnimals();
            foreach (IAnimal currentAnimal in randomAnimals)
            {
                currentAnimal.Interact();
            }
        }
    }
}
