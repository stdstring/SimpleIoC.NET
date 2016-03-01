using System;

namespace SimpleIoC.ContainerEntry
{
    public class SimpleContainerEntry : IContainerEntry
    {
        public SimpleContainerEntry(Object value)
        {
            _value = value;
        }

        public Object GetValue(IServiceContainer container)
        {
            return _value;
        }

        private readonly Object _value;
    }
}