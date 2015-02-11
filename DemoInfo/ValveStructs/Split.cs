using System;
using EHVAG.DemoInfo.Utils;

namespace EHVAG.DemoInfo.ValveStructs
{
    class Split
    {
        const int FDEMO_NORMAL = 0, FDEMO_USE_ORIGIN2 = 1, FDEMO_USE_ANGLES2 = 2, FDEMO_NOINTERP = 4;

        public int Flags { get; private set; }
        public Vector viewOrigin { get; private set; }
        public QAngle viewAngles { get; private set; }
        public QAngle localViewAngles { get; private set; }

        public Vector viewOrigin2 { get; private set; }
        public QAngle viewAngles2 { get; private set; }
        public QAngle localViewAngles2 { get; private set; }

        public Vector ViewOrigin { get { return (Flags & FDEMO_USE_ORIGIN2) != 0 ? viewOrigin2 : viewOrigin;  }}

        public QAngle ViewAngles { get { return (Flags & FDEMO_USE_ANGLES2) != 0 ? viewAngles2 : viewAngles;   }}

        public QAngle LocalViewAngles { get { return (Flags & FDEMO_USE_ANGLES2) != 0 ? localViewAngles2 : localViewAngles; }}

        public static Split Parse(IBitStream reader)
        {
            return new Split
            {
                Flags = reader.ReadSignedInt(32),
                viewOrigin = Vector.Parse(reader),
                viewAngles = QAngle.Parse(reader),
                localViewAngles = QAngle.Parse(reader),

                viewOrigin2 = Vector.Parse(reader),
                viewAngles2 = QAngle.Parse(reader),
                localViewAngles2 = QAngle.Parse(reader),
            };
        }
    }
}

