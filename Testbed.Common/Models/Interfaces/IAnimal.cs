using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed.Common.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; set; }
        internal string AnimalSound { get; set; }

        /// <summary>
        /// To hear what the animal would say
        /// </summary>
        public void Speak();
 
    }
}
