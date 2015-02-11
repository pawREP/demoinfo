using System;
using EHVAG.DemoInfo.Utils;

namespace EHVAG.DemoInfo.ValveStructs
{
    class CommandInfo
    {
        public Split[] u { get; private set; }

        public static CommandInfo Parse(IBitStream reader)
        {
            return new CommandInfo 
            {
                u = new Split[2] { Split.Parse(reader), Split.Parse(reader) }
            };
        }
    }
}

