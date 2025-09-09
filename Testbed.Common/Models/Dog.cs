using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed.Common.Models
{
    public class Dog : Animal
    {
        public override string Name { get; set; }
        public override string AnimalSound { get; } = "Woof";

        public Dog(string name)
        {
            Name = name;
        }
    }
}
