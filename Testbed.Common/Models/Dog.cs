using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Enums;

namespace Testbed.Common.Models
{
    public class Dog : Animal
    {
        public override string Name { get; set; }
        public override string AnimalSound { get; } = "Woof";
        public override AnimalEnums.TravelType AnimalTravelType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the Dog</param>
        public Dog(string name)
        {
            Name = name;
            this.AnimalTravelType = RandomizeTravelType(true);
        }
    }
}
