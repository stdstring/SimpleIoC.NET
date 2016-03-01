using System;

namespace SimpleIoC.ContainerEntry
{
    public class LazyContainerEntry : IContainerEntry
    {
        public LazyContainerEntry(Func<IServiceContainer, Object> initializer)
        {
            _initializer = initializer;
            _initialized = false;
            _value = null;
        }

        public Object GetValue(IServiceContainer container)
        {
            if (!_initialized)
            {
                _value = _initializer(container);
                _initialized = true;
            }
            return _value;
        }

        private readonly Func<IServiceContainer, Object> _initializer;
        private Boolean _initialized;
        private Object _value;
    }
}