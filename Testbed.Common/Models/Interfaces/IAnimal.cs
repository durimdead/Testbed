using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Testbed.Common.Enums.AnimalEnums;

namespace Testbed.Common.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; set; }
        string AnimalSound { get; }
        TravelType AnimalTravelType { get; }

        /// <summary>
        /// The animal will make a sound to you, if one exists for them. If they are "judging you", you will get a snarkier message
        /// </summary>
        /// <returns>string with animal speech</returns>
        public string Speak();
        /// <summary>
        /// The animal will be moving around in some way if they currently have a "TravelType" assigned to them. Regardless of the TravelType, you will get a different message if the animal is currently judging you
        /// </summary>
        /// <returns>string with animal travel description</returns>
        public string Travel();
        /// <summary>
        /// Greeting the animal
        /// </summary>
        /// <returns>String of the animal type and name (if one exists for the animal)</returns>
        public string Greet();

        /// <summary>
        /// Performs all interactions with the animal, skipping any that don't have the full set of information required for the interaction.
        /// </summary>
        public void Interact();
    }
}
