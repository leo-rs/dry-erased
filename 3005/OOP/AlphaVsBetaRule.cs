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
    class AlphaVsBetaRule : IBattlePlan
    {
        private const long _damageFactor = 8;

        public bool MatchesPlan(Alien good, Alien bad)
        {
            bool colorMatch = good.Color == "blue" && bad.Color == "red";
            return good.IsGood != bad.IsGood && colorMatch;
        }

        public long ComputeDamage(Alien good, Alien bad)
        {
            return 2 * (good.Age * _damageFactor);
        }

    }
}
