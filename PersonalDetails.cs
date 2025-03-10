using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_First_WPF_Proj
{
    internal class PersonalDetails
    {
        public string getCommandString(object commandString) { 
            var s = commandString as string;
            if (s != null)
            {
                return s;
            } else
            {
                throw new Exception("Failed to parse string from object" + commandString.ToString());
            }
        }
    }
}
