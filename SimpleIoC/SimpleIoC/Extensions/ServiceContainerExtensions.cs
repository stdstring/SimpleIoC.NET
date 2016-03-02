using System;
using SimpleIoC.ContainerEntry;

namespace SimpleIoC.Extensions
{
    public static class ServiceContainerExtensions
    {
        public static void AddSimpleValueComponent(this IServiceContainer container, Object key, Object value)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            container.AddComponent(key, new SimpleContainerEntry<Object>(value));
        }

        public static void AddLazyValueComponent(this IServiceContainer container, Object key, CreateFunc<Object> initializer)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            container.AddComponent(key, new LazyContainerEntry<Object>(initializer));
        }

        public static void AddGeneratorComponent(this IServiceContainer container, Object key, CreateFunc<Object> generator)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            container.AddComponent(key, new GeneratorContainerEntry<Object>(generator));
        }

        public static void AddSimpleValueComponent(this IServiceContainer container, String name, Object value)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            container.AddComponent(name, new SimpleContainerEntry<Object>(value));
        }

        public static void AddLazyValueComponent(this IServiceContainer container, String name, CreateFunc<Object> initializer)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            container.AddComponent(name, new LazyContainerEntry<Object>(initializer));
        }

        public static void AddGeneratorComponent(this IServiceContainer container, String name, CreateFunc<Object> generator)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            container.AddComponent(name, new GeneratorContainerEntry<Object>(generator));
        }

        public static void AddSimpleValueComponent<T>(this IServiceContainer container, T value) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            container.AddComponent<T>(new SimpleContainerEntry<T>(value));
        }

        public static void AddLazyValueComponent<T>(this IServiceContainer container, CreateFunc<T> initializer) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            container.AddComponent<T>(new LazyContainerEntry<T>(initializer));
        }

        public static void AddGeneratorComponent<T>(this IServiceContainer container, CreateFunc<T> generator) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            container.AddComponent<T>(new GeneratorContainerEntry<T>(generator));
        }

        public static void AddSimpleValueComponent(this IServiceContainer container, Type type, Object value)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            container.AddComponent(type, new SimpleContainerEntry<Object>(value));
        }

        public static void AddLazyValueComponent(this IServiceContainer container, Type type, CreateFunc<Object> initializer)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            container.AddComponent(type, new LazyContainerEntry<Object>(initializer));
        }

        public static void AddGeneratorComponent(this IServiceContainer container, Type type, CreateFunc<Object> generator)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            container.AddComponent(type, new GeneratorContainerEntry<Object>(generator));
        }

        public static void AddSimpleValueComponent<T>(this IServiceContainer container, String name, T value) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            container.AddComponent<T>(name, new SimpleContainerEntry<T>(value));
        }

        public static void AddLazyValueComponent<T>(this IServiceContainer container, String name, CreateFunc<T> initializer) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            container.AddComponent<T>(name, new LazyContainerEntry<T>(initializer));
        }

        public static void AddGeneratorComponent<T>(this IServiceContainer container, String name, CreateFunc<T> generator) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            container.AddComponent<T>(name, new GeneratorContainerEntry<T>(generator));
        }

        public static void AddSimpleValueComponent(this IServiceContainer container, String name, Type type, Object value)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            container.AddComponent(name, type, new SimpleContainerEntry<Object>(value));
        }

        public static void AddLazyValueComponent(this IServiceContainer container, String name, Type type, CreateFunc<Object> initializer)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            container.AddComponent(name, type, new LazyContainerEntry<Object>(initializer));
        }

        public static void AddGeneratorComponent(this IServiceContainer container, String name, Type type, CreateFunc<Object> generator)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            container.AddComponent(name, type, new GeneratorContainerEntry<Object>(generator));
        }
    }
}
