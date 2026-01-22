using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Testbed.Common.Enums;

namespace Testbed.Common.Models.Animals
{
    public class Bird : Animal
    {
        public override string AnimalSound { get; } = "Chirp";
        public override string Name { get; set; }
        public override int NumberOfLimbs { get;  } = 2;
        public override AnimalEnums.LimbType AnimalLimbType { get; private protected set; } = AnimalEnums.LimbType.Wings;
        public override AnimalEnums.TravelType AnimalTravelType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the Bird</param>
        public Bird(string name)
        {
            Name = name;
            AnimalTravelType = RandomizeTravelType(true, true);
            if (AnimalTravelType != AnimalEnums.TravelType.Fly)
            {
                this.AnimalLimbType = AnimalEnums.LimbType.Legs;
            }
        }
    }
}
