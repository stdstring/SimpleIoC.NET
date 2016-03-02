using System;

namespace SimpleIoC.Key
{
    public class NameTypeKey : Tuple<String, Type>
    {
        public NameTypeKey(String name, Type type)
            : base(name, type)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
        }

        public String Name { get { return Item1; } }

        public Type Type { get { return Item2; } }
    }
}