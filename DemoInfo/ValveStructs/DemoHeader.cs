using System;
using EHVAG.DemoInfo.Utils;

namespace EHVAG.DemoInfo.ValveStructs
{
    /// <summary>
    /// The header of any Valve-Demo. 
    /// </summary>
    public class DemoHeader
    {
        /// <summary>
        /// the max length of an path
        /// </summary>
        const int MAX_OSPATH = 260;

        /// <summary>
        /// the demo-protocol-version
        /// </summary>
        public const int DEMO_PROTOCOL = 4;

        public const string FILESTAMP = "HL2DEMO";

        /// <summary>
        /// The first bytes of a demo-file. Should be HL2DEMO
        /// </summary>
        /// <value>The filestamp.</value>
        public string Filestamp { get; private set; }

        /// <summary>
        /// Should be DEMO_PROTICOL, (4 for CS:GO)
        /// </summary>
        /// <value>The protocol.</value>
        public int Protocol { get; private set; }

        /// <summary>
        /// Gets the network protocol version. 
        /// </summary>
        /// <value>The network protocol.</value>
        public int NetworkProtocol { get; private set; }

        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        /// <value>The name of the server.</value>
        public string ServerName { get; private set; }

        /// <summary>
        /// Gets the name of the client  who recorded the game.
        /// </summary>
        /// <value>The name of the client.</value>
        public string ClientName { get; private set; }

        /// <summary>
        /// Gets the name of the map.
        /// </summary>
        /// <value>The name of the map.</value>
        public string MapName { get; private set; }

        /// <summary>
        /// Gets the game directory (Usually "csgo")
        /// </summary>
        /// <value>The game directory.</value>
        public string GameDirectory { get; private set; }

        /// <summary>
        /// Gets the playback time of this demo in seconds.
        /// </summary>
        /// <value>The playback time.</value>
        public float PlaybackTime { get; private set; }

        /// <summary>
        /// Gets the playback ticks. The playback-ticks are how many ticks were 
        /// simulated on the server during the recording of this demo
        /// </summary>
        /// <value>The playback ticks.</value>
        public int PlaybackTicks { get; private set; }

        /// <summary>
        /// Gets the playback frames. The playback-frames are how many ticks are
        /// stored in this demo
        /// </summary>
        /// <value>The playback frames.</value>
        public int PlaybackFrames { get; private set; }         // # of frames in track

        /// <summary>
        /// Gets the length of the signon-data in bytes.
        /// </summary>
        /// <value>The length of the signon.</value>
        public int SignonLength { get; private set; }

        /// <summary>
        /// Parses a DemoHeader from a IBitStream
        /// </summary>
        /// <returns>The from.</returns>
        /// <param name="reader">Reader.</param>
        internal static DemoHeader ParseFrom(IBitStream reader)
        {
            return new DemoHeader() {
                Filestamp = reader.ReadCString(8),
                Protocol = reader.ReadSignedInt(32),
                NetworkProtocol = reader.ReadSignedInt(32),
                ServerName = reader.ReadCString(MAX_OSPATH),

                ClientName = reader.ReadCString(MAX_OSPATH),
                MapName = reader.ReadCString(MAX_OSPATH),
                GameDirectory = reader.ReadCString(MAX_OSPATH),
                PlaybackTime = reader.ReadFloat(),

                PlaybackTicks = reader.ReadSignedInt(32),
                PlaybackFrames = reader.ReadSignedInt(32),
                SignonLength = reader.ReadSignedInt(32),
            };
        }

        private DemoHeader ()
        {
            
        }
    }
}

