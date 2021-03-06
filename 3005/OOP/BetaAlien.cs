/* Jan Leo Ras
 * CSCI 3005
 * Assignment 4 - Battle
 * Dr. Dana
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class BetaAlien : Alien
    {

        public BetaAlien(string name, long age, bool isGood) : base(name, "red", age, isGood, null)
        {
        }

        public override string ToString()
        {
            string side = "good";
            if (!IsGood)
                side = "evil";
            return "\"" + Name + "\" (" + Color + " Beta Alien), " + Age + " Years Old, from Planet " + Planet.Name + " [" + side + " Alien]\n";
        }

    }
}
