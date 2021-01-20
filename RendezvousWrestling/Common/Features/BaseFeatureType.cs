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

        public BaseFeatureType(int val, Type type)
        {
            Value = val;
            MatchingType = type;
        }

        public static IEnumerable<BaseFeatureType> List()
        {
            //return new[] { Author };
            return Array.Empty<BaseFeatureType>();
        }

        public static BaseFeatureType FromString(string modifierTypeString)
        {
            return List().Single(r => string.Equals(r.MatchingType.Name, modifierTypeString, StringComparison.OrdinalIgnoreCase));
        }

        public static BaseFeatureType FromValue(int value)
        {
            return List().Single(r => r.Value == value);
        }
    }
}
