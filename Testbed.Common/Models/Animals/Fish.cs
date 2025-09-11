﻿using System;
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
