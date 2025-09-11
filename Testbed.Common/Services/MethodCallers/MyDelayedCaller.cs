using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testbed.Common.Services.Interfaces;

namespace Testbed.Common.Services.MethodCallers
{
    //
    //  https://stackoverflow.com/a/21197520
    //

    /// <summary>
    /// Allows the storage of a delegate with 0 parameters
    /// </summary>
    public class MyDelayedCaller : IMyDelayedCaller
    {
        private Action _target;

        /// <summary>
        /// Creating instance of a stored delegate with 0 parameters
        /// </summary>
        /// <param name="target">the delegate</param>
        public MyDelayedCaller(Action target)
        {
            _target = target;
        }

        /// <summary>
        /// Invokes the stored method
        /// </summary>
        public void Invoke()
        {
            _target();
        }
    }

    /// <summary>
    /// Allows the storage of a delegate with exactly 1 parameter
    /// </summary>
    /// <typeparam name="T1">Type of the first param</typeparam>
    public class MyDelayedCaller<T1> : IMyDelayedCaller
    {
        private Action<T1> _target;
        public T1 _param;

        /// <summary>
        /// Creating instance of a stored delegate with 1 parameter
        /// </summary>
        /// <param name="target">the name of the method (i.e. MyDelayedCaller<string>)</param>
        /// <param name="parameter">the first param (fitting the T1 descriptor)</param>
        public MyDelayedCaller(Action<T1> target, T1 parameter)
        {
            _target = target;
            _param = parameter;
        }

        /// <summary>
        /// Invokes the stored method
        /// </summary>
        public void Invoke()
        {
            _target(_param);
        }
    }

    /// <summary>
    /// Allows the storage of a delegate with exactly 2 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first param</typeparam>
    /// <typeparam name="T2">Type of second param</typeparam>
    public class MyDelayedCaller<T1, T2> : IMyDelayedCaller
    {
        private Action<T1, T2> _target;
        public T1 _param1;
        public T2 _param2;

        /// <summary>
        /// Creating instance of a stored delegate with 2 parameters
        /// </summary>
        /// <param name="target">the name of the method (i.e. MyDelayedCaller<string, int>)</param>
        /// <param name="param1">the first param (fitting the T1 descriptor)</param>
        /// <param name="param2">the second param (fitting the T2 descriptor)</param>
        public MyDelayedCaller(Action<T1, T2> target, T1 param1, T2 param2)
        {
            _target = target;
            _param1 = param1;
            _param2 = param2;
        }

        /// <summary>
        /// Invokes the stored method
        /// </summary>
        public void Invoke()
        {
            _target(_param1, _param2);
        }
    }
}
