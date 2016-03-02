using System;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Tests.Utils;

namespace SimpleIoC.Tests
{
    [TestFixture]
    public class ServiceContainerBadArgsTests
    {
        [Test]
        public void BadArgsInResolve()
        {
            // by key
            Assert.Throws<ArgumentNullException>(() => _container.Resolve((Object) null));
            // by name
            Assert.Throws<ArgumentNullException>(() => _container.Resolve((String) null));
            Assert.Throws<ArgumentNullException>(() => _container.Resolve(String.Empty));
            // by type
            Assert.Throws<ArgumentNullException>(() => _container.Resolve((Type) null));
            // by name and type
            Assert.Throws<ArgumentNullException>(() => _container.Resolve<SomeData>((String) null));
            Assert.Throws<ArgumentNullException>(() => _container.Resolve<SomeData>(String.Empty));
            Assert.Throws<ArgumentNullException>(() => _container.Resolve(null, typeof (SomeData)));
            Assert.Throws<ArgumentNullException>(() => _container.Resolve(String.Empty, typeof (SomeData)));
            Assert.Throws<ArgumentNullException>(() => _container.Resolve(Name, null));
            // by predicate
            Assert.Throws<ArgumentNullException>(() => _container.Resolve((Func<Object, Boolean>) null));
            Assert.Throws<ArgumentNullException>(() => _container.Resolve<SomeData>((Func<Object, Boolean>) null));
            Assert.Throws<ArgumentNullException>(() => _container.ResolveEntries(null));
        }

        [Test]
        public void BadArgsInHasComponent()
        {
            // by key
            Assert.Throws<ArgumentNullException>(() => _container.HasComponent((Object) null));
            // by name
            Assert.Throws<ArgumentNullException>(() => _container.HasComponent((String) null));
            Assert.Throws<ArgumentNullException>(() => _container.HasComponent(String.Empty));
            // by type
            Assert.Throws<ArgumentNullException>(() => _container.HasComponent((Type) null));
            // by name and type
            Assert.Throws<ArgumentNullException>(() => _container.HasComponent<SomeData>(null));
            Assert.Throws<ArgumentNullException>(() => _container.HasComponent<SomeData>(String.Empty));
            Assert.Throws<ArgumentNullException>(() => _container.HasComponent(null, typeof (SomeData)));
            Assert.Throws<ArgumentNullException>(() => _container.HasComponent(String.Empty, typeof (SomeData)));
            Assert.Throws<ArgumentNullException>(() => _container.HasComponent(Name, null));
        }

        [Test]
        public void BadArgsInAddComponent()
        {
            // by key
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent((Object) null, _entry));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent(new Object(), null));
            // by name
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent((String) null, _entry));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent(String.Empty, _entry));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent(Name, null));
            // by type
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent((Type) null, _entry));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent<SomeData>(null));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent(typeof (SomeData), null));
            // by name and type
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent<SomeData>(null, _entry));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent<SomeData>(String.Empty, _entry));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent<SomeData>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent(null, typeof (SomeData), _entry));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent(String.Empty, typeof (SomeData), _entry));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent(Name, null, _entry));
            Assert.Throws<ArgumentNullException>(() => _container.AddComponent(Name, typeof (SomeData), null));
        }

        [Test]
        public void BadArgsInRemoveComponent()
        {
            // by key
            Assert.Throws<ArgumentNullException>(() => _container.RemoveComponent((Object) null));
            // by name
            Assert.Throws<ArgumentNullException>(() => _container.RemoveComponent((String) null));
            Assert.Throws<ArgumentNullException>(() => _container.RemoveComponent(String.Empty));
            // by type
            Assert.Throws<ArgumentNullException>(() => _container.RemoveComponent((Type) null));
            // by name and type
            Assert.Throws<ArgumentNullException>(() => _container.RemoveComponent<SomeData>(null));
            Assert.Throws<ArgumentNullException>(() => _container.RemoveComponent<SomeData>(String.Empty));
            Assert.Throws<ArgumentNullException>(() => _container.RemoveComponent(null, typeof (SomeData)));
            Assert.Throws<ArgumentNullException>(() => _container.RemoveComponent(String.Empty, typeof (SomeData)));
            Assert.Throws<ArgumentNullException>(() => _container.RemoveComponent(Name, null));
        }

        [Test]
        public void BadArgsInAddSubContainer()
        {
            Assert.Throws<ArgumentNullException>(() => _container.AddSubContainer(null));
        }

        [Test]
        public void BadArgsInRemoveSubContainer()
        {
            Assert.Throws<ArgumentNullException>(() => _container.RemoveSubContainer(null));
        }

        [Test]
        public void BadArgsInInitialize()
        {
            Assert.Throws<ArgumentNullException>(() => _container.Initialize(null));
        }

        private readonly IServiceContainer _container = new ServiceContainer();
        private readonly IContainerEntry _entry = new SimpleContainerEntry<SomeData>(new SomeData("IDDQD"));

        private const String Name = "IDDQD";
    }
}
