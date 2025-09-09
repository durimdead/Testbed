using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Enums;
using Testbed.Common.Models.Interfaces;

namespace Testbed.Common.Models
{
    public abstract class Animal : IAnimal
    {
        public virtual string Name { get; set; } = string.Empty;
        public virtual string AnimalSound { get; } = string.Empty;
        public virtual Enums.AnimalEnums.TravelType AnimalTravelType { get; }

        private bool isJudgingYou = false;
        private string animalType;
        public Animal()
        {
            RandomizeJudgement();
            animalType = this.GetType().ToString().Split(".").Last().ToLower();
        }

        public virtual void Interact()
        {
            List<string> interactions = new List<string>();
            interactions.Add(Greet());
            interactions.Add(Speak());
            interactions.Add(Travel());

            foreach (var currentInteraction in interactions)
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
            string returnValue = string.Empty;

            if (this.AnimalSound != string.Empty)
            {
                if (isJudgingYou)
                {
                    returnValue = "The " + animalType + " is staring into your soul. You can feel it judging you. Silently. Maliciously. Then, suddenly, it lets out a faint sound... '" + this.AnimalSound + "'";
                }
                else
                {
                    returnValue = "It says " + this.AnimalSound + "!";
                }
            }

            return returnValue;
        }

        public virtual string Travel()
        {
            string returnValue = string.Empty;
            if (isJudgingYou)
            {
                returnValue = "The " + this.animalType + " just sits there. They continue to judge you. Did you forget their birthday? Maybe you didn't give them their treat earlier today that they wanted so badly. Whatever it is, you are a monster.";
            }
            else if (this.AnimalTravelType != Enums.AnimalEnums.TravelType.None)
            {
                returnValue = "They " + this.AnimalTravelType.ToString().ToLower() + " around happily!";
            }
            return returnValue;
        }

        private void RandomizeJudgement()
        {
            int randomNumber = RandomNumberGenerator.GetInt32(10);
            if (randomNumber == 1)
            {
                isJudgingYou = true;
            }
        }

        internal AnimalEnums.TravelType RandomizeTravelType(bool canFly = false)
        {
            int randomNumberSeed = canFly ? 4 : 3;
            int randomNumber = RandomNumberGenerator.GetInt32(randomNumberSeed);
            AnimalEnums.TravelType returnValue;
            switch (randomNumber)
            {
                case 0:
                    returnValue = AnimalEnums.TravelType.None;
                    break;
                case 1:
                    returnValue = AnimalEnums.TravelType.Walk;
                    break;
                case 2:
                    returnValue = AnimalEnums.TravelType.Swim;
                    break;
                case 3:
                    returnValue = AnimalEnums.TravelType.Fly;
                    break;
                default:
                    returnValue = AnimalEnums.TravelType.None;
                    break;
            }
            return returnValue;
        }
    }
}
