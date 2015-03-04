using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace Scripting
{
    /// <summary>
    /// Class responsible for controlling cs-script access.  All scripts
    /// are called through procedures contained in this class.
    /// </summary>
    public class ScriptHost
    {
        /*
         * Need methods intended to call any procedure as defined by the 
         * game object scripting property.  Methods for calculating object
         * totals must accept a GameObject argument and return an integer 
         * representing the total item cost.
         */

        /// <summary>
        /// Calculates the total item market value for the specified game object.
        /// </summary>
        /// <param name="ScriptName">The script to call that will calculate the
        /// total market value of the object.</param>
        /// <param name="Object">The game object for which the method should
        /// obtain the market value.</param>
        /// <returns>The total market value.</returns>
        public int GetItemMarketValue(string ScriptName, GameObject Object)
        {
            return 0;
        }
    }
}
