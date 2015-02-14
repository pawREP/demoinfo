using System;

namespace EHVAG.DemoInfo.Edicts.Reflection
{
    public class NetworkedVar<T>
    {
        public EntityInformation entity;
        public T Value { get; internal set; }


        public static implicit operator T(NetworkedVar<T> d)
        {
            return d.Value;
        }
    }
}

