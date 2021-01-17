using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Features.Enabled;
using System;
public class RWFeatureFactory : IFeatureFactory<RWAchievement, RWActionFactory, RWActiveAction, RWFeature, RWFeatureFactory, RWFight, RWFighterState, RWModifier, RWUser, RWFeatureParameter>
{

    public RWFeatureFactory()
    {

    }

    public RWFeature getFeature(string featureName, RWUser receiver, int uses, string id = null){
        RWFeature feature = null;

        switch(featureName){
            //case FeatureType.KickStart:
            //    feature = new KickStart(receiver, uses, id);
            //    break;
            case FeatureType.BondageBunny:
                feature = new BondageBunnyFeature(receiver, uses, id);
                break;
            //case FeatureType.CumSlut:
            //    feature = new CumSlut(receiver, uses, id);
            //    break;
            //case FeatureType.RyonaEnthusiast:
            //    feature = new RyonaEnthusiast(receiver, uses, id);
            //    break;
            default:
                feature = null;
                break;
        }

        if(feature == null){
            throw new Exception($"The feature ${featureName} couldn't be initialized. The ${featureName} could be missing in Features.js and/or the ${featureName} isn't present in the features.json file.");
        }
        return feature;
    }

    public string[] getExistingFeatures(){
        return new string[]{ FeatureType.KickStart, FeatureType.RyonaEnthusiast, FeatureType.CumSlut, FeatureType.BondageBunny};
    }
}