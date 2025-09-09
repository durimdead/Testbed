using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Interfaces;

namespace Testbed.Common.Models
{
    public abstract class Animal : IAnimal
    {
        public virtual string Name { get; set; } = string.Empty;
        public virtual string AnimalSound { get; } = string.Empty;
        public virtual Enums.AnimalEnums.TravelType AnimalTravelType { get; } = Enums.AnimalEnums.TravelType.None;

        public virtual void Interact()
        {
            List<string> interactions = new List<string>();
            interactions.Add(Greet());
            interactions.Add(Speak());
            interactions.Add(Travel());

            foreach(var currentInteraction in interactions)
            {
                if (currentInteraction != string.Empty)
                {
                    Console.WriteLine(currentInteraction);
                }
            }
            Console.WriteLine("-----");
        }

        public virtual string Greet()
        {
            string animalType = this.GetType().ToString().Split(".").Last().ToLower();
            string returnValue = "Say hello to ";
            if (this.Name != string.Empty)
            {
                returnValue += this.Name + " ";
            }
            returnValue += "the " + animalType + "!";

            return returnValue;
        }

        public virtual string Speak()
        {
            return this.AnimalSound != string.Empty ? "It says " + this.AnimalSound + ". " : string.Empty;
        }

        public virtual string Travel()
        {
            return this.AnimalTravelType != Enums.AnimalEnums.TravelType.None ? "They " + this.AnimalTravelType.ToString() + " around happily!" : string.Empty;
        }
    }
}
