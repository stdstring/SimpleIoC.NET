using System;

namespace SimpleIoC.Key
{
    public class TypeKey : Tuple<Type>
    {
        public TypeKey(Type type)
            : base(type)
        {
        }

        public Type Type { get { return Item1; } }
    }
}