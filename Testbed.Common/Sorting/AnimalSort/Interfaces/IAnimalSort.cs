using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Animals;
using static Testbed.Common.Enums.CommonEnums;

namespace Testbed.Common.Sorting.AnimalSort.Interfaces
{
    public interface IAnimalSort
    {
        /// <summary>
        /// Takes a list of animals and returns a sorted list of animals
        /// </summary>
        /// <param name="animalsToSort">the list of Animals to sort</param>
        /// <param name="sortOrder">The sort order</param>
        /// <returns>A list of sorted animals</returns>
        public List<Animal> Sort(List<Animal> animalsToSort, SortOrder sortOrder);
    }
}
