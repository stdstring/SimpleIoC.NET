using System;

namespace SimpleIoC.Tests.Services
{
    public class SomeServiceComplex : ISomeService
    {
        public SomeServiceComplex(String name, Int32 index)
        {
            Id = $"{name}.{index}";
        }

        public String Id { get; }
    }
}
