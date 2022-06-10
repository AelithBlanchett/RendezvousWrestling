using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Actions.Enabled;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWActionType : BaseActionType<RWActionType>
    {
        public static RWActionType Pass { get; } = new RWActionType(1000, typeof(ActionPass));

        private static readonly ICollection<RWActionType> _rwActionTypes = new List<RWActionType>()
        {
            Pass
        };

        public override ICollection<RWActionType> List { get => _rwActionTypes; }

        public RWActionType() : base()
        {

        }

        public RWActionType(int value, Type type) : base(value, type)
        {

        }
    }
}
