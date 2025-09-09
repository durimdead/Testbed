using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed.Common.Enums
{
    public static class AnimalEnums
    {
        public enum TravelType
        {
            None,
            Walk, 
            Fly,
            Swim,
        }

        public enum AnimalType
        {
            Cat = 1,
            Dog,
            Bird
        }
    }
}
