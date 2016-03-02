using System;

namespace SimpleIoC.Key
{
    public class NameKey : Tuple<String>
    {
        public NameKey(String name) : base(name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
        }

        public String Name { get { return Item1; } }
    }
}