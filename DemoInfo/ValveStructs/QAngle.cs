using System;
using EHVAG.DemoInfo.Utils;

namespace EHVAG.DemoInfo.ValveStructs
{
    /// <summary>
    /// And Angle in the Source-Engine. Looks pretty much like a vector. 
    /// </summary>
    class QAngle
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public static QAngle Parse(IBitStream reader)
        {
            return new QAngle
            {
                X = reader.ReadFloat(),
                Y = reader.ReadFloat(),
                Z = reader.ReadFloat(),
            };
        }
    }
}

