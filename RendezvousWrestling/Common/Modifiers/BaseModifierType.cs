using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendezvousWrestling.Common.Modifiers
{
    public abstract class BaseModifierType
    {
        //public static BaseModifierType Author { get; } = new BaseModifierType(0, typeof(TestBase));

        public int Value { get; private set; }
        public Type MatchingType { get; private set; }

        public BaseModifierType(int val, Type type)
        {
            Value = val;
            MatchingType = type;
        }

        public static IEnumerable<BaseModifierType> List()
        {
            //return new[] { Author };
            return Array.Empty<BaseModifierType>();
        }

        public static BaseModifierType FromString(string modifierTypeString)
        {
            return List().Single(r => string.Equals(r.MatchingType.Name, modifierTypeString, StringComparison.OrdinalIgnoreCase));
        }

        public static BaseModifierType FromValue(int value)
        {
            return List().Single(r => r.Value == value);
        }
    }
}
