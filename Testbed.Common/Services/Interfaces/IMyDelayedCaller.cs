using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed.Common.Services.Interfaces
{
    public interface IMyDelayedCaller
    {
        /// <summary>
        /// Invokes the stored method
        /// </summary>
        public void Invoke();
    }
}
