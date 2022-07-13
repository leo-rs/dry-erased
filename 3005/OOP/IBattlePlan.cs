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
    interface IBattlePlan
    {

        bool MatchesPlan(Alien good, Alien bad);
        long ComputeDamage(Alien good, Alien bad);

    }
}
