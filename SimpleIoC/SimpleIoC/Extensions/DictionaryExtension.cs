using System;
using System.Collections.Generic;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Key;

namespace SimpleIoC.Extensions
{
    public static class DictionaryExtension
    {
        public static Boolean AddSimpleValueComponent(this IDictionary<Object, IContainerEntry> entries, String name, Object value)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            NameKey key = new NameKey(name);
            return AddComponent(entries, key, new SimpleContainerEntry(value));
        }

        public static Boolean AddLazyValueComponent(this IDictionary<Object, IContainerEntry> entries, String name, Func<IServiceContainer, Object> initializer)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            NameKey key = new NameKey(name);
            return AddComponent(entries, key, new LazyContainerEntry(initializer));
        }

        public static Boolean AddGeneratorComponent(this IDictionary<Object, IContainerEntry> entries, String name, Func<IServiceContainer, Object> generator)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            NameKey key = new NameKey(name);
            return AddComponent(entries, key, new GeneratorContainerEntry(generator));
        }

        public static Boolean AddSimpleValueComponent<T>(this IDictionary<Object, IContainerEntry> entries, Object value)
        {
            return AddSimpleValueComponent(entries, typeof (T), value);
        }

        public static Boolean AddLazyValueComponent<T>(this IDictionary<Object, IContainerEntry> entries, Func<IServiceContainer, Object> initializer)
        {
            return AddLazyValueComponent(entries, typeof (T), initializer);
        }

        public static Boolean AddGeneratorComponent<T>(this IDictionary<Object, IContainerEntry> entries, Func<IServiceContainer, Object> generator)
        {
            return AddGeneratorComponent(entries, typeof (T), generator);
        }

        public static Boolean AddSimpleValueComponent(this IDictionary<Object, IContainerEntry> entries, Type type, Object value)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            TypeKey key = new TypeKey(type);
            return AddComponent(entries, key, new SimpleContainerEntry(value));
        }

        public static Boolean AddLazyValueComponent(this IDictionary<Object, IContainerEntry> entries, Type type, Func<IServiceContainer, Object> initializer)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            TypeKey key = new TypeKey(type);
            return AddComponent(entries, key, new LazyContainerEntry(initializer));
        }

        public static Boolean AddGeneratorComponent(this IDictionary<Object, IContainerEntry> entries, Type type, Func<IServiceContainer, Object> generator)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            TypeKey key = new TypeKey(type);
            return AddComponent(entries, key, new GeneratorContainerEntry(generator));
        }

        public static Boolean AddSimpleValueComponent<T>(this IDictionary<Object, IContainerEntry> entries, String name, Object value)
        {
            return AddSimpleValueComponent(entries, name, typeof (T), value);
        }

        public static Boolean AddLazyValueComponent<T>(this IDictionary<Object, IContainerEntry> entries, String name, Func<IServiceContainer, Object> initializer)
        {
            return AddLazyValueComponent(entries, name, typeof (T), initializer);
        }

        public static Boolean AddGeneratorComponent<T>(this IDictionary<Object, IContainerEntry> entries, String name, Func<IServiceContainer, Object> generator)
        {
            return AddGeneratorComponent(entries, name, typeof (T), generator);
        }

        public static Boolean AddSimpleValueComponent(this IDictionary<Object, IContainerEntry> entries, String name, Type type, Object value)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (type == null)
                throw new ArgumentNullException("type");
            NameTypeKey key = new NameTypeKey(name, type);
            return AddComponent(entries, key, new SimpleContainerEntry(value));
        }

        public static Boolean AddLazyValueComponent(this IDictionary<Object, IContainerEntry> entries, String name, Type type, Func<IServiceContainer, Object> initializer)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (type == null)
                throw new ArgumentNullException("type");
            NameTypeKey key = new NameTypeKey(name, type);
            return AddComponent(entries, key, new LazyContainerEntry(initializer));
        }

        public static Boolean AddGeneratorComponent(this IDictionary<Object, IContainerEntry> entries, String name, Type type, Func<IServiceContainer, Object> generator)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (type == null)
                throw new ArgumentNullException("type");
            NameTypeKey key = new NameTypeKey(name, type);
            return AddComponent(entries, key, new GeneratorContainerEntry(generator));
        }

        private static Boolean AddComponent(IDictionary<Object, IContainerEntry> entries, Object key, IContainerEntry entry)
        {
            if (entries.ContainsKey(key))
                return false;
            entries.Add(key, entry);
            return true;
        }
    }
}
