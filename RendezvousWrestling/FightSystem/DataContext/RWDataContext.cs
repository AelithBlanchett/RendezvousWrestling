using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.Common.DataContext
{
    public class RWDataContext : BaseDataContext<RWAchievement, RWActionFactory, RWActiveAction, RWFeature, RWFeatureFactory, RWFight, RWFighterState, RWModifier, RWUser, RWFeatureParameter>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase("RW");
    }
}
