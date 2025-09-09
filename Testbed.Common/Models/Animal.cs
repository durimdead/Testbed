using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Interfaces;

namespace Testbed.Common.Models
{
    public class Animal : IAnimal
    {
        public virtual string Name { get; set; } = "...";
        public virtual string AnimalSound { get; } = "...";

        public virtual void Speak()
        {
            string animalType = this.GetType().ToString().Split(".").Last().ToLower();
            Console.WriteLine(this.Name + " the " + animalType + " says " + this.AnimalSound);
        }
    }
}
