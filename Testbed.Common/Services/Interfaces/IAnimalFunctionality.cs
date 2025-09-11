using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Animals;
using static Testbed.Common.Enums.AnimalEnums;
using static Testbed.Common.Enums.CommonEnums;

namespace Testbed.Common.Services.Interfaces
{
    public interface IAnimalFunctionality
    {
        /// <summary>
        /// Creates a random set of animals
        /// </summary>
        /// <param name="maxNumberOfAnimals">The maximum number of animals to create.</param>
        /// <returns>A list of Animal objects containing at least 1 item</returns>
        public List<Animal> CreateRandomSetOfAnimals(int maxNumberOfAnimals);

        /// <summary>
        /// This will create a set of random animals based on the input, and then "interact" with the created animals
        /// </summary>
        /// <param name="numberOfAnimals">the max number of random animals to create</param>
        public void PlayWithRandomAnimals(int numberOfAnimals);

        /// <summary>
        /// Interacts with the currently created animals
        /// </summary>
        public void InteractWithCurrentAnimals();

        /// <summary>
        /// Outputs all of the stats for the current set of animals.
        /// </summary>
        public void OutputAnimalStatistics();

        /// <summary>
        /// determines if there are any animals to play with. If there are not, it will output that there are no animals to play with.
        /// </summary>
        /// <returns>true if there is are any animals in the list, otherwise false.</returns>
        public bool HasAnimalsToPlayWith();

        /// <summary>
        /// Performs a sorting algorithm depending on the <paramref name="sortType"/> and <paramref name="sortOrder"/>(Ascending by default) for
        /// the current list of animals
        /// </summary>
        /// <param name="sortType">enum passed in to indicate what we are sorting on</param>
        /// <param name="sortOrder">either Ascending or Descending (Ascending by default)</param>
        public void PerformSorting(AnimalSortType sortType, SortOrder sortOrder = SortOrder.Ascending);
    }
}
