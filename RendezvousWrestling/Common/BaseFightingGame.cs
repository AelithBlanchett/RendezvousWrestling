using FChatSharpLib.Entities.Plugin;
using System.Collections.Generic;

public class BaseFightingGame<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType> : BasePlugin
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
        if (this.isFightGoingOn(character, false, false) || (this.Fight.fighters != null && this.Fight.fighters.FindIndex(x => x.name == character) == -1))
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

