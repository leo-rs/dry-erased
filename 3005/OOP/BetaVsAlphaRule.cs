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
    class BetaVsAlphaRule : IBattlePlan
    {

        private const long _damageFactor = 8;

        public bool MatchesPlan(Alien good, Alien bad)
        {
            bool colorMatch = good.Color == "red" && bad.Color == "blue";
            return good.IsGood != bad.IsGood && colorMatch;
        }

        public long ComputeDamage(Alien good, Alien bad)
        {
            return (good.Age * _damageFactor/2);
        }
    }
}
