using System;

namespace SimpleIoC.Key
{
    public class TypeKey : Tuple<Type>
    {
        public TypeKey(Type type)
            : base(type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
        }

        public Type Type { get { return Item1; } }
    }
}