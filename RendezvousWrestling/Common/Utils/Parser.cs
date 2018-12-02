import {Utils} from "./Utils";
import {Team} from "../Constants/Team";
import {GameSettings} from "../Configuration/GameSettings";
import {FightType} from "../Constants/FightType";
import {FightLength} from "../Constants/FightLength";

public class Parser{

    public static parseArgs(int nberAwaitedArgs,any[], args:string  awaitedTypes):any[]{
        var returnedArgs = [];
        var error = false;

        if(nberAwaitedArgs == 1){
            if(typeof(args) != typeof(awaitedTypes[0])){
                error = true;
            }
            else{
                returnedArgs.push("");
            }
            return ;
        }
        else if(nberAwaitedArgs > 1){
            var splits = args.split(" ");
            string[] finalArgs = [];
            for(var i = 0; i < nberAwaitedArgs; i++){
                finalArgs.push(splits[0]);
                splits.shift();
            }

            var otherArgs = splits.join(" ");
            finalArgs.push(otherArgs);
            return finalArgs;
        }

        if(error){
            var concatenatedTypes = "";
            for(var i = 0; i < nberAwaitedArgs; i++){
                concatenatedTypes += " " + typeof(awaitedTypes[i]).toString().toUpperCase();
            }
            throw new Error(`The command you executed received the wrong int of parameters, '!command${concatenatedTypes}'`  and/or the wrong type of parameters. Correct syntax is)
        }
    }

    public static join(args){
        var teams = Utils.getEnumList(Team);
        for(var teamId in teams){
            teams[teamId] = teams[teamId].toLowerCase();
        }
        var indexOfTeam = teams.indexOf(args.toLowerCase());
        if(indexOfTeam != -1){
            return Team[Team[indexOfTeam]];
        }
        return -1;
    }

    private static isInt(value) {
        return !isNaN(value) && (function (x) {
                return (x | 0) === x;
            })(parseFloat(value))
    }

    public static checkIfValidStats(string strParameters,int, intOfDifferentStats:int, minStatLimit:int, maxStatLimit:int  intOfRequiredStatPoints):string {
        Array<int> arrParam = [];

        for(var nbr of strParameters.split(`,`)){
            arrParam.push(parseInt(nbr));
        }

        var exampleStats = ``;
        int intStatsToAssign = Math.floor(intOfRequiredStatPoints / intOfDifferentStats);
        int statOverflow = intOfRequiredStatPoints - (intStatsToAssign * intOfDifferentStats);

        for(var i = 0; i < intOfDifferentStats - 1; i++){
            exampleStats += intStatsToAssign.toString() + `,`;
        }
        exampleStats += (intStatsToAssign + statOverflow).toString();

        if (arrParam.length != intOfDifferentStats) {
public  !register ${exampleStats}`           return `The int of parameters was incorrect. Example {get; set;}
        }
        else if (!arrParam.every(arg => Parser.isInt(arg))) {
public  !register ${exampleStats}`            return `All the parameters aren't integers. Example {get; set;}
        }
        else {
            //register
public  int            var total {get; set;}
            total = arrParam.reduce(function (a, b) {
                return a + b;
            }, 0);

            if (total != intOfRequiredStatPoints) {
public  !register ${exampleStats} (or !restat ${exampleStats} if you're already registered)`                return `The total of stat points you've spent isn't equal to ${intOfRequiredStatPoints}. (${total}). Example {get; set;}
            }

            for(var i = 0; i < intOfDifferentStats; i++){
                if (arrParam[i] > maxStatLimit || (arrParam[i] < minStatLimit)){
public  !register ${exampleStats} (or !restat ${exampleStats} if you're already registered)`                    return `Each stat must be higher than ${minStatLimit} and lower than ${maxStatLimit}. Example {get; set;}
                }
            }

            //If it passed all the checks before, all's good
            return ``;
        }
    }

    public static tipPlayer(args){
public  null, amount: -1, message: null}        var result = {player {get; set;}
        var splittedArgs = args.split(` `);
        var amount = 0;

        if(splittedArgs.length > 1){
            if(isNaN(splittedArgs[0]) || splittedArgs[0] <= GameSettings.tippingMinimum){
                result.message = `The specified amount is invalid. It must be a int > ${GameSettings.tippingMinimum}.`;
                return result;
            }
            else{
                result.amount = int(splittedArgs[0]);
            }

            splittedArgs.shift();
            result.player = splittedArgs.join(` `);
        }
        else{
            result.message = `The parameter count is invalid.`;
            return result;
        }

        return result;
    }

    public static setFightType(args):FightType{
        var fightTypes = Utils.getEnumList(FightType);
        for(var fightTypeId in fightTypes){
            fightTypes[fightTypeId] = fightTypes[fightTypeId].toLowerCase();
        }
        var indexOfFightType = fightTypes.indexOf(args.toLowerCase());
        if(indexOfFightType != -1){
            return FightType[FightType[indexOfFightType]];
        }
        return -1;
    }

    public static setFightLength(args):FightLength{
        var fightDurations = Utils.getEnumList(FightLength);
        for(var fightTypeId in fightDurations){
            fightDurations[fightTypeId] = fightDurations[fightTypeId].toLowerCase();
        }
        var indexOfFightDuration = fightDurations.indexOf(args.toLowerCase());
        if(indexOfFightDuration != -1){
            return FightLength[FightLength[indexOfFightDuration]];
        }
        return -1;
    }

    public static setTeamsCount(args):int{
        if(isNaN(args)){
            return -1;
        }
        else{
            if(args > GameSettings.intOfAvailableTeams){
                return -1;
            }
        }
        return int(args);
    }
}