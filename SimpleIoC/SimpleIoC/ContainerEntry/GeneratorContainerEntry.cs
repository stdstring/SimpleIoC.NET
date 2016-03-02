using System;

namespace SimpleIoC.ContainerEntry
{
    public class GeneratorContainerEntry<T> : IContainerEntry<T>, IContainerEntry where T : class
    {
        public GeneratorContainerEntry(CreateFunc<T> generator)
        {
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            _generator = generator;
        }

        public T GetValue(IServiceContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            return _generator(container);
        }

        Object IContainerEntry.GetValue(IServiceContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            return GetValue(container);
        }

        private readonly CreateFunc<T> _generator;
    }
}