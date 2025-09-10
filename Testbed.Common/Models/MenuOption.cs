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

        public MenuOption(int optionId, string optionDescription, string optionName = "")
        {
            MenuOptionId = optionId;
            MenuOptionDescription = optionDescription;
            MenuOptionName = optionName == "" ? optionDescription : optionName;
        }

        public MenuOption(IMyDelayedCaller methodToRun, int optionId, string optionDescription, string optionName = "")
        {
            MethodToRun = methodToRun;
            MenuOptionId = optionId;
            MenuOptionDescription = optionDescription;
            MenuOptionName = optionName == "" ? optionDescription : optionName;
        }

        /// <summary>
        /// executes the stored method if it's not null.
        /// </summary>
        /// <returns>false if stored method is null, otherwise true</returns>
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
