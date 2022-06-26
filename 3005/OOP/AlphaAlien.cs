/* Jan Leo Ras
 * CSCI 3005
 * Assignment 3 - Aliens in the Galaxy
 * Dr. Dana
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class AlphaAlien : Alien
    {

        public AlphaAlien(string name, long age, bool isGood) : base(name, "blue", age, isGood, null)
        {
        }

        public override string ToString()
        {
            string side = "good";
            if (!IsGood)
                side = "evil";
            return "\"" + Name + "\" (" + Color + " Alpha Alien), " + Age + " Years Old, from Planet " + Planet.Name + " [" + side + " Alien]\n";
        }

    }
}
