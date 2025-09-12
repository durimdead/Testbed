using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Animals;
using static Testbed.Common.Enums.CommonEnums;

namespace Testbed.Common.Sorting.Common.Interfaces
{
    public interface IItemSort<T>
    {
        /// <summary>
        /// Takes a list of items and returns a sorted list of items
        /// </summary>
        /// <param name="itemsToSort">the list of items to sort</param>
        /// <param name="sortOrder">The sort order</param>
        /// <returns>A list of sorted items</returns>
        public List<T> Sort(List<T> itemsToSort, SortOrder sortOrder);
    }
}
