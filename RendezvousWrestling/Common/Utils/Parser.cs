using System;
using System.Collections.Generic;
using System.Linq;

namespace RendezvousWrestling.Common.Utils
{
    public class Parser
    {


        public static string CheckIfValidStats(IEnumerable<string> strParameters, int intOfRequiredStatPoints, int intOfDifferentStats, int minStatLimit, int maxStatLimit)
        {
            List<int> arrParam = new List<int>();

            var exampleStats = "";
            int intStatsToAssign = (int)Math.Floor(intOfRequiredStatPoints / intOfDifferentStats * 1f);
            int statOverflow = intOfRequiredStatPoints - intStatsToAssign * intOfDifferentStats;

            for (var i = 0; i < intOfDifferentStats - 1; i++)
            {
                exampleStats += intStatsToAssign.ToString() + " ";
            }
            exampleStats += (intStatsToAssign + statOverflow).ToString();

            foreach (var nbr in strParameters)
            {
                if (!int.TryParse(nbr, out var unusedNumber))
                {
                    return $"All the parameters aren't integers ({unusedNumber}). Example: !register {exampleStats}";
                }
                arrParam.Add(int.Parse(nbr));
            }

            if (arrParam.Count != intOfDifferentStats)
            {
                return $"The number of parameters was incorrect. Example: !register {exampleStats}";
            }
            else
            {
                //register
                int total = arrParam.Sum();

                if (total != intOfRequiredStatPoints)
                {
                    return $"The total of stat points you've spent isn't equal to {intOfRequiredStatPoints}. ({total}). Example: !register {exampleStats} (or !restat {exampleStats} if you're already registered)";
                }

                for (var i = 0; i < intOfDifferentStats; i++)
                {
                    if (arrParam[i] > maxStatLimit || arrParam[i] < minStatLimit)
                    {
                        return $"Each stat must be higher than {minStatLimit} and lower than {maxStatLimit}. Example: !register {exampleStats} (or !restat {exampleStats} if you're already registered)";
                    }
                }

                //If it passed all the checks before, all's good
                return "";
            }
        }

        //    public static tipPlayer(args)
        //{
        //public null, amount: -1, message: null}        var result = { player { get; set;}
        //        var splittedArgs = args.split($" ");
        //var amount = 0;

        //if (splittedArgs.Count > 1)
        //{
        //    if (isNaN(splittedArgs[0]) || splittedArgs[0] <= GameSettings.tippingMinimum)
        //    {
        //        result.message = "The specified amount is invalid. It must be a int > ${GameSettings.tippingMinimum}.";
        //        return result;
        //    }
        //    else
        //    {
        //        result.amount = int(splittedArgs[0]);
        //    }

        //    splittedArgs.shift();
        //    result.player = splittedArgs.join($" ");
        //}
        //else
        //{
        //    result.message = "The parameter count is invalid.";
        //    return result;
        //}

        //return result;
        //    }

        //    public static setFightType(args):FightType
        //{
        //    var fightTypes = Utils.getEnumList(FightType);
        //        for(var fightTypeId in fightTypes)
        //    {
        //        fightTypes[fightTypeId] = fightTypes[fightTypeId].ToLower();
        //    }
        //    var indexOfFightType = fightTypes.IndexOf(args.ToLower());
        //    if (indexOfFightType != -1)
        //    {
        //        return FightType[FightType[indexOfFightType]];
        //    }
        //    return -1;
        //}

        //public static setFightLength(args):FightLength
        //{
        //    var fightDurations = Utils.getEnumList(FightLength);
        //        for(var fightTypeId in fightDurations)
        //    {
        //        fightDurations[fightTypeId] = fightDurations[fightTypeId].ToLower();
        //    }
        //    var indexOfFightDuration = fightDurations.IndexOf(args.ToLower());
        //    if (indexOfFightDuration != -1)
        //    {
        //        return FightLength[FightLength[indexOfFightDuration]];
        //    }
        //    return -1;
        //}

        //public static setTeamsCount(args):int
        //{
        //    if (isNaN(args))
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        if (args > GameSettings.intOfAvailableTeams)
        //        {
        //            return -1;
        //        }
        //    }
        //    return int(args);
        //}
    }
}