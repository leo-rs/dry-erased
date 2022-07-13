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
    class BattlePlanContext
    {
        private List<IBattlePlan> _battlePlans;

        public BattlePlanContext()
        {
            _battlePlans = new List<IBattlePlan>();
            _battlePlans.Add(new AlphaVsBetaRule());
            _battlePlans.Add(new AlphaVsGammaRule());
            _battlePlans.Add(new BetaVsAlphaRule());
            _battlePlans.Add(new BetaVsGammaRule());
            _battlePlans.Add(new GammaVsAlphaRule());
            _battlePlans.Add(new GammaVsBetaRule());
            _battlePlans.Add(new GoodVsBadRule());
        }

        public void AddBattlePlan(IBattlePlan battlePlan)
        {
            _battlePlans.Add(battlePlan);
        }

        public long ComputeDamage(Alien good, Alien evil)
        {
            long damage = 0;
            foreach (IBattlePlan plan in _battlePlans)
            {

                if (plan.MatchesPlan(good, evil)) 
                {
                    damage = plan.ComputeDamage(good, evil);
                    return damage;
                }
            }

            return damage; 
        }
    }
}
