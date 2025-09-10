using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Models.Animals;

namespace Testbed.Common.Services.Interfaces
{
    public interface IAnimalFunctionality
    {
        /// <summary>
        /// Creates a random set of animals
        /// </summary>
        /// <returns>A list of Animal objects containing at least 1 item</returns>
        public List<Animal> CreateRandomSetOfAnimals();
    }
}
