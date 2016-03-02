using System;
using SimpleIoC.ContainerEntry;

namespace SimpleIoC.Extensions
{
    public static class ReplaceExtensions
    {
        public static void ReplaceComponent(this IServiceContainer container, Object key, IContainerEntry entry)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            container.RemoveComponent(key);
            container.AddComponent(key, entry);
        }

        public static void ReplaceComponent(this IServiceContainer container, String name, IContainerEntry entry)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            container.RemoveComponent(name);
            container.AddComponent(name, entry);
        }

        public static void ReplaceComponent<T>(this IServiceContainer container, IContainerEntry entry)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            container.RemoveComponent<T>();
            container.AddComponent<T>(entry);
        }

        public static void ReplaceComponent(this IServiceContainer container, Type type, IContainerEntry entry)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            container.RemoveComponent(type);
            container.AddComponent(type, entry);
        }

        public static void ReplaceComponent<T>(this IServiceContainer container, String name, IContainerEntry entry)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            container.RemoveComponent<T>(name);
            container.AddComponent<T>(name, entry);
        }

        public static void ReplaceComponent(this IServiceContainer container, String name, Type type, IContainerEntry entry)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            container.RemoveComponent(name, type);
            container.AddComponent(name, type, entry);
        }

        public static void ReplaceBySimpleValueComponent(this IServiceContainer container, Object key, Object value)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            ReplaceComponent(container, key, new SimpleContainerEntry<Object>(value));
        }

        public static void ReplaceByLazyValueComponent(this IServiceContainer container, Object key, CreateFunc<Object> initializer)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            ReplaceComponent(container, key, new LazyContainerEntry<Object>(initializer));
        }

        public static void ReplaceByGeneratorComponent(this IServiceContainer container, Object key, CreateFunc<Object> generator)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            ReplaceComponent(container, key, new GeneratorContainerEntry<Object>(generator));
        }

        public static void ReplaceBySimpleValueComponent(this IServiceContainer container, String name, Object value)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            ReplaceComponent(container, name, new SimpleContainerEntry<Object>(value));
        }

        public static void ReplaceByLazyValueComponent(this IServiceContainer container, String name, CreateFunc<Object> initializer)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            ReplaceComponent(container, name, new LazyContainerEntry<Object>(initializer));
        }

        public static void ReplaceByGeneratorComponent(this IServiceContainer container, String name, CreateFunc<Object> generator)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            ReplaceComponent(container, name, new GeneratorContainerEntry<Object>(generator));
        }

        public static void ReplaceBySimpleValueComponent<T>(this IServiceContainer container, T value) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            ReplaceComponent<T>(container, new SimpleContainerEntry<T>(value));
        }

        public static void ReplaceByLazyValueComponent<T>(this IServiceContainer container, CreateFunc<T> initializer) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            ReplaceComponent<T>(container, new LazyContainerEntry<T>(initializer));
        }

        public static void ReplaceByGeneratorComponent<T>(this IServiceContainer container, CreateFunc<T> generator) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            ReplaceComponent<T>(container, new GeneratorContainerEntry<T>(generator));
        }

        public static void ReplaceBySimpleValueComponent(this IServiceContainer container, Type type, Object value)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            ReplaceComponent(container, type, new SimpleContainerEntry<Object>(value));
        }

        public static void ReplaceByLazyValueComponent(this IServiceContainer container, Type type, CreateFunc<Object> initializer)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            ReplaceComponent(container, type, new LazyContainerEntry<Object>(initializer));
        }

        public static void ReplaceByGeneratorComponent(this IServiceContainer container, Type type, CreateFunc<Object> generator)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            ReplaceComponent(container, type, new GeneratorContainerEntry<Object>(generator));
        }

        public static void ReplaceBySimpleValueComponent<T>(this IServiceContainer container, String name, T value) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            ReplaceComponent<T>(container, name, new SimpleContainerEntry<T>(value));
        }

        public static void ReplaceByLazyValueComponent<T>(this IServiceContainer container, String name, CreateFunc<T> initializer) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            ReplaceComponent<T>(container, name, new LazyContainerEntry<T>(initializer));
        }

        public static void ReplaceByGeneratorComponent<T>(this IServiceContainer container, String name, CreateFunc<T> generator) where T : class
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            ReplaceComponent<T>(container, name, new GeneratorContainerEntry<T>(generator));
        }

        public static void ReplaceBySimpleValueComponent(this IServiceContainer container, String name, Type type, Object value)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            ReplaceComponent(container, name, type, new SimpleContainerEntry<Object>(value));
        }

        public static void ReplaceByLazyValueComponent(this IServiceContainer container, String name, Type type, CreateFunc<Object> initializer)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            ReplaceComponent(container, name, type, new LazyContainerEntry<Object>(initializer));
        }

        public static void ReplaceByGeneratorComponent(this IServiceContainer container, String name, Type type, CreateFunc<Object> generator)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            ReplaceComponent(container, name, type, new GeneratorContainerEntry<Object>(generator));
        }
    }
}
