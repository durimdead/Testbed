using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Services.Interfaces;
using Testbed.Common.Services.MethodCallers;

namespace Testbed.Common.Models
{
    public class MenuOption
    {
        public IMyDelayedCaller? MethodToRun { get; private set; }
        public int MenuOptionId { get; private set; }
        public string MenuOptionName { get; private set; }
        public string MenuOptionDescription { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="optionId">ID of the option</param>
        /// <param name="optionDescription">Description of the option</param>
        /// <param name="optionName">Name of the option (uses the <paramref name="optionDescription"/> if no name is passed in)</param>
        public MenuOption(int optionId, string optionDescription, string optionName = "")
        {
            MenuOptionId = optionId;
            MenuOptionDescription = optionDescription;
            MenuOptionName = optionName == "" ? optionDescription : optionName;
        }

        /// <summary>
        /// Constructor including a method to be able to invoke upon choosing the menu option
        /// </summary>
        /// <param name="optionId">ID of the option</param>
        /// <param name="methodToRun">Delegate method that may have 0 or multiple params (based on implementation of IMyDelayedCaller)</param>
        /// <param name="optionDescription">Description of the option</param>
        /// <param name="optionName">Name of the option (uses the <paramref name="optionDescription"/> if no name is passed in)</param>
        public MenuOption(int optionId, IMyDelayedCaller methodToRun, string optionDescription, string optionName = "")
        {
            MethodToRun = methodToRun;
            MenuOptionId = optionId;
            MenuOptionDescription = optionDescription;
            MenuOptionName = optionName == "" ? optionDescription : optionName;
        }

        /// <summary>
        /// Executes the stored method if it's not null.
        /// </summary>
        /// <returns>False if stored method is null, otherwise true</returns>
        public bool ExecuteStoredMethod()
        {
            bool returnValue = false;
            if (MethodToRun != null)
            {
                MethodToRun.Invoke();
                returnValue = true;
            }

            return returnValue;
        }
        
    }
}
