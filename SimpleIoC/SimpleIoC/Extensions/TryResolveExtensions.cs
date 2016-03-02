using System;

namespace SimpleIoC.Extensions
{
    public static class TryResolveExtensions
    {
        public static Object TryResolve(this IServiceContainer container, Object key, Object defaultValue)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            return container.HasComponent(key) ? container.Resolve(key) : defaultValue;
        }

        public static Object TryResolve(this IServiceContainer container, String name, Object defaultValue)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            return container.HasComponent(name) ? container.Resolve(name) : defaultValue;
        }

        public static T TryResolve<T>(this IServiceContainer container, T defaultValue)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            return container.HasComponent<T>() ? container.Resolve<T>() : defaultValue;
        }

        public static Object TryResolve(this IServiceContainer container, Type type, Object defaultValue)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return container.HasComponent(type) ? container.Resolve(type) : defaultValue;
        }

        public static T TryResolve<T>(this IServiceContainer container, String name, T defaultValue)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            return container.HasComponent<T>(name) ? container.Resolve<T>(name) : defaultValue;
        }

        public static Object TryResolve(this IServiceContainer container, String name, Type type, Object defaultValue)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return container.HasComponent(name, type) ? container.Resolve(name, type) : defaultValue;
        }
    }
}
