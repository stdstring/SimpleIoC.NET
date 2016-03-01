using System;
using System.Collections.Generic;
using SimpleIoC.ContainerEntry;

namespace SimpleIoC
{
    public interface IServiceContainer
    {
        // resolve
        Object Resolve(Object key);
        Object Resolve(String name);
        T Resolve<T>();
        Object Resolve(Type type);
        T Resolve<T>(String name);
        Object Resolve(String name, Type type);
        // resolve by condition
        IList<Object> Resolve(Func<Object, Boolean> keyPredicate);
        IList<T> Resolve<T>(Func<Object, Boolean> keyPredicate);
        // resolve entries by condition
        IList<IContainerEntry> ResolveEntries(Func<Object, Boolean> keyPredicate);
        // has
        Boolean HasComponent(Object key);
        Boolean HasComponent(String name);
        Boolean HasComponent<T>();
        Boolean HasComponent(Type type);
        Boolean HasComponent<T>(String name);
        Boolean HasComponent(String name, Type type);
        // add
        void AddComponent(Object key, IContainerEntry entry);
        void AddComponent(String name, IContainerEntry entry);
        void AddComponent<T>(IContainerEntry entry);
        void AddComponent(Type type, IContainerEntry entry);
        void AddComponent<T>(String name, IContainerEntry entry);
        void AddComponent(String name, Type type, IContainerEntry entry);
        // remove
        void RemoveComponent(Object key);
        void RemoveComponent(String name);
        void RemoveComponent<T>();
        void RemoveComponent(Type type);
        void RemoveComponent<T>(String name);
        void RemoveComponent(String name, Type type);
        // add/remove subcontainers
        void AddSubContainer(IServiceContainer container);
        void RemoveSubContainer(IServiceContainer container);
        // init/clear
        void Clear();
        void Initialize(Action<IServiceContainer> initializer);
    }
}