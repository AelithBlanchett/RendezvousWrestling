
public class FightFinishers {

    static AvailableFinishers = [
        "Tombstone Piledriver into the mats",
        "Make the loser lick the mats",
        "Smother"
    ];

    static getAll():string[]{
        return FightFinishers.AvailableFinishers;
    }

    static pick():string{
        var finishers = FightFinishers.getAll();
        return finishers[Math.floor(Math.random() * finishers.length)];
    }
}

