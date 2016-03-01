using System;

namespace SimpleIoC.Key
{
    public class NameKey : Tuple<String>
    {
        public NameKey(String name) : base(name)
        {
        }

        public String Name { get { return Item1; } }
    }
}