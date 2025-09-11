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
using static Testbed.Common.Enums.AnimalEnums;

namespace Testbed.Common.Services.Animals
{
    public class AnimalFunctionalityService: MainMenuOption, IAnimalFunctionality, IMenuOptionHolder
    {
        private const int MAX_NUMBER_RANDOM_ANIMALS = 10;
        private const string USER_OPTION_DESCRIPTION = "Play with Animals";
        private List<MenuOption> _menuOptions = new List<MenuOption>();
        private List<Animal> _animals = new List<Animal>();

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
        public override void PopulateAllMenuOptions()
        {
            // only populate the menu options if there isn't anything in there already.
            if (_menuOptions.Count == 0)
            {
                IMyDelayedCaller randomAnimals = new MyDelayedCaller<int>(PlayWithRandomAnimals, MAX_NUMBER_RANDOM_ANIMALS);
                IMyDelayedCaller singleRandomAnimal = new MyDelayedCaller<int>(PlayWithRandomAnimals, 1);
                IMyDelayedCaller showAnimals = new MyDelayedCaller(OutputCurrentAnimals);
                IMyDelayedCaller showAnimalStats = new MyDelayedCaller(OutputAnimalStatistics);
                
                int counter = 1;
                _menuOptions.Add(new MenuOption(counter++, showAnimals, "Show the current list of animals", "showAnimals"));
                _menuOptions.Add(new MenuOption(counter++, showAnimalStats, "Show animal statistics", "animalStats"));
                _menuOptions.Add(new MenuOption(counter++, randomAnimals, "Play with randomized animals", "randomizedAnimals"));
                _menuOptions.Add(new MenuOption(counter++, singleRandomAnimal, "Play with one random animal", "singleRandomAnimal"));
                _menuOptions.Add(new MenuOption(counter++, "(Exit) Stop playing with animals", "Exit"));
            }
        }

        public override void ShowOptions()
        {
            if (_menuOptions.Count == 0)
            {
                PopulateAllMenuOptions();
            }
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
            // Create a new, random set of animals and then interact with them
            _animals = numberOfAnimals > 0 ? this.CreateRandomSetOfAnimals(numberOfAnimals) : this.CreateRandomSetOfAnimals();
            OutputCurrentAnimals();
        }

        private void OutputCurrentAnimals()
        {
            if (HasAnimalsToPlayWith())
            {
                foreach (IAnimal currentAnimal in _animals)
                {
                    currentAnimal.Interact();
                }
            }
        }

        private void OutputAnimalStatistics()
        {
            // generate structures to store the animal information inside of.
            int numberOfAnimals = 0;
            int numberOfJudgementalAnimals = 0;
            Dictionary<string, int> animalTypes = new Dictionary<string, int>();
            int[] animalTravelTypeCount = new int[(int)Enum.GetValues(typeof(TravelType)).Cast<TravelType>().Count()];
            foreach (var currentAnimal in _animals)
            {
                numberOfAnimals++;
                numberOfJudgementalAnimals += currentAnimal.IsJudgingYou ? 1 : 0;
                animalTravelTypeCount[(int)currentAnimal.AnimalTravelType]++;

                // increment the count of the current animal type
                int countOfAnimalType = 0;
                animalTypes.TryGetValue(currentAnimal.AnimalType, out countOfAnimalType);
                animalTypes[currentAnimal.AnimalType] = ++countOfAnimalType;
            }

            System.Console.WriteLine("Number of animals available: " + numberOfAnimals.ToString());
            System.Console.WriteLine("Number of judgemental Animals: " + numberOfJudgementalAnimals.ToString());
            System.Console.WriteLine("Animal travel types: ");
            System.Console.WriteLine("\t Not doing anything: " + animalTravelTypeCount[(int)TravelType.None]);
            System.Console.WriteLine("\t Flying: " + animalTravelTypeCount[(int)TravelType.Fly]);
            System.Console.WriteLine("\t Swimming: " + animalTravelTypeCount[(int)TravelType.Swim]);
            System.Console.WriteLine("\t Walking: " + animalTravelTypeCount[(int)TravelType.Walk]);
            System.Console.WriteLine("Types of Animals: ");
            foreach(var currentType in animalTypes)
            {
                System.Console.WriteLine("\t " + currentType.Key.ToString() + ": " + currentType.Value.ToString());
            }
        }

        private bool HasAnimalsToPlayWith()
        {
            bool returnValue = _animals.Count > 0;
            if (!returnValue)
            {
                System.Console.WriteLine("Sorry, there aren't any animals to play with right now :(");
            }
            return returnValue;
        }
    }
}
