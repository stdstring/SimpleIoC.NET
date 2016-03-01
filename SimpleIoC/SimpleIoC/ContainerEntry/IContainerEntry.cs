using System;

namespace SimpleIoC.ContainerEntry
{
    public interface IContainerEntry
    {
        Object GetValue(IServiceContainer container);
    }
}