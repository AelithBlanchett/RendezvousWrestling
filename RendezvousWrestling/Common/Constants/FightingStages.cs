
public class FightingStages {

    static AvailableStages = [
        "The Pit",
        "Wrestling Ring",
        "Arena",
        "Subway",
        "Skyscraper Roof",
        "Forest",
        "Cafe",
        "Street road",
        "Alley",
        "Park",
        "MMA Hexagonal Cage",
        "Hangar",
        "Swamp",
        "Glass Box",
        "Free Space",
        "Magic Shop",
        "Public Restroom",
        "School",
        "Pirate Ship",
        "Baazar",
        "Supermarket",
        "Night Club",
        "Docks",
        "Hospital",
        "Dark Temple",
        "Restaurant Kitchen",
        "Graveyard",
        "Zoo",
        "Slaughterhouse",
        "Junkyard"
    ];

    static getAll():string[]{
        return FightingStages.AvailableStages;
    }

    static pick():string{
        var stages = FightingStages.getAll();
        return stages[Math.floor(Math.random() * stages.length)];
    }
}

