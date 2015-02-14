using System;
using System.Runtime.CompilerServices;
using EHVAG.DemoInfo.ProtobufMessages;
using EHVAG.DemoInfo.DataTables;

namespace EHVAG.DemoInfo.Utils
{
    public static partial class Util
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFlagFast(int Property, int Flag)
        {
            return (Property & Flag) == Flag;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFlagFast(int Property, SendPropertyFlags Flag)
        {
            return (Property & (int)Flag) == (int)Flag;
        }
    }
}

