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
using Testbed.Common.Sorting.AnimalSort.Interfaces;
using Testbed.Common.Sorting.Common.Interfaces;
using static Testbed.Common.Enums.AnimalEnums;
using static Testbed.Common.Enums.CommonEnums;
using static Testbed.Common.Enums.SortingEnums;

namespace Testbed.Common.Services.Animals
{
    public class AnimalFunctionalityService: IAnimalFunctionality
    {
        private const int MAX_NUMBER_RANDOM_ANIMALS = 10;
        private List<Animal> _animals = new List<Animal>();
        private Dictionary<AnimalSortType, IItemSort<Animal>> _animalSortingAlgorithms;

        /// <summary>
        /// set up the sorting algorithms on initialization
        /// </summary>
        public AnimalFunctionalityService()
        {
            _animalSortingAlgorithms = InitializeAnimalSortingAlgorithms();
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

        /// <summary>
        /// This will create a set of random animals based on the input, and then "interact" with the created animals
        /// </summary>
        /// <param name="numberOfAnimals">the max number of random animals to create. 0 uses the default value in the class</param>
        public void PlayWithRandomAnimals(int numberOfAnimals = 0)
        {
            // Create a new, random set of animals and then interact with them
            _animals = numberOfAnimals > 0 ? this.CreateRandomSetOfAnimals(numberOfAnimals) : this.CreateRandomSetOfAnimals();
            InteractWithCurrentAnimals();
        }

        /// <summary>
        /// Interacts with the currently created animals
        /// </summary>
        public void InteractWithCurrentAnimals()
        {
            if (HasAnimalsToPlayWith())
            {
                foreach (IAnimal currentAnimal in _animals)
                {
                    currentAnimal.Interact();
                }
            }
        }

        /// <summary>
        /// Outputs all of the stats for the current set of animals.
        /// </summary>
        public void OutputAnimalStatistics()
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

            // output the stats for the animals.
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

        /// <summary>
        /// determines if there are any animals to play with. If there are not, it will output that there are no animals to play with.
        /// </summary>
        /// <returns>true if there is are any animals in the list, otherwise false.</returns>
        public bool HasAnimalsToPlayWith()
        {
            bool returnValue = _animals.Count > 0;
            if (!returnValue)
            {
                System.Console.WriteLine("Sorry, there aren't any animals to play with right now :(");
            }
            return returnValue;
        }

        /// <summary>
        /// Performs a sorting algorithm depending on the <paramref name="sortType"/> and <paramref name="sortOrder"/>(Ascending by default) for
        /// the current list of animals
        /// </summary>
        /// <param name="sortType">enum passed in to indicate what we are sorting on</param>
        /// <param name="sortOrder">either Ascending or Descending (Ascending by default)</param>
        public void PerformSorting(AnimalSortType sortType, SortOrder sortOrder = SortOrder.Ascending)
        {
            try
            {
                // ensure that the sorting type we're attempting to do exists in the possible sorting algorithms
                if (!_animalSortingAlgorithms.TryGetValue(sortType, out var algorithm))
                {
                    throw new NotImplementedException("The sort type of " + sortType.ToString() + " has not been implemented yet.");
                }
                // perform sort on animals
                _animals = _animalSortingAlgorithms[sortType].Sort(_animals, sortOrder);
            }
            catch (Exception ex)
            {
                ConsoleHelper.OutputError(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Initializes the ability to utilize the sorting algorithms based on the IAnimalSort interface and what classes have implemented it
        /// </summary>
        /// <returns>A Dictionary with the key/value pairs for what sorting algorithms are available to be invoked.</returns>
        private Dictionary<AnimalSortType, IItemSort<Animal>> InitializeAnimalSortingAlgorithms()
        {
            var returnValue = MenuSortOptionHelper<AnimalSortType, Animal, IAnimalSort>.InitializeSortingAlgorithms();
            return returnValue;
        }
    }
}
