using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Enums;
using Testbed.Common.Models.Animals;
using Testbed.Common.Sorting.AnimalSort.Interfaces;
using static Testbed.Common.Enums.CommonEnums;

namespace Testbed.Common.Sorting.AnimalSort
{
    public class AnimalSortByTravelType : IAnimalSort
    {
        /// <summary>
        /// Takes a list of animals and returns a sorted list of animals
        /// </summary>
        /// <param name="animalsToSort">the list of Animals to sort</param>
        /// <param name="sortOrder">The sort order</param>
        /// <returns>A list of sorted animals</returns>
        public List<Animal> Sort(List<Animal> animalsToSort, CommonEnums.SortOrder sortOrder)
        {
            List<Animal> returnValue = SortOrder.Ascending == sortOrder
                ? animalsToSort.OrderBy(x => (int)x.AnimalTravelType).ToList()
                : animalsToSort.OrderByDescending(x => (int)x.AnimalTravelType).ToList();
            return returnValue;
        }
    }
}
