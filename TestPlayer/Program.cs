using System;
using System.IO;
using EHVAG.DemoInfo;
using EHVAG.DemoInfo.Edicts;

namespace TestPlayer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var stream = File.OpenRead(args[0]);

            DemoParser parser = new DemoParser(stream);

            parser.ParseToEnd();
        }
    }
}
