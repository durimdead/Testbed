using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Sorting.Common.Interfaces;

namespace Testbed.Common.Helpers
{
    /// <summary>
    /// A class to help with management of menu options that have to do with sorting items related to the menu you are working with
    /// </summary>
    /// <typeparam name="TEnum">The Enum related to the Sorting Type</typeparam>
    /// <typeparam name="TType">The base class of the Sortable objects</typeparam>
    /// <typeparam name="TSortingInterface">The interface that implements IItemSort, which then has classes that implement that interface for the sorting algorithm.</typeparam>
    public static class MenuSortOptionHelper<TEnum,TType,TSortingInterface> where TEnum : struct, IConvertible
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
                    .SelectMany(currentAssembly => currentAssembly.GetTypes())
                    .Where(currentType => interfaceType.IsAssignableFrom(currentType) && currentType.IsClass && !currentType.IsAbstract);

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
