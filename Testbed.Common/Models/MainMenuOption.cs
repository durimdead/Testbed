using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Interfaces;

namespace Testbed.Common.Models
{
    public class MainMenuOption : IMenuOptionHolder
    {
        public int MainMenuOptionId { get; private set; }
        public string MainMenuOptionName { get; private set; }
        public string MainMenuOptionDescription { get; private set; }

        public MainMenuOption(int mainMenuOptionId, string description, string name = "")
        {
            MainMenuOptionId = mainMenuOptionId;
            MainMenuOptionDescription = description;
            MainMenuOptionName = name == string.Empty ? description : name;
            PopulateAllSubOptions();
        }

        /// <summary>
        /// Always run in the constructor to ensure that all sub-classes will always have this method running to avoid having
        /// to worry about where to put this setup. It will ensure that a list of sub-options for interactions will be created.
        /// </summary>
        public virtual void PopulateAllSubOptions()
        {
            // nothing to do here by default
        }

        /// <summary>
        /// We will use this to start the interaction with the User Option
        /// </summary>
        public virtual void Start()
        {
            // if we are not overriding this, we assume that the application will be exiting.
            System.Console.WriteLine("Now Exiting the application");
        }

        ///
        public virtual void ShowOptions()
        {
            // nothing to do here by default
        }
    }
}
