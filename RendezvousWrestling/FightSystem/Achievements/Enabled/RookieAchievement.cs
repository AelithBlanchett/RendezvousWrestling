using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.Common.Achievements;

namespace RendezvousWrestling.FightSystem.Achievements
{
    public class RookieAchievement : RWAchievement
    {

        public override string DetailedDescription => "Participate in your first fight!";

        public override string Name => UniqueShortName;

        public override int Reward => 4;

        public override string UniqueShortName => "Rookie";

        public override bool MeetsRequirements(RWUser user, RWFighterState activeFighter, RWFight fight)
        {
            var flag = false;
            if(user != null)
            {
                flag = (user.Stats.FightsCount >= 1);
            }
            return flag;
        }
    }
}
