using System;

namespace SimpleIoC.Tests.Services
{
    public class SomeServiceSimple : ISomeService
    {
        public SomeServiceSimple()
        {
            Id = "IDDQD";
        }

        public String Id { get; }
    }
}
