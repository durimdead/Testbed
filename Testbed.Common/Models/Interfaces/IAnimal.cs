using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed.Common.Models.Interfaces
{
    public interface IAnimal
    {
        /// <summary>
        /// To hear what the animal would say
        /// </summary>
        /// <returns>A string with the noise that the animal makes.</returns>
        public string Speak();
 
    }
}
