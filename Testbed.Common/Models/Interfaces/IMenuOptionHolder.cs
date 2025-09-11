using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Helpers;
using Testbed.Common.Services.Interfaces;
using Testbed.Common.Services.MethodCallers;

namespace Testbed.Common.Models.Interfaces
{
    public interface IMenuOptionHolder
    {
        /// <summary>
        /// The entry point for interactions.
        /// </summary>
        public void Start();

        /// <summary>
        /// Populates a set of options for the user to choose from.
        /// </summary>
        public void PopulateAllMenuOptions();

        /// <summary>
        /// Shows all of the populated options
        /// </summary>
        public void ShowOptions();
    }
}
