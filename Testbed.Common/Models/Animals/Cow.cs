using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Enums;

namespace Testbed.Common.Models.Animals
{
    internal class Cow : Animal
    {
        public override string AnimalSound { get; } = "Moo";
        public override string Name { get; set; }
        public override int NumberOfLimbs { get; } = 4;
        public override AnimalEnums.LimbType AnimalLimbType { get; private protected set; } = AnimalEnums.LimbType.Legs;
        public override AnimalEnums.TravelType AnimalTravelType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the Cow</param>
        public Cow(string name)
        {
            Name = name;
            AnimalTravelType = RandomizeTravelType(true);
        }
    }
}
