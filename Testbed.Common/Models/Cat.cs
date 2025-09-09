using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Enums;
using Testbed.Common.Models.Interfaces;

namespace Testbed.Common.Models
{
    public class Cat : Animal
    {
        public override string AnimalSound { get; } = "Meow!";
        public override string Name { get; set; }
        public override AnimalEnums.TravelType AnimalTravelType { get; } = AnimalEnums.TravelType.Walk;

        public Cat(string name)
        {
            Name = name;
        }
    }
}
