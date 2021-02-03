namespace RendezvousWrestling.Common.Constants
{
    public class BaseMessages
    {
        public static string startupGuide = @"Note: Any commands written down there are starting with a ! and must be typed without the """".
    It's easy! First, you need to register.
    Just type ""!register"", and your profile will be created.
    You will start with 1 point in every stat: Power, Sensuality, Toughness, Endurance, Dexterity, Willpower.
    The stat system is fixed to 200 available points for the moment, and you can change your stats at any moment.
    An example on how to change your stats: Type: !restat 31,32,29,28,30,50 
    31 here represents your Power, 32 your Sensuality, 29 your Toughness, 28 your Endurance, 30 your Dexterity and 50 your Willpower.
    You must have 200 attributed points in order to start a fight.
    
    Let's get to the stats.

    Power will be used wear out the defender Physically with your strength, reducing their Health
    Sensuality will wear out the defender Sexually
    Toughness will help you resist Physical attacks by increasing your maximum Health
    Endurance will help you resist Sexual attacks, and increasing your Lust and Orgasm Counter
    Dexterity will help your moves to hit, help you to dodge attacks and influence your initiative
    Willpower will help you to keep your focus, and increase your Focus bar’s bounds

    During a fight, your ""health"" is splitted in three bars. Health, Lust, and Focus.
    
    Your overall Health scales with your Toughness.
    Your Lust and Orgasm Counter scales with the Endurance.
    Your Focus bar bounds scales with the Willpower.

    Health works similarly to how Lust does.
    For your health, you will have 3 hearts, each representing a certain amount of HP, depending on your toughness.
    For your lust, the hearts are replaced by the Orgasm Counter, and the HP by LP (Lust Points).
    The Orgasm Counter are the equivalent of hearts.
    
    When you receive an attack, it affects your latest heart. Once your heart's hp gets to zero, it breaks, and the next (with full HP) one takes place.
    Same as the hearts, you will trigger an orgasm when you max your Lust Counter, which will reset back to 0, and removing one orgasm from your Orgasm Counter.
    No Hearts = No More Orgasms = You're out!
    
    The focus works a bit differently: see it as something you need not to be in the 'red'.
    The focus bar bounds go into the negative and the positive. (-30 to 30 for example.)
    You will start at 0 FP (Focus Points).
    In order to stay in the fight, you will have to keep your focus in the green zone, between 0 and 30 in our case.
    Successfully placing an attack or resting will make you gain FP.
    Missing an attack, receiving a hit or being put in a humiliation hold will make you lose FP.
    If you are in the red for 3 consecutive turns, you're considered as too unfocused to continue the fight.
    Of course, in other terms, it could mean: Too submissive to fight, Ahegao, etc.
    
    There is an economy driven around the federation.
    To participate in a fight, you must pay a copper token (10 tokens).
    You start with 10 tokens, enough to participate in a fight.
    If you don't have enough money to participate in a fight, don't worry.
    You can service someone in the room (however they like~), and they'll give you some money in return with ""!tip your_character_name amount_of_tokens"".
    It is encouraged that you do so too, if you happen to be a successful fighter!
    You can also have feats and flaws linked to your character, called Features.
    Most of the features are feats, such as starting with an item before the fight starts (the KickStart feature).
    You can also have non-impacting features, such as the DomSubLover. It simply replaces your focus bar with a submissiveness bar that acts the same.
    Get a complete list of those features with !getfeatureslist.
    
    TLDR: Do ""!register"", then set your 200 points of stats with ""!restat 31,32,29,28,29,51"", then do ""!ready"" to take part in the upcoming fight.
    You can check the command list on the profile.
    Available commands in fight: Brawl, Tease, HighRisk, RiskyLewd, SubHold, HumHold, Bondage, Degradation, ItemPickup, SextoyPickup, StrapToy, Submit, Finisher
    ";
        public static string Ready = "[color=green]{0} is now ready to get it on![/color] ( {1} ---- Required Teams [color=green][b]{2}[/b][/color] ---- Fight Length: {3})\n[sub]Hint: Don't forget you can change these settings with the !fighttype Fight Type, the !teamscount or the !fightlength commands.[/sub]";
        public static string HitMessage = " HIT! ";
        public static string MissMessage = " MISS! ";
        public static string ForcedHoldRelease = "{0} forced {1} to release their hold with this heavy blow!";
        public static string changeMinTeamsInvolvedInFightOK = "int of teams involved in the fight updated!";
        public static string changeMinTeamsInvolvedInFightFail = "The int of teams should be superior or equal than 2.";
        public static string setDiceLess = "The fight is now %susing the dice.";
        public static string setDiceLessFail = "Couldn't drop the dice for this fight, it is already started, or it's already over.";
        public static string SetFightLength = "The fight's pace has been set to {0}";
        public static string setFightLengthFail = "Couldn't change the pace for this fight, it is already started, or it's already over.";
        public static string setFightTypeClassic = "Fight Type successfully set to Classic.";
        public static string setFightTypeTag = "Fight Type successfully set to Tag-Team.";
        public static string setFightTypeLMS = "Fight Type successfully set to Last Man Standing.";
        public static string setFightTypeHMatch = "Fight Type successfully set to Humiliation Match.";
        public static string setFightTypeSexFight = "Fight Type successfully set to SexFight.";
        public static string setFightTypeBondageMatch = "Fight Type successfully set to Bondage Match.";
        public static string setFightTypeSubmission = "Fight Type successfully set to Submission.";
        public static string SetFightTypeNotFound = "Type not found. Fight Type reset to Classic.";
        public static string SetFightTypeFail = "Can't change the fight name if the fight has already started or is already finished.";

        public static string startMatchAnnounce = "[color=green]Everyone's ready, {0} Keep it somewhere if you want to resume it later!  let's start the match![/color] (Match ID)";
        public static string startMatchStageAnnounce = "The fighters will meet in the... [color=red][b]{0}![/b][/color]";
        public static string startMatchFirstPlayer = "{0} starts first for the [color={1}]{2}[/color] team!";
        public static string startMatchFollowedBy = "{0} will follow for the [color={1}]{2}[/color] team.";

        public static string outputStatusInfo = "[b]Turn #{0}[/b] [color={1}]------ {2} team ------[/color] It's [u]{3}[/u]'s turn.\n";

        public static string setCurrentPlayerOK = "Successfully changed {0}'s place with {1}'s!";
        public static string setCurrentPlayerFail = "Couldn't switch the two wrestlers. The name is either wrong, this user is already in the ring or this user isn't able to fight right now.";

        public static string rollAllDiceEchoRoll = "{0} rolled a {1}";

        public static string cantAttackExplanation = "You cannot do that right now: {0}";

        public static string lastActionStillProcessing = "The last action hasn't been processed yet.";
        public static string playerOutOfFight = "You are out of this fight.";
        public static string playerStillInFight = "You are still participating in this fight.";
        public static string playerOutOfRing = "You are not inside the ring.";
        public static string playerOnTheRing = "You are inside the ring.";
        public static string targetOutOfRing = "One of your target(s) isn't inside the ring.";
        public static string targetStillInRing = "One of your target(s) is still inside the ring.";
        public static string tooManyTargets = "You can't target multiple players, this is a single-target attack.";
        public static string targetOutOfFight = "One of your target(s) is out of this fight.";
        public static string targetNotOutOfFight = "One of your target(s) is not out of this fight.";
        public static string stuckInHold = "You're stuck in a hold.";
        public static string mustBeStuckInHold = "You must be stuck in a hold.";
        public static string mustNotBeStuckInHold = "You must not be stuck in a hold.";
        public static string targetMustBeInRange = "Your target(s) must be in range.";
        public static string targetMustBeOffRange = "Your target(s) must be off range.";
        public static string targetMustBeInHold = "Your target(s) must be held in a hold.";
        public static string targetMustNotBeInHold = "Your target(s) must not be held in a hold.";

        public static string cantAddFeatureAlreadyHaveIt = "You already have this feature. You have to wait for it to expire before adding another of the same name.";

        public static string checkAttackRequirementsNotInSexualHold = "You cannot do that since your target is not in a sexual hold.";

        public static string doActionNotActorsTurn = "This isn't your turn.";
        public static string doActionTargetIsSameTeam = "The targets for this action can't be in your team.";
        public static string doActionTargetIsNotSameTeam = "The targets for this action must be in your team.";

        public static string stillActorsTurn = "[b]This is still your turn {0}![/b]";

        public static string targetAlreadyStunned = "Your targets is already stunned, you can't stack the effects.";

        public static string forfeitItemApply = "{0} forfeits! Which means... {1} bondage items landing on them to punish them!";
        public static string forfeitTooManyItems = "{0} has too many items on them to possibly fight! [b][color=red]They're out![/color][/b]";
        public static string forfeitAlreadyOut = "You are already out of the match. No need to give up.";

        public static string tapoutMessage = "{0} couldn't handle it anymore! They SUBMIT!";
        public static string tapoutTooEarly = "You can't tap out right now. Submitting is only allowed after the %sth turn.";

        public static string finishFailMessage = "{0} failed their finisher!";
        public static string finishMessage = "{0} couldn't fight against that! They're out!";

        public static string CheckForDrawOK = "Everybody agrees, it's a draw!";
        public static string CheckForDrawWaiting = "Waiting for the other players still in the fight to call the draw.";
        public static string endFightAnnounce = "{0} team wins the fight!";

        public static string wrongMatchTypeForAction = "You can't {0} in a {1} match.";

        public static string commandError = "[color=red]An error happened: {0}[/color]";
        public static string commandErrorWithStack = "[color=red]An error happened: {0}\n{1}[/color]";

        public static string statChangeSuccessful = "[color=green]You've successfully changed your stats![/color]";
        public static string registerWelcomeMessage = "[color=green]You are now registered! Welcome! Don't forget to read the quickstart guide AND the two collapses under Core Mechanics on [user]Rendezvous Wrestling[/user]'s profile.[/color]";

        public static string errorStatsPrivate = "[color=red]This wrestler's stats are private, or does not exist.[/color]";

        public static string errorAlreadyReady = "[color=red]You are already ready.[/color]";
        public static string errorFightAlreadyInProgress = "[color=red]There is already a fight in progress.[/color]";
        public static string ErrorNotRegistered = "[color=red]You are not registered.[/color]";
        public static string errorRecipientOrSenderNotFound = "[color=red]Either you or the receiver wasn't found in the fighter database.[/color]";
        public static string errorNotEnoughMoney = "[color=red]You don't have enough money. Required: {0}[/color]";
        public static string errorAlreadyRegistered = "[color=red]You are already registered.[/color]";
        public static string ErrorTooManyDefendersForThisCall = "Wrong function call. There are too many targets, this function can only return one.";
    }
}