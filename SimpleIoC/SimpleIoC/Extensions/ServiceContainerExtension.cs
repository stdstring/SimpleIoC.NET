using System;
using SimpleIoC.ContainerEntry;

namespace SimpleIoC.Extensions
{
    public static class ServiceContainerExtension
    {
        public static void AddSimpleValueComponent(this IServiceContainer container, String name, Object value)
        {
            container.AddComponent(name, new SimpleContainerEntry(value));
        }

        public static void AddLazyValueComponent(this IServiceContainer container, String name, Func<IServiceContainer, Object> initializer)
        {
            container.AddComponent(name, new LazyContainerEntry(initializer));
        }

        public static void AddGeneratorComponent(this IServiceContainer container, String name, Func<IServiceContainer, Object> generator)
        {
            container.AddComponent(name, new GeneratorContainerEntry(generator));
        }

        public static void AddSimpleValueComponent<T>(this IServiceContainer container, Object value)
        {
            container.AddComponent<T>(new SimpleContainerEntry(value));
        }

        public static void AddLazyValueComponent<T>(this IServiceContainer container, Func<IServiceContainer, Object> initializer)
        {
            container.AddComponent<T>(new LazyContainerEntry(initializer));
        }

        public static void AddGeneratorComponent<T>(this IServiceContainer container, Func<IServiceContainer, Object> generator)
        {
            container.AddComponent<T>(new GeneratorContainerEntry(generator));
        }

        public static void AddSimpleValueComponent(this IServiceContainer container, Type type, Object value)
        {
            container.AddComponent(type, new SimpleContainerEntry(value));
        }

        public static void AddLazyValueComponent(this IServiceContainer container, Type type, Func<IServiceContainer, Object> initializer)
        {
            container.AddComponent(type, new LazyContainerEntry(initializer));
        }

        public static void AddGeneratorComponent(this IServiceContainer container, Type type, Func<IServiceContainer, Object> generator)
        {
            container.AddComponent(type, new GeneratorContainerEntry(generator));
        }

        public static void AddSimpleValueComponent<T>(this IServiceContainer container, String name, Object value)
        {
            container.AddComponent<T>(name, new SimpleContainerEntry(value));
        }

        public static void AddLazyValueComponent<T>(this IServiceContainer container, String name, Func<IServiceContainer, Object> initializer)
        {
            container.AddComponent<T>(name, new LazyContainerEntry(initializer));
        }

        public static void AddGeneratorComponent<T>(this IServiceContainer container, String name, Func<IServiceContainer, Object> generator)
        {
            container.AddComponent<T>(name, new GeneratorContainerEntry(generator));
        }

        public static void AddSimpleValueComponent(this IServiceContainer container, String name, Type type, Object value)
        {
            container.AddComponent(name, type, new SimpleContainerEntry(value));
        }

        public static void AddLazyValueComponent(this IServiceContainer container, String name, Type type, Func<IServiceContainer, Object> initializer)
        {
            container.AddComponent(name, type, new LazyContainerEntry(initializer));
        }

        public static void AddGeneratorComponent(this IServiceContainer container, String name, Type type, Func<IServiceContainer, Object> generator)
        {
            container.AddComponent(name, type, new GeneratorContainerEntry(generator));
        }
    }
}
