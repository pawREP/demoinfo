using System;
using EHVAG.DemoInfo.StringTables;
using System.Collections.Generic;
using EHVAG.DemoInfo.ValveStructs;
using System.IO;
using EHVAG.DemoInfo.Utils;

namespace EHVAG.DemoInfo.States
{
    public class RawDataState
    {
        public const int MAXPLAYERS = 64;

        public Dictionary<string, StringTable> StringTables { get; private set; }

        public PlayerInfo[] PlayerInfos { get; private set; }

        public RawDataState()
        {
            StringTables = new Dictionary<string, StringTable>();
            PlayerInfos = new PlayerInfo[MAXPLAYERS];
        }

        /// <summary>
        /// Regenerates the player infos from the userinfo stringtable.
        /// </summary>
        public void RegeneratePlayerInfos()
        {
            for (int i = 0; i < PlayerInfos.Length; i++)
            {
                PlayerInfos[i] = null;
            }

            foreach (var PlayerEntry in StringTables["userinfo"].Entries)
            {
                if (PlayerEntry.UserData != null)
                {
                    //Yes, this is the right way
                    int playerid = int.Parse(PlayerEntry.Name);

                    using (MemoryStream ms = new MemoryStream(PlayerEntry.UserData))
                    {
                        ms.Seek(0, System.IO.SeekOrigin.Begin);
                        using (BinaryReader reader = new BinaryReader(ms))
                        {
                            PlayerInfos[playerid] = PlayerInfo.ParseFrom(reader);

                            Util.WriteHexdump(PlayerEntry.UserData, 16);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}

