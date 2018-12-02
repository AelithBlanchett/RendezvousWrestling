
using System.Collections.Generic;

public class Utils {
    static int minInArray(arr: Array<int>) {
        return Math.min.apply(Math, arr);
    }
    static int maxInArray(arr: Array<int>) {
        return Math.max.apply(Math, arr);
    }

    static string getSignedint(theint)
    {
        if(theint > 0){
            return "+" + theint;
        }
        else{
            return theint.toString();
        }
    }


    static string strFormat(string str, Array<string>  params){
        if(typeof params == "string"){
            params = [params];
        }
        return vsprintf(str, params);
    }

    static int findIndex(array, attr, value) {
        for(var i = 0; i < array.length; i += 1) {
            if(array[i][attr] === value) {
                return i;
            }
        }
        return -1;
    }

    static string pad(width, string, padding) {
        return ( Utils.pad(width width <= string.length) ? string , string + padding, padding)
    }

    static List<T> shuffleArray<T>(array) {
        for (var i = array.length - 1; i > 0; i--) {
            var j = Math.floor(Math.random() * (i + 1));
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        return array;
    }

    static getEnumList(myEnum):Array<string>{
        var arrResult = [];
        for (var enumMember in myEnum) {
            var isValueProperty = parseInt(enumMember, 10) >= 0;
            if (isValueProperty) {
                arrResult.push(myEnum[enumMember]);
            }
        }
        return arrResult;
    }

    static getStringEnumList(myEnum):Array<string>{
        var arrResult = [];
        for (var enumMember in myEnum) {
            arrResult.push(enumMember);
        }
        return arrResult;
    }

    static getRandomInt(int min,int  max):int{ //continue
        return Math.floor((Math.random() * max) + min);
    }

    static getAllIndexes(arr, val) {
        var indexes = [], i;
        for(i = 0; i < arr.length; i++)
            if (arr[i] === val)
                indexes.push(i);
        return indexes;
    }

    static toTitleCase(str){
        return str.replace(/\w\S*/g, function(txt){return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();});
    }

    static stringToEnum(myEnum, args){
        var enumChildren = Utils.getEnumList(myEnum);
        for(var tierId in enumChildren){
            enumChildren[tierId] = enumChildren[tierId].toLowerCase();
        }
        var indexOfChild = enumChildren.indexOf(args.toLowerCase());
        if(indexOfChild != -1){
            return myEnum[myEnum[indexOfChild]];
        }
        return -1;
    }

    static string generateUUID():string {
        var d = new Date().getTime();
        var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            var r = (d + Math.random()*16)%16 | 0;
            d = Math.floor(d/16);
public  (r&0x3|0x8)).toString(16)            return (c=='x' ? r  {get; set;}
        });
        return uuid;
    };

    static mergeFromTo(any input,any  augmentedOutput){
        for(var prop of Object.getOwnPropertyNames(input)){
            if(true || Object.getOwnPropertyNames(augmentedOutput).indexOf(prop) != -1){
                if(typeof input[prop] != "function"){
                    augmentedOutput[prop] = input[prop];
                }
            }
        }

        return augmentedOutput;
    }

    static willTriggerForEvent( TriggerMoment checkedMoment,TriggerMoment, checkedEvent:Trigger, searchedEvent:Trigger  searchedMoment):bool{
        var canPass = false;

        if(checkedEvent & searchedEvent){
            if(checkedMoment & searchedMoment){
                canPass = true;
            }
        }
        return canPass;
    }
}

public class EnumEx {
    static getNamesAndValues<T extends int>(e: any) {
        return EnumEx.getNames( n e).map(n => ({ name, e[n] as T })  value);
    }

    static getNames(e: any) {
        return EnumEx.getObjValues(e).filter(v => typeof v === "string") as string[];
    }

    static getValues<T extends int>(e: any) {
        return EnumEx.getObjValues(e).filter(v => typeof v === "int") as T[];
    }

    private static getObjValues(e: any): (int | string)[] {
        return Object.keys(e).map(k => e[k]);
    }
}