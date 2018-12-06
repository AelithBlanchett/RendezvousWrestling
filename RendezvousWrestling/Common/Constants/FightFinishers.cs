
using System;
using System.Linq;

public class FightFinishers {

    public static string[] AvailableFinishers = {
        "Tombstone Piledriver into the mats",
        "Make the loser lick the mats",
        "Smother"
    };

    public static string[] getAll() {
        return FightFinishers.AvailableFinishers;
    }

    public static string pick(){
        var finishers = FightFinishers.getAll();
        return finishers[(int)Math.Floor(new Random().NextDouble() * finishers.Length)];
    }
}

