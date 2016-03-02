using System;

namespace SimpleIoC.ContainerEntry
{
    public interface IContainerEntry
    {
        Object GetValue(IServiceContainer container);
    }

    public interface IContainerEntry<out T> where T : class
    {
        T GetValue(IServiceContainer container);
    }
}