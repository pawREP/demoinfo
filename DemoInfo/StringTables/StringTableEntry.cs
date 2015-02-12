using System;

namespace EHVAG.DemoInfo.StringTables
{
    public class StringTableEntry
    {
        /// <summary>
        /// Gets the index of the StringTable entry
        /// </summary>
        /// <value>The index.</value>
        public int Index { get; internal set; }

        /// <summary>
        /// Gets the name of the entry
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; internal set; }

        /// <summary>
        /// The data accociated with this entry
        /// </summary>
        /// <value>The user data.</value>
        public byte[] UserData { get; internal set; }


        public StringTableEntry()
        {
        }
    }
}

