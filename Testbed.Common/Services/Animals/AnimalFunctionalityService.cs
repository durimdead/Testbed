using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Helpers;
using Testbed.Common.Models;
using Testbed.Common.Models.Animals;
using Testbed.Common.Models.Interfaces;
using Testbed.Common.Services.Interfaces;
using Testbed.Common.Services.MethodCallers;

namespace Testbed.Common.Services.Animals
{
    public class AnimalFunctionalityService: MainMenuOption, IAnimalFunctionality, IMenuOptionHolder
    {
        private const int MAX_NUMBER_RANDOM_ANIMALS = 10;
        private const string USER_OPTION_DESCRIPTION = "Play with Animals";
        private List<MenuOption> _menuOptions = new List<MenuOption>();

        public AnimalFunctionalityService(int mainMenuOptionId) : base(mainMenuOptionId, USER_OPTION_DESCRIPTION, string.Empty)
        {
        }
        public AnimalFunctionalityService(MainMenuOption mainMenuOption) : base(mainMenuOption.MainMenuOptionId, mainMenuOption.MainMenuOptionDescription, mainMenuOption.MainMenuOptionName)
        {
        }

        /// <summary>
        /// The entry point for animal interactions.
        /// </summary>
        public override void Start()
        {
            System.Console.WriteLine("Now playing with the animals!");
            System.Console.WriteLine("---------------------------------------------");
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
                if (!(Int32.TryParse(userInput, out userChoice) && (userChoice >= 1 && userChoice <= _menuOptions.Count)))
                {
                    wasValidInput = false;
                }

                // input was valid, so perform the action requested
                if (wasValidInput)
                {
                    // if the last option was chosen, the user is exiting the application
                    if (userChoice == _menuOptions.Count)
                    {
                        isExiting = true;
                    }
                    // execute the action for the user choice
                    _menuOptions.Single(x => x.MenuOptionId == userChoice).ExecuteStoredMethod();
                }
            } while (!isExiting);
        }

        /// <summary>
        /// Populates a set of option for the user to choose from.
        /// </summary>
        public override void PopulateAllSubOptions()
        {
            IMyDelayedCaller randomAnimals = new MyDelayedCaller<int>(PlayWithRandomAnimals, MAX_NUMBER_RANDOM_ANIMALS);
            IMyDelayedCaller singleRandomAnimal = new MyDelayedCaller<int>(PlayWithRandomAnimals, 1);
            _menuOptions.Add(new MenuOption(1, randomAnimals, "Play with randomized animals", "randomizedAnimals"));
            _menuOptions.Add(new MenuOption(2, singleRandomAnimal, "Play with one random animal", "randomizedAnimals"));
            _menuOptions.Add(new MenuOption(3, "(Exit) Stop playing with animals", "Exit"));
        }

        public override void ShowOptions()
        {
            System.Console.WriteLine("How would you like to interact with the animals?: ");
            foreach (MenuOption currentOption in _menuOptions)
            {
                System.Console.WriteLine(currentOption.MenuOptionId.ToString() + ") " + currentOption.MenuOptionDescription);
            }
        }

        /// <summary>
        /// Creates a random set of animals
        /// </summary>
        /// <param name="maxNumberOfAnimals">The maximum number of animals to create. Default vlaue is a private class constant.</param>
        /// <returns>A list of Animal objects containing at least 1 item</returns>
        public List<Animal> CreateRandomSetOfAnimals(int maxNumberOfAnimals = MAX_NUMBER_RANDOM_ANIMALS)
        {
            List<Animal> returnValue = new List<Animal>();
            // create at least 1 animal
            int numberOfAnimals = RandomNumberGenerator.GetInt32(maxNumberOfAnimals) + 1;
            // grab all subClasses of Animal
            var animalTypes = CommonHelper.GetAllSubClasses(typeof(Animal), "Testbed.Common");

            // create the set of random animals
            for (int counter = 0; counter < numberOfAnimals; counter++)
            {
                // generate a random name ~80% of the time
                string animalName = RandomNumberGenerator.GetInt32(5) > 0 ? CommonHelper.GetRandomName() : string.Empty;

                // create random animal
                int randomizeAnimalType = RandomNumberGenerator.GetInt32(animalTypes.Length);
                Animal newAnimal = (Animal)Activator.CreateInstance(animalTypes[randomizeAnimalType], animalName)!;
                returnValue.Add(newAnimal);
            }
            return returnValue;
        }

        private void PlayWithRandomAnimals(int numberOfAnimals = 0)
        {
            // Create a random set of animals and then interact with them
            var randomAnimals = numberOfAnimals > 0 ? this.CreateRandomSetOfAnimals(numberOfAnimals) : this.CreateRandomSetOfAnimals();
            foreach (IAnimal currentAnimal in randomAnimals)
            {
                currentAnimal.Interact();
            }
        }
    }
}
