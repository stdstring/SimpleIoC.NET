using System;

namespace SimpleIoC.Tests.Utils
{
    internal class SomeData : Tuple<String>
    {
        public SomeData(String data) : base(data)
        {
        }

        public String Data { get { return Item1; } }
    }
}