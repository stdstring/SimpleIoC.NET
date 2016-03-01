using System;

namespace SimpleIoC.Tests.Utils
{
    internal class OtherKey : Tuple<Int32>
    {
        public OtherKey(Int32 data)
            : base(data)
        {
        }

        public Int32 Data { get { return Item1; } }
    }
}