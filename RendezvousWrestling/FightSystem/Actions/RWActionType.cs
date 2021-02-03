using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Actions.Enabled;
using System;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWActionType : BaseActionType
    {
        public static RWActionType Pass { get; } = new RWActionType(1000, typeof(ActionPass));

        private static readonly ICollection<RWActionType> _rwFeatures = new List<RWActionType>()
        {
            Pass
        };

        public override ICollection<BaseEntityType> List { get => (ICollection<BaseEntityType>)_rwFeatures; }

        public RWActionType() : base()
        {

        }

        public RWActionType(int value, Type type) : base(value, type)
        {

        }
    }
}
