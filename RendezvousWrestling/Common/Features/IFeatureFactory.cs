public interface IFeatureFactory {
    BaseFeature getFeature(string featureName, BaseUser receiver, int uses, string id = null);
    string[]  getExistingFeatures();
}