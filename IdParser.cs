using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_First_WPF_Proj
{
    public class IdParser
    {
        public static int ParseOccupationIdFromString(string occupationString)
        {
            switch (occupationString)
            {
                case "Miner": return 1;
                case "Dentist": return 2;
                case "Circus Performer": return 3;
            }
            return 0;
        }

        public static int ParseHobbyIdFromString(string hobbyString)
        {
            switch (hobbyString)
            {
                case "Golf": return 1;
                case "Cards": return 2;
                case "Sailing": return 3;
            }
            return 0;

        }

    }

}
