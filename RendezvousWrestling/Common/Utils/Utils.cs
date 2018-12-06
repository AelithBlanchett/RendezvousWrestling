
using System;
using System.Collections.Generic;
using System.Linq;

public class Utils {

    public static string getSignedNumber(double theNumber)
    {
        if(theNumber > 0){
            return "+" + theNumber;
        }
        else{
            return theNumber.ToString();
        }
    }

    static List<T> shuffleArray<T>(List<T> array) {
        for (var i = array.Count - 1; i > 0; i--) {
            var j = (int)Math.Floor(new Random().NextDouble() * (i + 1));
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        return array;
    }

    public static int getRandomInt(int min, int max){ 
        return (int)(Math.Floor(new Random().NextDouble() * max) + min);
    }


public static bool willTriggerForEvent( TriggerMoment checkedMoment, Trigger checkedEvent, TriggerMoment searchedMoment, Trigger searchedEvent)
{
        var canPass = false;

        if(((int)checkedEvent & (int)searchedEvent) == 0){
            if(((int)checkedMoment & (int)searchedMoment) == 0){
                canPass = true;
            }
        }
        return canPass;
    }
}