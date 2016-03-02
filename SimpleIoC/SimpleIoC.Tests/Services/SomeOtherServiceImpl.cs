using System;

namespace SimpleIoC.Tests.Services
{
    public class SomeOtherServiceImpl : ISomeOtherService
    {
        public SomeOtherServiceImpl(String id)
        {
            Id = id;
        }

        public String Id { get; }
    }
}
