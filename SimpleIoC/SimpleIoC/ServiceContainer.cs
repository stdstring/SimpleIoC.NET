using System;
using System.Collections.Generic;
using System.Linq;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Exceptions;
using SimpleIoC.Key;

namespace SimpleIoC
{
    public class ServiceContainer : IServiceContainer
    {
        public ServiceContainer()
        {
            _containerEntries = new Dictionary<Object, IContainerEntry>();
            _subContainers = new List<IServiceContainer>();
        }

        public Object Resolve(Object key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            Object result = ResolveImpl(key);
            if (result == null)
                throw new ServiceNotFoundException();
            return result;
        }

        public Object Resolve(String name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            Object result = ResolveImpl(new NameKey(name));
            if (result == null)
                throw new ServiceNotFoundException();
            return result;
        }

        public T Resolve<T>()
        {
            return (T) Resolve(typeof (T));
        }

        public Object Resolve(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            Object result = ResolveImpl(new TypeKey(type));
            if (result == null)
                throw new ServiceNotFoundException();
            return result;
        }

        public T Resolve<T>(String name)
        {
            return (T) Resolve(name, typeof (T));
        }

        public Object Resolve(String name, Type type)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (type == null)
                throw new ArgumentNullException("type");
            Object result = ResolveImpl(new NameTypeKey(name, type));
            if (result == null)
                throw new ServiceNotFoundException();
            return result;
        }

        public IList<Object> Resolve(Func<Object, Boolean> keyPredicate)
        {
            IList<IContainerEntry> entries = ResolveEntries(keyPredicate);
            return entries.Select(entry => entry.GetValue(this)).ToList();
        }

        public IList<T> Resolve<T>(Func<Object, Boolean> keyPredicate)
        {
            IList<IContainerEntry> entries = ResolveEntries(keyPredicate);
            return entries.Select(entry => entry.GetValue(this)).OfType<T>().ToList();
        }

        public IList<IContainerEntry> ResolveEntries(Func<Object, Boolean> keyPredicate)
        {
            List<IContainerEntry> result = new List<IContainerEntry>();
            IEnumerable<IContainerEntry> values = _containerEntries.
                Where(entry => keyPredicate(entry.Key)).
                Select(entry => entry.Value);
            result.AddRange(values);
            foreach (IServiceContainer subContainer in _subContainers)
                result.AddRange(subContainer.ResolveEntries(keyPredicate));
            return result;
        }

        public Boolean HasComponent(Object key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (_containerEntries.ContainsKey(key))
                return true;
            foreach (IServiceContainer container in _subContainers)
            {
                if (container.HasComponent(key))
                    return true;
            }
            return false;
        }

        public Boolean HasComponent(String name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            NameKey key = new NameKey(name);
            return HasComponent(key);
        }

        public Boolean HasComponent<T>()
        {
            return HasComponent(typeof (T));
        }

        public Boolean HasComponent(Type type)
        {
            TypeKey key = new TypeKey(type);
            return HasComponent(key);
        }

        public Boolean HasComponent<T>(String name)
        {
            return HasComponent(name, typeof (T));
        }

        public Boolean HasComponent(String name, Type type)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (type == null)
                throw new ArgumentNullException("type");
            NameTypeKey key = new NameTypeKey(name, type);
            return HasComponent(key);
        }

        public void AddComponent(Object key, IContainerEntry entry)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (entry == null)
                throw new ArgumentNullException("entry");
            if (HasComponent(key))
                throw new ServiceAlreadyRegisteredException();
            _containerEntries.Add(key, entry);
        }

        public void AddComponent(String name, IContainerEntry entry)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            AddComponent(new NameKey(name), entry);
        }

        public void AddComponent<T>(IContainerEntry entry)
        {
            AddComponent(typeof (T), entry);
        }

        public void AddComponent(Type type, IContainerEntry entry)
        {
            AddComponent(new TypeKey(type), entry);
        }

        public void AddComponent<T>(String name, IContainerEntry entry)
        {
            AddComponent(name, typeof (T), entry);
        }

        public void AddComponent(String name, Type type, IContainerEntry entry)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (type == null)
                throw new ArgumentNullException("type");
            AddComponent(new NameTypeKey(name, type), entry);
        }

        public void RemoveComponent(Object key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (_containerEntries.Remove(key))
                return;
            foreach (IServiceContainer container in _subContainers)
            {
                if (container.HasComponent(key))
                {
                    container.RemoveComponent(key);
                    return;
                }
            }
        }

        public void RemoveComponent(String name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            RemoveComponent(new NameKey(name));
        }

        public void RemoveComponent<T>()
        {
            RemoveComponent(typeof (T));
        }

        public void RemoveComponent(Type type)
        {
            RemoveComponent(new TypeKey(type));
        }

        public void RemoveComponent<T>(String name)
        {
            RemoveComponent(name, typeof (T));
        }

        public void RemoveComponent(String name, Type type)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (type == null)
                throw new ArgumentNullException("type");
            RemoveComponent(new NameTypeKey(name, type));
        }

        public void AddSubContainer(IServiceContainer container)
        {
            _subContainers.Add(container);
        }

        public void RemoveSubContainer(IServiceContainer container)
        {
            _subContainers.Remove(container);
        }

        public void Clear()
        {
            _containerEntries.Clear();
            foreach (IServiceContainer container in _subContainers)
                container.Clear();
        }

        public void Initialize(Action<IServiceContainer> initializer)
        {
            initializer(this);
        }

        private Object ResolveImpl(Object key)
        {
            IContainerEntry entry;
            if (_containerEntries.TryGetValue(key, out entry))
                return entry.GetValue(this);
            foreach (IServiceContainer container in _subContainers)
            {
                if (container.HasComponent(key))
                    return container.Resolve(key);
            }
            return null;
        }

        private readonly IDictionary<Object, IContainerEntry> _containerEntries;
        private readonly IList<IServiceContainer> _subContainers;
    }
}
