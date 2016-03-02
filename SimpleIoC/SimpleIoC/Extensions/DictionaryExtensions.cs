using System;
using System.Collections.Generic;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Key;

namespace SimpleIoC.Extensions
{
    public static class DictionaryExtensions
    {
        public static Boolean AddSimpleValueComponent(this IDictionary<Object, IContainerEntry> entries, String name, Object value)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            NameKey key = new NameKey(name);
            return AddComponent(entries, key, new SimpleContainerEntry<Object>(value));
        }

        public static Boolean AddLazyValueComponent(this IDictionary<Object, IContainerEntry> entries, String name, CreateFunc<Object> initializer)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            NameKey key = new NameKey(name);
            return AddComponent(entries, key, new LazyContainerEntry<Object>(initializer));
        }

        public static Boolean AddGeneratorComponent(this IDictionary<Object, IContainerEntry> entries, String name, CreateFunc<Object> generator)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            NameKey key = new NameKey(name);
            return AddComponent(entries, key, new GeneratorContainerEntry<Object>(generator));
        }

        public static Boolean AddSimpleValueComponent<T>(this IDictionary<Object, IContainerEntry> entries, T value) where T : class
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            return AddSimpleValueComponent(entries, typeof (T), value);
        }

        public static Boolean AddLazyValueComponent<T>(this IDictionary<Object, IContainerEntry> entries, CreateFunc<T> initializer) where T : class
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            return AddLazyValueComponent(entries, typeof (T), initializer);
        }

        public static Boolean AddGeneratorComponent<T>(this IDictionary<Object, IContainerEntry> entries, CreateFunc<T> generator) where T : class
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            return AddGeneratorComponent(entries, typeof (T), generator);
        }

        public static Boolean AddSimpleValueComponent(this IDictionary<Object, IContainerEntry> entries, Type type, Object value)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            TypeKey key = new TypeKey(type);
            return AddComponent(entries, key, new SimpleContainerEntry<Object>(value));
        }

        public static Boolean AddLazyValueComponent(this IDictionary<Object, IContainerEntry> entries, Type type, CreateFunc<Object> initializer)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            TypeKey key = new TypeKey(type);
            return AddComponent(entries, key, new LazyContainerEntry<Object>(initializer));
        }

        public static Boolean AddGeneratorComponent(this IDictionary<Object, IContainerEntry> entries, Type type, CreateFunc<Object> generator)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            TypeKey key = new TypeKey(type);
            return AddComponent(entries, key, new GeneratorContainerEntry<Object>(generator));
        }

        public static Boolean AddSimpleValueComponent<T>(this IDictionary<Object, IContainerEntry> entries, String name, T value) where T : class
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            return AddSimpleValueComponent(entries, name, typeof (T), value);
        }

        public static Boolean AddLazyValueComponent<T>(this IDictionary<Object, IContainerEntry> entries, String name, CreateFunc<T> initializer) where T : class
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            return AddLazyValueComponent(entries, name, typeof (T), initializer);
        }

        public static Boolean AddGeneratorComponent<T>(this IDictionary<Object, IContainerEntry> entries, String name, CreateFunc<T> generator) where T : class
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            return AddGeneratorComponent(entries, name, typeof (T), generator);
        }

        public static Boolean AddSimpleValueComponent(this IDictionary<Object, IContainerEntry> entries, String name, Type type, Object value)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            NameTypeKey key = new NameTypeKey(name, type);
            return AddComponent(entries, key, new SimpleContainerEntry<Object>(value));
        }

        public static Boolean AddLazyValueComponent(this IDictionary<Object, IContainerEntry> entries, String name, Type type, CreateFunc<Object> initializer)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));
            NameTypeKey key = new NameTypeKey(name, type);
            return AddComponent(entries, key, new LazyContainerEntry<Object>(initializer));
        }

        public static Boolean AddGeneratorComponent(this IDictionary<Object, IContainerEntry> entries, String name, Type type, CreateFunc<Object> generator)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            NameTypeKey key = new NameTypeKey(name, type);
            return AddComponent(entries, key, new GeneratorContainerEntry<Object>(generator));
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
