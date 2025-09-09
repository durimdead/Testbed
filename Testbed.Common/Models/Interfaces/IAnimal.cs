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
        /// To hear what the animal would say
        /// </summary>
        public string Speak();
        public string Travel();
        public string Greet();
        public void Interact();
    }
}
