using System;

namespace SimpleIoC.ContainerEntry
{
    public class GeneratorContainerEntry : IContainerEntry
    {
        public GeneratorContainerEntry(Func<IServiceContainer, Object> generator)
        {
            _generator = generator;
        }

        public Object GetValue(IServiceContainer container)
        {
            return _generator(container);
        }

        private readonly Func<IServiceContainer, Object> _generator;
    }
}