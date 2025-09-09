using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Testbed.Common.Enums;

namespace Testbed.Common.Models
{
    public class Bird : Animal
    {
        public override string AnimalSound { get; } = "Chirp";
        public override string Name { get; set; }
        public override AnimalEnums.TravelType AnimalTravelType { get; }

        public Bird(string name)
        {
            Name = name;
            this.AnimalTravelType = RandomizeTravelType(true);
        }
        
        public Bird()
        {
            Name = string.Empty;
            this.AnimalTravelType = RandomizeTravelType(true);
        }
    }
}
