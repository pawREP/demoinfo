using System;
using EHVAG.DemoInfo.StringTables;
using System.Collections.Generic;
using EHVAG.DemoInfo.ValveStructs;
using System.IO;
using EHVAG.DemoInfo.Utils;
using EHVAG.DemoInfo.DataTables;

namespace EHVAG.DemoInfo.States
{
    public class RawDataState
    {
        public const int MAXPLAYERS = 64;

        /// <summary>
        /// Gets the state of the stringtables at this point of the demofile.
        /// The stringtables are mostly serialized blobs of data, somtimes
        /// they also are a string[] (like in the "modelprecache"-table)
        /// </summary>
        /// <value>The string tables.</value>
        public Dictionary<string, StringTable> StringTables { get; private set; }

        /// <summary>
        /// Gets the server classes. The serverclasses are basically a table
        /// that documents what property is networked how. The map networked
        /// data to a class-structure
        /// </summary>
        /// <value>The server classes.</value>
        public List<ServerClass> ServerClasses { get; private set; }

        /// <summary>
        /// Gets the player infos. This array is generated from the "userinfo"-
        /// stringtable. It contains information about each player currently
        /// connected to the server. 
        /// </summary>
        /// <value>The player infos.</value>
        public PlayerInfo[] PlayerInfos { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="EHVAG.DemoInfo.States.RawDataState"/> class.
        /// </summary>
        public RawDataState()
        {
            StringTables = new Dictionary<string, StringTable>();
            ServerClasses = new List<ServerClass>(128); //this is an estimate
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
                    using (BinaryReader reader = new BinaryReader(ms))
                        PlayerInfos[playerid] = PlayerInfo.ParseFrom(reader);
                }
            }
        }
    }
}

