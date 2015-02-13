using System;
using EHVAG.DemoInfo.ProtobufMessages;
using System.Reflection;

namespace EHVAG.DemoInfo.DataTables
{
    public class FlattenedPropEntry
    {
        public SendTable.SendProp Prop { get; private set; }
        public SendTable.SendProp ArrayElementProp { get; private set; }
        public string PropertyName { get; private set; }

        internal MethodInfo Setter { get; set; }

        public FlattenedPropEntry(string propertyName, SendTable.SendProp prop, SendTable.SendProp arrayElementProp)
        {
            this.Prop = prop;
            this.ArrayElementProp = arrayElementProp;
            this.PropertyName = propertyName;
        }

        public override string ToString()
        {
            return string.Format("[FlattenedPropEntry: PropertyName={2}, Prop={0}, ArrayElementProp={1}]", Prop, ArrayElementProp, PropertyName);
        }

    }
}

