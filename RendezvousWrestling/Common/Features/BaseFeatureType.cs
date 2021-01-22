using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendezvousWrestling.Common.Features
{
    public abstract class BaseFeatureType
    {
        //public static BaseFeatureType Author { get; } = new BaseFeatureType(0, typeof(TestBase));

        public int Value { get; private set; }
        public Type MatchingType { get; private set; }

        public BaseFeatureType()
        {

        }

        public BaseFeatureType(int val, Type type)
        {
            Value = val;
            MatchingType = type;
        }

        public abstract ICollection<BaseFeatureType> FeaturesList {get;}

        public BaseFeatureType FromString(string modifierTypeString)
        {
            return FeaturesList.Single(r => string.Equals(r.MatchingType.Name, modifierTypeString, StringComparison.OrdinalIgnoreCase));
        }

        public BaseFeatureType FromValue(int value)
        {
            return FeaturesList.Single(r => r.Value == value);
        }

        public ICollection<string> FeaturesListAsString()
        {
            return FeaturesList.Select(x => x.MatchingType.Name).ToList();
        }
    }
}
