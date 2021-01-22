﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.FightSystem.Features.Enabled
{
    public class BondageBunnyFeature : RWFeature
    {

        public BondageBunnyFeature(RWUser receiver, int uses) : base(receiver, uses)
        {

        }

        public override int getCost()
        {
            return 0;
        }

        public override string applyFeature(TriggerMoment moment, Trigger triggeringEvent, RWFeatureParameter parameters = null)
        {
            return "";
        }
    }
}