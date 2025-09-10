using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Testbed.Common.Services
{
    public class CommonService
    {
        public CommonService(){}

        /// <summary>
        /// Returns a list of all subClasses of a given parentClass
        /// </summary>
        /// <param name="parentClass">The parent class you're looking for children of</param>
        /// <param name="assemblyPartialName">OPTIONAL: if included, will filter the assemblies by <paramref name="assemblyPartialName"/>. If not included, will search ALL assemblies for the given type.</param>
        /// <returns></returns>
        public Type[] GetAllSubClasses(Type parentClass, string assemblyPartialName = "")
        {
            List<Type> returnValue = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //List the assemblies in the current application domain.
            foreach (Assembly assem in assemblies)
            {
                string assemblyName = assem.ToString();
                // search based on the partial or whole name of the assembly passed in
                if (assemblyName.Contains(assemblyPartialName) || assemblyPartialName == string.Empty)
                {
                    foreach (var currentType in assem.GetTypes())
                    {
                        // for each of the types in the assemblies, add it to the return value if it's a subClass of the parent type
                        if (currentType.IsSubclassOf(parentClass))
                        {
                            returnValue.Add(currentType);
                        }
                    }
                }
            }

            return returnValue.ToArray();
        }
    }
}
