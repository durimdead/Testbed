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
    public class AnimalSortByAnimalType : IAnimalSort
    {
        /// <summary>
        /// Takes a list of animals and returns a sorted list of animals
        /// </summary>
        /// <param name="animalsToSort">the list of Animals to sort</param>
        /// <param name="sortOrder">The sort order</param>
        /// <returns>A list of sorted animals</returns>
        public List<Animal> Sort(List<Animal> animalsToSort, CommonEnums.SortOrder sortOrder)
        {
            List<Animal> returnValue = sortOrder == CommonEnums.SortOrder.Ascending
                ? animalsToSort.OrderBy(x => x.GetType().ToString()).ToList()
                : animalsToSort.OrderByDescending(x => x.GetType().ToString()).ToList();
            return returnValue;
        }
    }
}
