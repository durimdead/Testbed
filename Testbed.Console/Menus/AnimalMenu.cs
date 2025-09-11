using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Helpers;
using Testbed.Common.Models;
using Testbed.Common.Models.Animals;
using Testbed.Common.Models.Interfaces;
using Testbed.Common.Services.Animals;
using Testbed.Common.Services.Interfaces;
using Testbed.Common.Services.MethodCallers;
using static Testbed.Common.Enums.AnimalEnums;
using static Testbed.Common.Enums.CommonEnums;

namespace Testbed.Console.Menus
{
    public class AnimalMenu: MainMenuOption, IMenuOptionHolder
    {
        private const int MAX_NUMBER_RANDOM_ANIMALS = 10;
        private const string USER_OPTION_DESCRIPTION = "Play with Animals";
        private List<MenuOption> _menuOptions = new List<MenuOption>();
        private IAnimalFunctionality _animalFunctionalityService;

        public AnimalMenu(int mainMenuOptionId, IAnimalFunctionality? animalFunctionalityService = null) : base(mainMenuOptionId, USER_OPTION_DESCRIPTION, string.Empty)
        {
            _animalFunctionalityService = animalFunctionalityService == null ? new AnimalFunctionalityService() : animalFunctionalityService;
        }
        public AnimalMenu(MainMenuOption mainMenuOption, IAnimalFunctionality? animalFunctionalityService = null) : base(mainMenuOption.MainMenuOptionId, mainMenuOption.MainMenuOptionDescription, mainMenuOption.MainMenuOptionName)
        {
            _animalFunctionalityService = animalFunctionalityService == null ? new AnimalFunctionalityService() : animalFunctionalityService;
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
                IMyDelayedCaller randomAnimals = new MyDelayedCaller<int>(_animalFunctionalityService.PlayWithRandomAnimals, MAX_NUMBER_RANDOM_ANIMALS);
                IMyDelayedCaller singleRandomAnimal = new MyDelayedCaller<int>(_animalFunctionalityService.PlayWithRandomAnimals, 1);
                IMyDelayedCaller interactWithCurrentAnimals = new MyDelayedCaller(_animalFunctionalityService.InteractWithCurrentAnimals);
                IMyDelayedCaller showAnimalStats = new MyDelayedCaller(_animalFunctionalityService.OutputAnimalStatistics);
                List<MenuOption> animalSortingAlgorithms = new List<MenuOption>();

                int counter = 1;
                _menuOptions.Add(new MenuOption(counter++, interactWithCurrentAnimals, "Interact with the current set of animals", "showAnimals"));
                _menuOptions.Add(new MenuOption(counter++, showAnimalStats, "Show animal statistics", "animalStats"));
                _menuOptions.Add(new MenuOption(counter++, randomAnimals, "Play with randomized animals", "randomizedAnimals"));
                _menuOptions.Add(new MenuOption(counter++, singleRandomAnimal, "Play with one random animal", "singleRandomAnimal"));

                // add in all the sorting capabilities
                foreach (var currentSortType in Enum.GetValues(typeof(AnimalSortType)).Cast<AnimalSortType>().ToList())
                {
                    // get only the sorting information (i.e. "ByName") from the enum, not the "AnimalSort" part at the beginning of each of them
                    string currentReadableSortType = CommonHelper.ConvertVariableNameToReadableString(currentSortType.ToString().Replace("AnimalSort", string.Empty));
                    IMyDelayedCaller currentDelayedMethod = new MyDelayedCaller<AnimalSortType, SortOrder>(_animalFunctionalityService.PerformSorting, currentSortType, SortOrder.Ascending);
                    MenuOption currentMenuOption = new MenuOption(counter++, currentDelayedMethod, "Sort the animals (" + currentReadableSortType + ")", currentSortType.ToString());
                    _menuOptions.Add(currentMenuOption);
                }
                _menuOptions.Add(new MenuOption(counter++, "(Exit) Stop playing with animals", "Exit"));
            }
        }

        /// <summary>
        /// Outputs all menu options the user has. If there are currently no menu options, it will fill populate them with the default ones
        /// </summary>
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
    }
}
