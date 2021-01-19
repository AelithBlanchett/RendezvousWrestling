using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.Common.DataContext
{
    public abstract class BaseDataContext<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType> : DbContext
    where TActionFactory : IActionFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFeature : BaseFeature<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFeatureFactory : IFeatureFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TUser : BaseUser<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFight : BaseFight<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFighterState : BaseFighterState<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TActiveAction : BaseActiveAction<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where OptionalParameterType : BaseFeatureParameter<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TAchievement : BaseAchievement<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TModifier : BaseModifier<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFighterStats : BaseFighterStats<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFightingGame : BaseFightingGame<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    {
        public DbSet<TFight> Fights { get; set; }

        public DbSet<TUser> Users { get; set; }

        public DbSet<TFighterState> FighterStates { get; set; }

        public DbSet<TFeature> Features { get; set; }

        //public DbSet<TActiveAction> Actions { get; set; }

        public DbSet<TAchievement> Achievements { get; set; }

        public DbSet<TModifier> Modifiers { get; set; }

        public DbSet<TFighterStats> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TFighterState>()
            .HasOne(p => p.Fight)
            .WithMany(b => b.Fighters);

            modelBuilder.Entity<TModifier>()
            .HasOne(p => p.Receiver)
            .WithMany(b => b.ReceivedModifiers);

            modelBuilder.Entity<TModifier>()
            .HasOne(p => p.Applier)
            .WithMany(b => b.AppliedModifiers);

            modelBuilder.Entity<TFighterState>()
                        .Property(b => b.targets)
                        .HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<List<string>>(v));

            modelBuilder.Entity<TModifier>()
                        .Property(b => b.idParentActions)
                        .HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<List<string>>(v));
        }
    }
}
