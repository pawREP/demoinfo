using System;

namespace EHVAG.DemoInfo.Edicts.Reflection
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NetworkedPropertyAttribute : Attribute
    {
        public NetworkedPropertyAttribute(string propertyName)
        {
        }
    }
}

