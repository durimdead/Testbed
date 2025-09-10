using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models;
using Testbed.Common.Models.Animals;
using Testbed.Common.Models.Interfaces;
using Testbed.Common.Services.Interfaces;

namespace Testbed.Common.Services.Animals
{
    public class AnimalFunctionalityService: UserOption, IAnimalFunctionality
    {
        private const int MAX_NUMBER_RANDOM_ANIMALS = 10;
        public const string USER_OPTION_DESCRIPTION = "Play with Animals";

        public AnimalFunctionalityService(int userOptionId) : base(userOptionId, USER_OPTION_DESCRIPTION, string.Empty)
        {
        }
        public AnimalFunctionalityService(UserOption userOption) : base(userOption.UserOptionId, userOption.UserOptionDescription, userOption.UserOptionName)
        {
        }

        /// <summary>
        /// Creates a random set of animals
        /// </summary>
        /// <returns>A list of Animal objects containing at least 1 item</returns>
        public List<Animal> CreateRandomSetOfAnimals()
        {
            List<Animal> returnValue = new List<Animal>();
            // create at least 1 animal
            int numberOfAnimals = RandomNumberGenerator.GetInt32(MAX_NUMBER_RANDOM_ANIMALS) + 1;
            // grab all subClasses of Animal
            var animalTypes = CommonService.GetAllSubClasses(typeof(Animal), "Testbed.Common");

            for (int counter = 0; counter < numberOfAnimals; counter++)
            {
                // generate a random name ~80% of the time
                string animalName = RandomNumberGenerator.GetInt32(5) > 0 ? CommonService.GetRandomName() : string.Empty;

                // create random animal
                int randomizeAnimalType = RandomNumberGenerator.GetInt32(animalTypes.Length);
                Animal newAnimal = (Animal)Activator.CreateInstance(animalTypes[randomizeAnimalType], animalName)!;
                returnValue.Add(newAnimal);
            }
            return returnValue;
        }

        /// <summary>
        /// The entry point for animal interactions.
        /// </summary>
        public override void Start()
        {
            System.Console.WriteLine("Now playing with the animals!");
            System.Console.WriteLine("---------------------------------------------");
            // Create a random set of animals and then interact with them
            var randomAnimals = this.CreateRandomSetOfAnimals();
            foreach (IAnimal currentAnimal in randomAnimals)
            {
                currentAnimal.Interact();
            }
        }
    }
}
