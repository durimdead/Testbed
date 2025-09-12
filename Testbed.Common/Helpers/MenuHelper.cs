using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Sorting.Common.Interfaces;

namespace Testbed.Common.Helpers
{
    public static class MenuHelper<TEnum,TType,TSortingInterface> where TEnum : struct, IConvertible
    {

        /// <summary>
        /// gets a set of stored methods to perform a given type of sorting algorithm
        /// </summary>
        /// <returns>A dictionary of Sort types for a given the enum for available sorts for that type and the base type to sort</returns>
        public static Dictionary<TEnum, IItemSort<TType>> InitializeSortingAlgorithms()
        {
            Dictionary<TEnum, IItemSort<TType>> returnValue = new Dictionary<TEnum, IItemSort<TType>>();
            try
            {
                Type interfaceType = typeof(TSortingInterface);
                // Get all types that implement this interface that are classes, but not abstract
                IEnumerable<Type> implementingTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

                // populate with all the different types of sorting algorithms available
                foreach (Type currentType in implementingTypes)
                {
                    // add an instance of the current sorting class to the dictionary
                    string currentTypeClassName = currentType.ToString().Split(".").Last();
                    try
                    {
                        TEnum currentSortType = (TEnum)Enum.Parse(typeof(TEnum), currentTypeClassName);
                        returnValue[currentSortType] = (IItemSort<TType>)Activator.CreateInstance(currentType)!;
                    }
                    // If we get an error here, it is most likely because the sort type attempting to be added doesn't exist yet.
                    // No need to stop the others from getting added
                    catch (Exception ex)
                    {
                        ConsoleHelper.OutputError(ex.Message);
                    }
                }
            }
            // if we hit an error, output the error and clear the return value to avoid potentially returning a bad set of data
            catch (Exception ex)
            {
                ConsoleHelper.OutputError(ex.Message);
                returnValue.Clear();
            }
            return returnValue;
        }
    }
}
