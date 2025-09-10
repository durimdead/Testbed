using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed.Common.Models
{
    public class UserOption
    {
        public int UserOptionId { get; private set; }
        public string UserOptionName { get; private set; }
        public string UserOptionDescription { get; private set; }

        public UserOption(int userOptionId, string description, string name = "")
        {
            UserOptionId = userOptionId;
            UserOptionDescription = description;
            UserOptionName = name == string.Empty ? description : name;
        }
    }
}
