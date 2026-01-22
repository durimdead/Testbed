using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Enums;
using Testbed.Common.Models.Interfaces;

namespace Testbed.Common.Models.Animals
{
    public class Cat : Animal
    {
        public override string AnimalSound { get; } = "Meow";
        public override string Name { get; set; }
        public override int NumberOfLimbs { get; } = 4;
        public override AnimalEnums.LimbType AnimalLimbType { get; private protected set; } = AnimalEnums.LimbType.Legs;
        public override AnimalEnums.TravelType AnimalTravelType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the Cat</param>
        public Cat(string name)
        {
            Name = name;
            AnimalTravelType = RandomizeTravelType(true);
        }
    }
}
