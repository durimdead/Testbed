using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Enums;
using Testbed.Common.Models.Animals;
using Testbed.Common.Sorting.AnimalSort.Interfaces;

namespace Testbed.Common.Sorting.AnimalSort
{
    public class AnimalSortByReverseCurrentOrder : IAnimalSort
    {
        /// <summary>
        /// Takes a list of animals and returns a sorted list of animals
        /// </summary>
        /// <param name="animalsToSort">the list of Animals to sort</param>
        /// <param name="sortOrder">Not actually used here since we are just reversing the order. This is the only implementation like this - there should be a better organized way for this</param>
        /// <returns>A list of sorted animals</returns>
        public List<Animal> Sort(List<Animal> animalsToSort, CommonEnums.SortOrder sortOrder)
        {
            List<Animal> sortedAnimals = animalsToSort;
            sortedAnimals.Reverse();
            return sortedAnimals;
        }
    }
}
