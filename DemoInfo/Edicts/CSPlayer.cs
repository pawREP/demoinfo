using System;
using EHVAG.DemoInfo.Edicts.Reflection;

namespace EHVAG.DemoInfo.Edicts
{
    [ServerClass("CCSPlayer")]
    public class CSPlayer : BaseEntity
    {
        [NetworkedProperty("m_iTeamNum")]
        public NetworkedVar<int> TeamNum { get; set; }

        public CSPlayer()
        {
        }
    }
}

