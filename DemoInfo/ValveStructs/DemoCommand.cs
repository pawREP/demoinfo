using System;

namespace EHVAG.DemoInfo.ValveStructs
{
    /// <summary>
    /// The demo-commands as given by Valve.
    /// </summary>
    enum DemoCommand
    {

        /// <summary>
        /// it's a startup message, process as fast as possible
        /// </summary>
        Signon  = 1,
        /// <summary>
        // it's a normal network packet that we stored off
        /// </summary>
        Packet,

        /// <summary>
        /// sync client clock to demo tick
        /// </summary>
        Synctick,

        /// <summary>
        /// Console Command
        /// </summary>
        ConsoleCommand,

        /// <summary>
        /// user input command
        /// </summary>
        UserCommand,

        /// <summary>
        ///  network data tables
        /// </summary>
        DataTables,

        /// <summary>
        /// end of time.
        /// </summary>
        Stop,

        /// <summary>
        /// a blob of binary data understood by a callback function
        /// </summary>
        CustomData,

        StringTables,

        /// <summary>
        /// Last Command
        /// </summary>
        LastCommand = StringTables,

        /// <summary>
        /// First Command
        /// </summary>
        FirstCommand    = Signon
    };
}

