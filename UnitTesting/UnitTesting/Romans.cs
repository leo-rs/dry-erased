/* Jan Leo Ras
 * CSCI 3005
 * Assignment 6 - Testing
 * Dr. Dana
 * 7/3/2022
 * This project implements unit testing on the roaming romans problem
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class Romans
    {

        public static void Main() { }

        public static int RoamingRomans(double miles)
        {
            int paces;

            if (miles == 0)
                return 0;
            else
            {
                double result = miles * 1000 * 5280 / 4854;

                if (result % 0.5 == 0)
                    return (int)Math.Floor(result);
                else
                    return (int)Math.Ceiling(result);
            }
        }
    }
}
