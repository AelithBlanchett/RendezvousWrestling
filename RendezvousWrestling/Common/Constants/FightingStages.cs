
using System;

public class FightingStages {

    public static string[] AvailableStages = {
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
    };

    public static string[] getAll(){
        return FightingStages.AvailableStages;
    }

    public static string pick(){
        var stages = FightingStages.getAll();
        return stages[(int)Math.Floor(new Random().NextDouble() * stages.Count())];
    }
}

