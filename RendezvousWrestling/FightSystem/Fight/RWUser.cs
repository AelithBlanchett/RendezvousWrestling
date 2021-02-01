using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Fight;
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Fight
{
    public class RWUser : BaseUser<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierParameters, RWModifierType, RWUser>
    {


        public int Dexterity { get; set; } = 1;
        public int Power { get; set; } = 1;
        public int Sensuality { get; set; } = 1;
        public int Toughness { get; set; } = 1;
        public int Endurance { get; set; } = 1;
        public int Willpower { get; set; } = 1;


        public override void SaveTokenTransaction(string idFighter, int amount, TransactionType type, string fromFighter = null)
        {
            return;
        }

        public RWUser() : base()
        {

        }

        public RWUser(string name) : base(name)
        {

            Toughness = 1;
            Toughness = 1;
            Endurance = 1;
            Willpower = 1;
            Sensuality = 1;
            Power = 1;
            Dexterity = 1;
        }

        public override void Restat(List<int> statArray)
        {
            for (var i = 0; i < statArray.Count; i++)
            {
                Power = statArray[0];
                Sensuality = statArray[1];
                Toughness = statArray[2];
                Endurance = statArray[3];
                Dexterity = statArray[4];
                Willpower = statArray[5];
            }
        }

        public override string OutputStats()
        {
            return $"[b]{Id}[/b]'s stats\n" +
                $"[b][color=red]Power[/color][/b]:  {Power}\n" +
                $"[b][color=purple]Sensuality[/color][/b]:  {Sensuality}\n" +
                $"[b][color=orange]Toughness[/color][/b]: {Toughness}\n" +
                $"[b][color=cyan]Endurance[/color][/b]: {Endurance}      [b][color=green]Win[/color]/[color=red]Loss[/color] record[/b]: { Stats.wins } - { Stats.losses }\n" +
                $"[b][color=green]Dexterity[/color][/b]: {Dexterity}\n" +
                $"[b][color=brown]Willpower[/color][/b]: {Willpower}      [b][color=orange]Tokens[/color][/b]: {Tokens}         [b][color=orange]Total spent[/color][/b]: { TokensSpent }\n" +
                $"[b][color=red]Features[/color][/b]: [b]{FeaturesAsString }[/b]\n" +
                $"[b][color=yellow]Achievements[/color][/b]: [sub]{AchievementsList }[/sub]\n" +
                $"[b][color=white]Fun stats[/color][/b]: [sub]Avg.roll: {Stats.averageDiceRoll}, Fav.tag partner: {(Stats.favoriteTagPartner != null && Stats.favoriteTagPartner != "" ? Stats.favoriteTagPartner : "None!")}, Moves done: {Stats.actionsCount}, Nemesis: {Stats.nemesis}[/sub]";
        }

    }
}