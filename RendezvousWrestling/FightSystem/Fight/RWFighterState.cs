
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Fight;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.Common.Configuration;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Fight
{
    public class RWFighterState : BaseFighterState<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {
        public int Hp { get; set; } = 0;
        public int Lust { get; set; } = 0;
        public int LivesRemaining { get; set; } = 0;
        public int Focus { get; set; } = 0;
        public int ConsecutiveTurnsWithoutFocus { get; set; }

        public int StartingPower { get; set; }
        public int StartingSensuality { get; set; }
        public int StartingToughness { get; set; }
        public int StartingEndurance { get; set; }
        public int StartingDexterity { get; set; }
        public int StartingWillpower { get; set; }
        public int PowerDelta { get; set; }
        public int SensualityDelta { get; set; }
        public int ToughnessDelta { get; set; }
        public int EnduranceDelta { get; set; }
        public int DexterityDelta { get; set; }
        public int WillpowerDelta { get; set; }

        public int HpDamageLastRound { get; set; } = 0;
        public int LpDamageLastRound { get; set; } = 0;
        public int FpDamageLastRound { get; set; } = 0;
        public int HpHealLastRound { get; set; } = 0;
        public int LpHealLastRound { get; set; } = 0;
        public int FpHealLastRound { get; set; } = 0;
        public int HeartsDamageLastRound { get; set; } = 0;
        public int OrgasmsDamageLastRound { get; set; } = 0;
        public int HeartsHealLastRound { get; set; } = 0;
        public int OrgasmsHealLastRound { get; set; } = 0;

        public RWFighterState() : base()
        {

        }

        public RWFighterState(RWFight fight, RWUser user) : base(fight, user)
        {

            StartingToughness = user.Toughness;
            StartingEndurance = user.Endurance;
            StartingWillpower = user.Willpower;
            StartingSensuality = user.Sensuality;
            StartingPower = user.Power;
            StartingDexterity = user.Dexterity;

            Hp = HpPerHeart;
            Lust = 0;
            LivesRemaining = MaxLives;
            Focus = InitialFocus;
            ConsecutiveTurnsWithoutFocus = 0;

            PowerDelta = 0;
            SensualityDelta = 0;
            ToughnessDelta = 0;
            EnduranceDelta = 0;
            DexterityDelta = 0;
            WillpowerDelta = 0;

            HpDamageLastRound = 0;
            LpDamageLastRound = 0;
            FpDamageLastRound = 0;
            HpHealLastRound = 0;
            LpHealLastRound = 0;
            FpHealLastRound = 0;
            HeartsDamageLastRound = 0;
            OrgasmsDamageLastRound = 0;
            HeartsHealLastRound = 0;
            OrgasmsHealLastRound = 0;
        }

        public int InitialFocus => MaxFocus;

        public int MaxFocus => 30 + FocusResistance;

        public decimal TotalHp
        {
            get
            {
                var hp = 130m;
                if (CurrentToughness > 10)
                {
                    hp += CurrentToughness - 10;
                }
                switch (FightDuration)
                {
                    case FightLength.Epic:
                        hp *= 1.33m;
                        break;
                    case FightLength.Long:
                        hp *= 1.00m;
                        break;
                    case FightLength.Medium:
                        hp *= 0.66m;
                        break;
                    case FightLength.Short:
                        hp *= 0.33m;
                        break;
                }
                return hp;
            }
        }

        public int HpPerHeart => (int)Math.Ceiling(TotalHp / MaxLives * 1m);

        public decimal TotalLust
        {
            get
            {
                decimal lust = 130m;
                if (CurrentEndurance > 10)
                {
                    lust += CurrentEndurance - 10;
                }
                switch (FightDuration)
                {
                    case FightLength.Epic:
                        lust *= 1.33m;
                        break;
                    case FightLength.Long:
                        lust *= 1.00m;
                        break;
                    case FightLength.Medium:
                        lust *= 0.66m;
                        break;
                    case FightLength.Short:
                        lust *= 0.33m;
                        break;
                }
                return lust;
            }
        }

        public int LustPerOrgasm => (int)Math.Ceiling(TotalLust / MaxLives * 1m);

        public int MaxLives
        {
            get
            {
                var maxLives = -1;
                switch (FightDuration)
                {
                    case FightLength.Epic:
                        maxLives = 4;
                        break;
                    case FightLength.Long:
                        maxLives = 3;
                        break;
                    case FightLength.Medium:
                        maxLives = 2;
                        break;
                    case FightLength.Short:
                        maxLives = 1;
                        break;
                }
                return maxLives;
            }
        }

        public int MinFocus
        {
            get
            {
                return RWGameSettings.MinFocus;
            }
        }

        public int FocusResistance
        {
            get
            {
                var resistance = 30;
                if (CurrentWillpower > 10)
                {
                    resistance += CurrentWillpower - 10;
                }
                return resistance;
            }
        }

        public int MaxBondageItemsOnSelf
        {
            get
            {
                var maxBondageItemsOnSelf = -1;
                switch (FightDuration)
                {
                    case FightLength.Epic:
                        maxBondageItemsOnSelf = 5;
                        break;
                    case FightLength.Long:
                        maxBondageItemsOnSelf = 4;
                        break;
                    case FightLength.Medium:
                        maxBondageItemsOnSelf = 3;
                        break;
                    case FightLength.Short:
                        maxBondageItemsOnSelf = 2;
                        break;
                }
                return maxBondageItemsOnSelf;
            }
        }

        public string StatsString => $"{User.Power},{User.Sensuality},{User.Toughness},{User.Endurance},{User.Dexterity},{User.Willpower}";

        //fight is "mistakenly" set as optional to be compatible with the super.init
        public override void Initialize(RWFight fight, RWUser user)
        {
            base.Initialize(fight, user);
            StartingToughness = User.Toughness;
            StartingEndurance = User.Endurance;
            StartingWillpower = User.Willpower;
            StartingSensuality = User.Sensuality;
            StartingPower = User.Power;
            StartingDexterity = User.Dexterity;

            Hp = HpPerHeart;
            Lust = 0;
            LivesRemaining = MaxLives;
            Focus = InitialFocus;

            PowerDelta = 0;
            SensualityDelta = 0;
            ToughnessDelta = 0;
            EnduranceDelta = 0;
            DexterityDelta = 0;
            WillpowerDelta = 0;
        }

        public override string ValidateStats()
        {
            var statsInString = StatsString.Split(",");
            return Parser.CheckIfValidStats(statsInString, GameSettings.IntOfRequiredStatPoints, GameSettings.IntOfDifferentStats, GameSettings.MinStatLimit, GameSettings.MaxStatLimit);
        }

        public int CurrentPower
        {
            get
            {
                return StartingPower + PowerDelta;
            }
            set
            {
                PowerDelta += value;
            }

        }


        public int CurrentSensuality
        {
            get
            {
                return StartingSensuality + SensualityDelta;
            }
            set
            {
                SensualityDelta += value;
            }
        }



        public int CurrentToughness
        {
            get
            {
                return StartingToughness + ToughnessDelta;
            }
            set
            {
                ToughnessDelta += value;
            }
        }




        public int CurrentEndurance
        {
            get
            {
                return StartingEndurance + EnduranceDelta;
            }
            set
            {
                EnduranceDelta += value;
            }
        }



        public int CurrentDexterity
        {
            get
            {
                return StartingDexterity + DexterityDelta;
            }
            set
            {
                DexterityDelta += value;
            }
        }



        public int CurrentWillpower
        {
            get
            {
                return StartingWillpower + WillpowerDelta;
            }
            set
            {
                WillpowerDelta += value;
            }
        }



        public int LivesDamageLastRound
        {
            get
            {
                return HeartsDamageLastRound + OrgasmsDamageLastRound;
            }
        }

        public int LivesHealLastRound
        {
            get
            {
                return HeartsHealLastRound + OrgasmsHealLastRound;
            }
        }

        public string RemainingLivesBarDisplay
        {
            get
            {
                var str = "";
                for (var i = 1; i <= MaxLives; i++)
                {
                    if (i < LivesRemaining)
                    {
                        str += "❤️";
                    }
                    else if (i == LivesRemaining)
                    {
                        str += "💓";
                    }
                    else
                    {
                        str += "🖤";
                    }
                }
                return str;
            }
        }

        public override void NextRound()
        {
            base.NextRound();
            HpDamageLastRound = 0;
            LpDamageLastRound = 0;
            FpDamageLastRound = 0;
            HpHealLastRound = 0;
            LpHealLastRound = 0;
            FpHealLastRound = 0;

            HeartsDamageLastRound = 0;
            OrgasmsDamageLastRound = 0;
            HeartsHealLastRound = 0;
            OrgasmsHealLastRound = 0;
        }

        public void HealHP(decimal hp, bool triggerMods = true)
        {
            hp = (int)Math.Floor(hp);
            if (hp < 1)
            {
                hp = 1;
            }
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.Before, TriggerEvent.MainBarHealing);
            }
            if (Hp + hp > HpPerHeart)
            {
                hp = HpPerHeart - Hp; //reduce the int if it overflows the bar
            }
            Hp += (int)hp;
            HpHealLastRound += (int)hp;
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.After, TriggerEvent.MainBarHealing);
            }
        }

        public void HealLP(decimal lust, bool triggerMods = true)
        {
            lust = (int)Math.Floor(lust);
            if (lust < 1)
            {
                lust = 1;
            }
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.Before, TriggerEvent.SecondaryBarHealing);
            }
            if (Lust - lust < 0)
            {
                lust = Lust; //reduce the int if it overflows the bar
            }
            Lust -= (int)lust;
            LpHealLastRound += (int)lust;
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.After, TriggerEvent.SecondaryBarHealing);
            }
        }

        public void HealFP(int focus, bool triggerMods = true)
        {
            focus = (int)Math.Floor(focus * 1m);
            if (focus < 1)
            {
                focus = 1;
            }
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.Before, TriggerEvent.UtilitaryBarHealing);
            }
            if (Focus + focus > MaxFocus)
            {
                focus = MaxFocus - Focus; //reduce the int if it overflows the bar
            }
            Focus += focus;
            FpHealLastRound += focus;
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.After, TriggerEvent.UtilitaryBarHealing);
            }
        }

        public void HitHP(int hp, bool triggerMods = true)
        {
            hp = (int)Math.Floor(hp * 1m);
            if (hp < 1)
            {
                hp = 1;
            }
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.Before, TriggerEvent.MainBarDamage);
            }
            Hp -= hp;
            HpDamageLastRound += hp;
            if (Hp <= 0)
            {
                TriggerMods(TriggerMoment.Before, TriggerEvent.MainBarDepleted);
                Hp = 0;
                //this.heartsRemaining--;
                LivesRemaining--;
                HeartsDamageLastRound += 1;
                Fight.Message.addHit($"[b][color=red]Heart broken![/color][/b] {Name} has {LivesRemaining} lives left.");
                if (LivesRemaining > 0)
                {
                    Hp = HpPerHeart;
                }
                else if (LivesRemaining == 1)
                {
                    Fight.Message.addHit($"[b][color=red]Last life[/color][/b] for {Name}!");
                }
                TriggerMods(TriggerMoment.After, TriggerEvent.MainBarDepleted);
            }
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.After, TriggerEvent.MainBarDamage);
            }
        }

        public void HitLP(int lust, bool triggerMods = true)
        {
            lust = (int)Math.Floor(lust * 1m);
            if (lust < 1)
            {
                lust = 1;
            }
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.Before, TriggerEvent.SecondaryBarDamage);
            }
            Lust += lust;
            LpDamageLastRound += lust;
            if (Lust >= LustPerOrgasm)
            {
                TriggerMods(TriggerMoment.Before, TriggerEvent.SecondaryBarDepleted);
                Lust = 0;
                //this.orgasmsRemaining--;
                LivesRemaining--;
                OrgasmsDamageLastRound += 1;
                Fight.Message.addHit($"[b][color=pink]Orgasm on the mat![/color][/b] {Name} has {LivesRemaining} lives left.");
                Lust = 0;
                if (triggerMods)
                {
                    TriggerMods(TriggerMoment.After, TriggerEvent.SecondaryBarDepleted);
                }
                if (LivesRemaining == 1)
                {
                    Fight.Message.addHit($"[b][color=red]Last life[/color][/b] for {Name}!");
                }
            }
            TriggerMods(TriggerMoment.After, TriggerEvent.SecondaryBarDamage);
        }

        public void HitFP(int focusDamage, bool triggerMods = true)
        {
            if (focusDamage <= 0)
            {
                return;
            }
            focusDamage = (int)Math.Floor(focusDamage * 1m);
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.Before, TriggerEvent.UtilitaryBarDamage);
            }
            Focus -= focusDamage;
            FpDamageLastRound += focusDamage;
            if (triggerMods)
            {
                TriggerMods(TriggerMoment.After, TriggerEvent.UtilitaryBarDamage);
            }
        }

        public bool IsDead(bool displayMessage = false)
        {
            var condition = LivesRemaining == 0;
            if (condition && displayMessage)
            {
                Fight.Message.addHit($"{GetStylizedName()} couldn't take it anymore! They're out!");
            }
            return condition;
        }

        public bool IsSexuallyExhausted(bool displayMessage = false)
        {
            var condition = LivesRemaining == 0;
            if (condition && displayMessage)
            {
                Fight.Message.addHit($"{GetStylizedName()} got wrecked sexually! They're out!");
            }
            return condition;
        }

        public bool IsBroken(bool displayMessage = false)
        {
            var condition = (this.ConsecutiveTurnsWithoutFocus >= RWGameSettings.MaxTurnsWithoutFocus);

            if (condition && displayMessage)
            {
                Fight.Message.addHit($"{GetStylizedName()} got [b]utterly[/b] humiliated! They're out!");
            }
            return condition;
        }

        public bool IsCompletelyBound(bool displayMessage = false)
        {
            var condition = NumBondageItemsOnSelf >= MaxBondageItemsOnSelf;
            if (condition && displayMessage)
            {
                Fight.Message.addHit($"{GetStylizedName()} is completely bound! They're out!");
            }
            return condition;
        }

        public override bool IsTKO
        {
            get
            {
                return Fight.FightType switch
                {
                    FightType.Classic or FightType.Tag => IsSexuallyExhausted()
                                           || IsDead()
                                           || IsBroken()
                                           || IsCompletelyBound(),
                    FightType.LastManStanding => IsDead(),
                    FightType.SexFight => IsSexuallyExhausted(),
                    FightType.Humiliation => IsBroken() || IsCompletelyBound(),
                    FightType.Bondage => IsCompletelyBound(),
                    FightType.Submission => IsDead(),
                    _ => false,
                };
            }
        }

        public override void DisplayTKOMessage()
        {
            if (IsTKO)
            {
                if (IsSexuallyExhausted())
                {
                    Fight.Message.addHit($"{GetStylizedName()} got sexually wrecked! They're out!");
                }
                else if (IsDead())
                {
                    Fight.Message.addHit($"{GetStylizedName()}'s body couldn't take it anymore! They're out!");
                }
                else if (IsBroken())
                {
                    Fight.Message.addHit($"{GetStylizedName()} got [b]utterly[/b] humiliated! They're out!");
                }
                else if (IsCompletelyBound())
                {
                    Fight.Message.addHit($"{GetStylizedName()} is completely bound! They're out!");
                }
            }
        }

        public int NumBondageItemsOnSelf
        {
            get
            {
                var bondageModCount = 0;
                foreach (var mod in Modifiers)
                {
                    if (mod.Type == RWModifierType.Bondage)
                    {
                        bondageModCount++;
                    }
                }
                return bondageModCount;
            }
        }

        public override string OutputStatus()
        {
            //this.User.hasFeature(RWFeatureType.Bondage) >>>>> this.User.hasFeature(RWFeatureType.DomSubLover)
            var nameLine = $"{GetStylizedName()}:";
            var hpLine = $"  [color=yellow]hit points: {Hp}{(HpDamageLastRound > 0 || HpHealLastRound > 0 ? $"{(-HpDamageLastRound + HpHealLastRound < 0 ? "[color=red]" : "[color=green]")} ({RendezvousWrestling.Common.Utils.Utils.GetSignedNumber(-HpDamageLastRound + HpHealLastRound)})[/color]" : "")}|{HpPerHeart}[/color] ";
            var lpLine = $"  [color=pink]lust points: {Lust}{(LpDamageLastRound > 0 || LpHealLastRound > 0 ? $"{ (-LpDamageLastRound + LpHealLastRound < 0 ? "[color=red]" : "[color=green]")} ({RendezvousWrestling.Common.Utils.Utils.GetSignedNumber(LpDamageLastRound - LpHealLastRound)})[/color]" : "")}|{ LustPerOrgasm}[/color] ";
            var livesLine = $"  [color=red]lives: {RemainingLivesBarDisplay}{(OrgasmsDamageLastRound > 0 || OrgasmsHealLastRound > 0 ? $"{ (-OrgasmsDamageLastRound + OrgasmsHealLastRound < 0 ? "[color=red]" : "[color=green]")} ({RendezvousWrestling.Common.Utils.Utils.GetSignedNumber(-OrgasmsDamageLastRound + OrgasmsHealLastRound)} orgasm(s))[/color]" : "")}{ (HeartsDamageLastRound > 0 || HeartsHealLastRound > 0 ? $"{ (-HeartsDamageLastRound + HeartsHealLastRound < 0 ? "[color=red]" : "[color=green]")} ({ RendezvousWrestling.Common.Utils.Utils.GetSignedNumber(-HeartsDamageLastRound + HeartsHealLastRound)} heart(s))[/color]" : "")} ({LivesRemaining}|{MaxLives})[/color] ";
            var focusLine = $"  [color=orange]{(User.HasFeature(RWFeatureType.DomSubLover) ? "submissiveness" : "focus")}:[/color] [b][color={ (Focus <= 0 ? "red" : "orange")}]{Focus}[/color][/b]{((FpDamageLastRound > 0 || FpHealLastRound > 0) && FpDamageLastRound - FpHealLastRound != 0 ? $"{ (-FpDamageLastRound + FpHealLastRound < 0 ? "[color=red]" : "[color=green]")} ({RendezvousWrestling.Common.Utils.Utils.GetSignedNumber(-FpDamageLastRound + FpHealLastRound)})[/color]" : "")}|[color=green]{MaxFocus}[/color]";
            var turnsFocusLine = $"  [color=orange]turns {(User.HasFeature(RWFeatureType.DomSubLover) ? "being too submissive" : "without focus")}: {ConsecutiveTurnsWithoutFocus}|{ RWGameSettings.MaxTurnsWithoutFocus}[/color]";
            var bondageLine = $"  [color=purple]bondage items {NumBondageItemsOnSelf}|{ RWGameSettings.MaxBondageItemsOnSelf}[/color] ";
            var modifiersLine = $"  [color=cyan]affected by: {ActiveModifiersAsString}[/color] ";
            var targetLine = $"  [color=red]target(s): " + (TargetsAsString != null && TargetsAsString.Count > 0 ? $"{ string.Join(", ", TargetsAsString)}" : "None set yet! (!targets charactername)") + "[/color]";

            return $"{nameLine.PadLeft(50, '-')} {hpLine} {lpLine} {livesLine} {focusLine} {turnsFocusLine} {bondageLine} {(ActiveModifiersAsString.Length > 0 ? modifiersLine : "")} {targetLine}";
        }
    }
}