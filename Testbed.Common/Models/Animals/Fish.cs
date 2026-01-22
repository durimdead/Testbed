using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Enums;

namespace Testbed.Common.Models.Animals
{
    public class Fish : Animal
    {
        public override string AnimalSound { get; } = "Blub";
        public override string Name { get; set; }
        public override int NumberOfLimbs { get; } = 2;
        public override AnimalEnums.LimbType AnimalLimbType { get; private protected set; } = AnimalEnums.LimbType.Fins;
        public override AnimalEnums.TravelType AnimalTravelType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the Fish</param>
        public Fish(string name)
        {
            Name = name;
            AnimalTravelType = RandomizeTravelType(true, false, false);
        }
    }
}
