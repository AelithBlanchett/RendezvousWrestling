using FChatSharpLib.Entities.Plugin;
using System.Collections.Generic;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;

public class BaseFightingGame<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser> : BasePlugin
    where TAchievement : BaseAchievement<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TActionFactory : IActionFactory<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TActiveAction : BaseActiveAction<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TEntityMapper : BaseEntityMapper<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeature : BaseFeature<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeatureFactory : BaseFeatureFactory<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeatureParameters : BaseFeatureParameter<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeatureType : BaseFeatureType, new()
    where TFight : BaseFight<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFighterState : BaseFighterState<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFighterStats : BaseFighterStats<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFightingGame : BaseFightingGame<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TModifier : BaseModifier<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TModifierParameters : BaseModifierParameter<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TModifierType : BaseModifierType, new()
    where TUser : BaseUser<TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
{

    public TFight Fight { get; set; }
    public TFighterState FighterState { get; set; }
    public string DebugImpersonatedCharacter { get; set; }

    public BaseFightingGame() : base(true)
    {

    }

    public BaseFightingGame(string channel) : base(channel)
    {

    }

    public BaseFightingGame(List<string> channels) : base(channels)
    {

    }

    public BaseFightingGame(bool debug) : base(debug)
    {
    }

    public BaseFightingGame(string channel, bool debug = false) : base(channel, debug)
    {
    }

    public BaseFightingGame(IEnumerable<string> channels, bool debug = false) : base(channels, debug)
    {
    }


    public void Initialize()
    {
        this.Fight = new TFight();
        this.Fight.build(this.FChatClient, Channel);
    }

    public bool isInFight(string character, bool displayIfNotInFight = false, bool displayIfInFight = false)
    {
        if (this.isFightGoingOn(character, false, false) || (this.Fight.Fighters != null && this.Fight.Fighters.FindIndex(x => x.Name == character) == -1))
        {
            if (displayIfNotInFight)
            {
                this.FChatClient.SendPrivateMessage("[color=red]There isn't any fight going on, or you're not participating in it.[/color]", character);
            }
            return false;
        }
        else
        {
            if (displayIfInFight)
            {
                this.FChatClient.SendPrivateMessage("[color=red]You're participating in this fight.[/color]", character);
            }
            return true;
        }
    }

    public bool isFightGoingOn(string character, bool displayIfNoFight = false, bool displayIfFight = false)
    {
        var result = false;
        if (this.Fight == null || !this.Fight.hasStarted || this.Fight.hasEnded)
        {
            if (displayIfNoFight)
            {
                this.FChatClient.SendPrivateMessage("[color=red]There isn't any fight going on.[/color]", character);
            }
            result = false;
        }
        else
        {
            if (displayIfFight)
            {
                this.FChatClient.SendPrivateMessage("[color=red]There's already a fight going on.[/color]", character);
            }
            result = true;
        }

        return result;
    }
}

