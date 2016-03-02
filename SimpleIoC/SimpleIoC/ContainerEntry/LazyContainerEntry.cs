using System;

namespace SimpleIoC.ContainerEntry
{
    public class LazyContainerEntry<T> : IContainerEntry<T>, IContainerEntry where T : class
    {
        public LazyContainerEntry(CreateFunc<T> initializer)
        {
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            _initializer = initializer;
            _initialized = false;
            _value = null;
        }

        public T GetValue(IServiceContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (!_initialized)
            {
                _value = _initializer(container);
                _initialized = true;
            }
            return _value;
        }

        Object IContainerEntry.GetValue(IServiceContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            return GetValue(container);
        }

        private readonly CreateFunc<T> _initializer;
        private Boolean _initialized;
        private T _value;
    }
}