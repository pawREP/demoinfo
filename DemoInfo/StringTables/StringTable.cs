using System;
using System.Collections.Generic;
using EHVAG.DemoInfo.Utils;
using System.IO;
using EHVAG.DemoInfo.States;

namespace EHVAG.DemoInfo.StringTables
{
    public class StringTable
    {
        /// <summary>
        /// The name of the StringTable
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// The entries of the StringTable
        /// </summary>
        /// <value>The entries.</value>
        public List<StringTableEntry> Entries { get; internal set; }

        /// <summary>
        /// Clientside data. I'm not exactly sure what this is. 
        /// </summary>
        /// <value>The Clientside data.</value>
        public byte[] ClientData { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EHVAG.DemoInfo.StringTables.StringTable"/> class.
        /// </summary>
        private StringTable()
        {
            Entries = new List<StringTableEntry>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EHVAG.DemoInfo.StringTables.StringTable"/> class.
        /// </summary>
        internal StringTable(string name)  : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// Parses a StringTable
        /// </summary>
        /// <param name="parser">Parser.</param>
        internal static void Parse(DemoParser parser, IBitStream reader)
        {
            string tableName = reader.ReadString();
            int numStrings = (int)reader.ReadInt(16);

            StringTable table = null;

            table = new StringTable(tableName);
            parser.RawData.StringTables.Add(tableName, table);

            for (int i = 0; i < numStrings; i++)
            {
                StringTableEntry entry = new StringTableEntry();

                entry.Name = reader.ReadString();
                entry.Index = i;

                if (entry.Name.Length >= 100)
                    throw new InvalidDataException(
                        "The name of the string is longer than 100 chars, which is forbidden."
                    );

                if (reader.ReadBit())
                {
                    int userDataSize = (int)reader.ReadInt(16);

                    entry.UserData = reader.ReadBytes(userDataSize);
                }

                table.Entries.Add(entry);
            }

            // "Client side stuff" is the official comment by valve
            // I'm not quite sure what it is, but I'd rather save it :)
            if ( reader.ReadBit() )
            {
                int numstrings = (int)reader.ReadInt(16);
                for ( int i = 0 ; i < numstrings; i++ )
                {
                    reader.ReadString(); // stringname

                    if ( reader.ReadBit() )
                    {
                        int userDataSize = ( int )reader.ReadInt(16);

                        table.ClientData = reader.ReadBytes( userDataSize );
                    }
                }
            }
        }

        /// <summary>
        /// Parses a DEM_STRINGTABLES packet, and inserts it into the state
        /// </summary>
        /// <param name="state">State.</param>
        /// <param name="reader">Reader.</param>
        internal static void ParseStringTables(DemoParser parser, IBitStream reader)
        {
            int numTables = reader.ReadByte();

            for (int i = 0; i < numTables; i++) {
                Parse(parser, reader);
            }
        }
    }
}

