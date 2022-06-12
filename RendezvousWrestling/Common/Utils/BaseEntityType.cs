using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RendezvousWrestling.Common.Utils
{
    public abstract class BaseEntityType<T> where T : BaseEntityType<T>
    {
        //public static BaseFeatureType Author { get; } = new BaseFeatureType(0, typeof(TestBase));

        public int Value { get; private set; }
        public Type MatchingType { get; private set; }

        public BaseEntityType()
        {

        }

        public BaseEntityType(int val, Type type)
        {
            Value = val;
            MatchingType = type;
        }

        public abstract ICollection<T> List { get; }

        public T FromString(string modifierTypeString)
        {
            return List.Single(r => string.Equals(r.MatchingType.Name, modifierTypeString, StringComparison.OrdinalIgnoreCase));
        }

        public T FromValue(int value)
        {
            return List.Single(r => r.Value == value);
        }

        public ICollection<string> ListAsString()
        {
            return List.Select(x => x.MatchingType.Name).ToList();
        }
    }
}
