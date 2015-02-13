using System;
using System.Collections.Generic;

namespace EHVAG.DemoInfo.DataTables
{
    public class ServerClass
    {
        public int ClassID { get; set; }
        public int DataTableID { get; set; }
        public string Name { get; set; }
        public string DTName { get; set; }

        public List<FlattenedPropEntry> FlattenedProps  { get; set; }
        public List<ServerClass> BaseClasses { get; set; }

        public Type EntityType { get; set; }

        public ServerClass()
        {
            FlattenedProps = new List<FlattenedPropEntry>();
            BaseClasses = new List<ServerClass>();
        }
    }
}

