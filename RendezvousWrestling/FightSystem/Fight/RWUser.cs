using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RWUser : BaseUser<RWAchievement, RWActionFactory, RWActiveAction, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestling, RWModifier, RWModifierParameters, RWModifierType, RWUser>
{


    public int dexterity { get; set; } = 1;
    public int power { get; set; } = 1;
    public int sensuality { get; set; } = 1;
    public int toughness { get; set; } = 1;
    public int endurance { get; set; } = 1;
    public int willpower { get; set; } = 1;


    public override void saveTokenTransaction(string idFighter, int amount, TransactionType type, string fromFighter = null)
    {
        return;
    }

    public RWUser() : base()
    {

    }

    public RWUser(string name) : base(name)
    {

        this.toughness = 1;
        this.toughness = 1;
        this.endurance = 1;
        this.willpower = 1;
        this.sensuality = 1;
        this.power = 1;
        this.dexterity = 1;
    }

    public override void restat(List<int> statArray)
    {
        for (var i = 0; i < statArray.Count; i++)
        {
            //this[Stats[i]] = statArray[i];
            //TODO 
        }
    }

    public override string outputStats()
    {
        return $"[b]{this.Id}[/b]'s stats\n" +
            $"[b][color=red]Power[/color][/b]:  {this.power}\n" +
            $"[b][color=purple]Sensuality[/color][/b]:  {this.sensuality}\n" +
            $"[b][color=orange]Toughness[/color][/b]: {this.toughness}\n" +
            $"[b][color=cyan]Endurance[/color][/b]: {this.endurance}      [b][color=green]Win[/color]/[color=red]Loss[/color] record[/b]: { this.Stats.wins } - { this.Stats.losses }\n" +
            $"[b][color=green]Dexterity[/color][/b]: {this.dexterity}\n" +
            $"[b][color=brown]Willpower[/color][/b]: {this.willpower}      [b][color=orange]Tokens[/color][/b]: {this.Tokens}         [b][color=orange]Total spent[/color][/b]: { this.TokensSpent }\n" +
            $"[b][color=red]Features[/color][/b]: [b]{this.getFeaturesList() }[/b]\n" +
            $"[b][color=yellow]Achievements[/color][/b]: [sub]{this.getAchievementsList() }[/sub]\n" +
            $"[b][color= white]Fun stats[/ color][/ b]: [sub]Avg.roll: {this.Stats.averageDiceRoll}, Fav.tag partner: {(this.Stats.favoriteTagPartner != null && this.Stats.favoriteTagPartner != "" ? this.Stats.favoriteTagPartner : "None!")}, Moves done: {this.Stats.actionsCount}, Nemesis: {this.Stats.nemesis}[/sub]";
    }

}