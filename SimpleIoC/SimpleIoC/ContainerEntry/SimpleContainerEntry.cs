using System;

namespace SimpleIoC.ContainerEntry
{
    public class SimpleContainerEntry<T> : IContainerEntry<T>, IContainerEntry where T : class
    {
        public SimpleContainerEntry(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            _value = value;
        }

        public T GetValue(IServiceContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            return _value;
        }

        Object IContainerEntry.GetValue(IServiceContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            return GetValue(container);
        }

        private readonly T _value;
    }
}