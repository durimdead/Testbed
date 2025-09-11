using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Enums;
using Testbed.Common.Models.Interfaces;

namespace Testbed.Common.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public virtual string Name { get; set; } = string.Empty;
        public virtual string AnimalSound { get; } = string.Empty;
        public virtual AnimalEnums.TravelType AnimalTravelType { get; }

        public bool IsJudgingYou { get; private set; } = false;
        public string AnimalType { get; private set; }

        /// <summary>
        /// Constructor - Randomize Judgement will happen here regardless of what child is created since it will also create the parent.
        /// This way, the child classes don't have to worry about figuring out if they are in a judgement-free zone.
        /// </summary>
        public Animal()
        {
            RandomizeJudgement();
            AnimalType = GetType().ToString().Split(".").Last().ToLower();
        }

        /// <summary>
        /// Performs all interactions with the animal, skipping any that don't have the full set of information required for the interaction.
        /// </summary>
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

        /// <summary>
        /// Greeting the animal
        /// </summary>
        /// <returns>String of the animal type and name (if one exists for the animal)</returns>
        public virtual string Greet()
        {
            string returnValue = "Say hello to ";
            if (Name != string.Empty)
            {
                returnValue += Name + " ";
            }
            returnValue += "the " + AnimalType + "!";

            return returnValue;
        }

        /// <summary>
        /// The animal will make a sound to you, if one exists for them. If they are "judging you", you will get a snarkier message
        /// </summary>
        /// <returns>string with animal speech</returns>
        public virtual string Speak()
        {
            string returnValue = string.Empty;

            if (AnimalSound != string.Empty)
            {
                if (IsJudgingYou)
                {
                    returnValue = "The " + AnimalType + " is staring into your soul. You can feel it judging you. Silently. Maliciously. Then, suddenly, it lets out a faint sound... '" + AnimalSound + "'";
                }
                else
                {
                    returnValue = "It says " + AnimalSound + "!";
                }
            }

            return returnValue;
        }

        /// <summary>
        /// The animal will be moving around in some way if they currently have a "TravelType" assigned to them. Regardless of the TravelType, you will get a different message if the animal is currently judging you
        /// </summary>
        /// <returns>string with animal travel description</returns>
        public virtual string Travel()
        {
            string returnValue = string.Empty;
            if (IsJudgingYou)
            {
                returnValue = "The " + AnimalType + " just sits there. They continue to judge you. Did you forget their birthday? Maybe you didn't give them their treat earlier today that they wanted so badly. Whatever it is, you are a monster.";
            }
            else if (AnimalTravelType != AnimalEnums.TravelType.None)
            {
                returnValue = "They " + AnimalTravelType.ToString().ToLower() + " around happily!";
            }
            return returnValue;
        }

        /// <summary>
        /// Randomly decides if the animal is judging you
        /// </summary>
        private void RandomizeJudgement()
        {
            int randomNumber = RandomNumberGenerator.GetInt32(10);
            if (randomNumber == 1)
            {
                IsJudgingYou = true;
            }
        }

        /// <summary>
        /// randomized the travel type, accounting for whether the animal can fly or not
        /// </summary>
        /// <param name="canSwim">If true, there is a chance that the animal will be swimming</param>
        /// <param name="canFly">If true, there is a chance that the animal will be flying</param>
        /// <returns>AnimalEnums.TravelType</returns>
        internal AnimalEnums.TravelType RandomizeTravelType(bool canSwim = false, bool canFly = false)
        {
            int randomNumberSeed = 4;
            int randomNumber = RandomNumberGenerator.GetInt32(randomNumberSeed);
            AnimalEnums.TravelType returnValue;
            switch (randomNumber)
            {
                case 1:
                    returnValue = AnimalEnums.TravelType.Walk;
                    break;
                case 2:
                    returnValue = canSwim ? AnimalEnums.TravelType.Swim : AnimalEnums.TravelType.None;
                    break;
                case 3:
                    returnValue = canFly ? AnimalEnums.TravelType.Fly : AnimalEnums.TravelType.None;
                    break;
                default:
                    returnValue = AnimalEnums.TravelType.None;
                    break;
            }
            return returnValue;
        }
    }
}
