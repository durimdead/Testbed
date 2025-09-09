using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Interfaces;

namespace Testbed.Common.Models
{
    public class Cat : Animal
    {
        private readonly string ANIMAL_SOUND = "Meow!";

        public Cat(string name)
        {
            Name = name;
        }

        public override string Name { get; set; }

        public override string Speak()
        {
            return this.ANIMAL_SOUND;
        }
    }
}
