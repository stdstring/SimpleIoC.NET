using System;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Tests.Utils;

namespace SimpleIoC.Tests
{
    [TestFixture]
    public class ServiceContainerRemoveComponentTests
    {
        [SetUp]
        public void SetUp()
        {
            _singleContainer = new ServiceContainer();
            _mainContainer = new ServiceContainer();
            _subContainer1 = new ServiceContainer();
            _subContainer2 = new ServiceContainer();
            _innerSubContainer = new ServiceContainer();
            _mainContainer.AddSubContainer(_subContainer1);
            _mainContainer.AddSubContainer(_subContainer2);
            _subContainer1.AddSubContainer(_innerSubContainer);
        }

        [Test]
        public void TestSingleContainerRemoveComponentByKey()
        {
            _singleContainer.AddComponent(_key, _entry);
            _singleContainer.AddComponent(_otherKey, new SimpleContainerEntry<String>(OtherEntryValue));
            RemoveComponent(_key, _singleContainer, _singleContainer, true, false);
            RemoveComponent(_key, _singleContainer, _singleContainer, false, false);
            Assert.IsTrue(_singleContainer.HasComponent(_otherKey));
        }

        [Test]
        public void TestRemoveComponentByKey()
        {
            _subContainer1.AddComponent(_key, _entry);
            _subContainer1.AddComponent(_otherKey, new SimpleContainerEntry<String>(OtherEntryValue));
            RemoveComponent(_key, _subContainer2, _mainContainer, true, true);
            RemoveComponent(_key, _innerSubContainer, _mainContainer, true, true);
            RemoveComponent(_key, _subContainer1, _mainContainer, true, false);
            RemoveComponent(_key, _subContainer1, _mainContainer, false, false);
            RemoveComponent(_otherKey, _mainContainer, _mainContainer, true, false);
        }

        [Test]
        public void TestSingleContainerRemoveComponentByName()
        {
            _singleContainer.AddComponent(Name, _entry);
            _singleContainer.AddComponent(OtherName, new SimpleContainerEntry<String>(OtherEntryValue));
            RemoveComponent(Name, _singleContainer, _singleContainer, true, false);
            RemoveComponent(Name, _singleContainer, _singleContainer, false, false);
            Assert.IsTrue(_singleContainer.HasComponent(OtherName));
        }

        [Test]
        public void TestRemoveComponentByName()
        {
            _subContainer1.AddComponent(Name, _entry);
            _subContainer1.AddComponent(OtherName, new SimpleContainerEntry<String>(OtherEntryValue));
            RemoveComponent(Name, _subContainer2, _mainContainer, true, true);
            RemoveComponent(Name, _innerSubContainer, _mainContainer, true, true);
            RemoveComponent(Name, _subContainer1, _mainContainer, true, false);
            RemoveComponent(Name, _subContainer1, _mainContainer, false, false);
            RemoveComponent(OtherName, _mainContainer, _mainContainer, true, false);
        }

        [Test]
        public void TestSingleContainerRemoveComponentByType()
        {
            _singleContainer.AddComponent<String>(_entry);
            _singleContainer.AddComponent<SomeData>(new SimpleContainerEntry<SomeData>(new SomeData(OtherEntryValue)));
            RemoveComponent<String>(_singleContainer, _singleContainer, true, false);
            RemoveComponent<String>(_singleContainer, _singleContainer, false, false);
            Assert.IsTrue(_singleContainer.HasComponent<SomeData>());
        }

        [Test]
        public void TestRemoveComponentByType()
        {
            _subContainer1.AddComponent<String>(_entry);
            _subContainer1.AddComponent<SomeData>(new SimpleContainerEntry<SomeData>(new SomeData(OtherEntryValue)));
            RemoveComponent<String>(_subContainer2, _mainContainer, true, true);
            RemoveComponent<String>(_innerSubContainer, _mainContainer, true, true);
            RemoveComponent<String>(_subContainer1, _mainContainer, true, false);
            RemoveComponent<String>(_subContainer1, _mainContainer, false, false);
            RemoveComponent<SomeData>(_mainContainer, _mainContainer, true, false);
        }

        [Test]
        public void TestRemoveComponentByTypeMethodEquality()
        {
            Assert.DoesNotThrow(() => _singleContainer.AddComponent<String>(_entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>());
            Assert.DoesNotThrow(() => _singleContainer.RemoveComponent<String>());
            Assert.DoesNotThrow(() => _singleContainer.RemoveComponent<String>());
            Assert.IsFalse(_singleContainer.HasComponent<String>());
            Assert.DoesNotThrow(() => _singleContainer.AddComponent<String>(_entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>());
            Assert.DoesNotThrow(() => _singleContainer.RemoveComponent(typeof(String)));
            Assert.DoesNotThrow(() => _singleContainer.RemoveComponent(typeof(String)));
            Assert.IsFalse(_singleContainer.HasComponent<String>());
        }

        [Test]
        public void TestSingleContainerRemoveComponentByTypeAndName()
        {
            _singleContainer.AddComponent<String>(Name, _entry);
            _singleContainer.AddComponent<String>(OtherName, new SimpleContainerEntry<String>(OtherEntryValue));
            RemoveComponent<String>(Name, _singleContainer, _singleContainer, true, false);
            RemoveComponent<String>(Name, _singleContainer, _singleContainer, false, false);
            Assert.IsTrue(_singleContainer.HasComponent<String>(OtherName));
        }

        [Test]
        public void TestRemoveComponentByTypeAndName()
        {
            _subContainer1.AddComponent<String>(Name, _entry);
            _subContainer1.AddComponent<String>(OtherName, new SimpleContainerEntry<String>(OtherEntryValue));
            RemoveComponent<String>(Name, _subContainer2, _mainContainer, true, true);
            RemoveComponent<String>(Name, _innerSubContainer, _mainContainer, true, true);
            RemoveComponent<String>(Name, _subContainer1, _mainContainer, true, false);
            RemoveComponent<String>(Name, _subContainer1, _mainContainer, false, false);
            RemoveComponent<String>(OtherName, _mainContainer, _mainContainer, true, false);
        }

        [Test]
        public void TestRemoveComponentByTypeAndNameMethodEquality()
        {
            Assert.DoesNotThrow(() => _singleContainer.AddComponent<String>(Name, _entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>(Name));
            Assert.DoesNotThrow(() => _singleContainer.RemoveComponent<String>(Name));
            Assert.DoesNotThrow(() => _singleContainer.RemoveComponent<String>(Name));
            Assert.IsFalse(_singleContainer.HasComponent<String>(Name));
            Assert.DoesNotThrow(() => _singleContainer.AddComponent<String>(Name, _entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>(Name));
            Assert.DoesNotThrow(() => _singleContainer.RemoveComponent(Name, typeof(String)));
            Assert.DoesNotThrow(() => _singleContainer.RemoveComponent(Name, typeof(String)));
            Assert.IsFalse(_singleContainer.HasComponent<String>(Name));
        }

        private void RemoveComponent(OtherKey key, IServiceContainer removeContainer, IServiceContainer searchContainer, Boolean beforeValue, Boolean afterValue)
        {
            Assert.AreEqual(beforeValue, searchContainer.HasComponent(key));
            Assert.DoesNotThrow(() => removeContainer.RemoveComponent(key));
            Assert.AreEqual(afterValue, searchContainer.HasComponent(key));
        }

        private void RemoveComponent(String name, IServiceContainer removeContainer, IServiceContainer searchContainer, Boolean beforeValue, Boolean afterValue)
        {
            Assert.AreEqual(beforeValue, searchContainer.HasComponent(name));
            Assert.DoesNotThrow(() => removeContainer.RemoveComponent(name));
            Assert.AreEqual(afterValue, searchContainer.HasComponent(name));
        }

        private void RemoveComponent<T>(IServiceContainer removeContainer, IServiceContainer searchContainer, Boolean beforeValue, Boolean afterValue)
        {
            Assert.AreEqual(beforeValue, searchContainer.HasComponent<T>());
            Assert.DoesNotThrow(removeContainer.RemoveComponent<T>);
            Assert.AreEqual(afterValue, searchContainer.HasComponent<T>());
        }

        private void RemoveComponent<T>(String name, IServiceContainer removeContainer, IServiceContainer searchContainer, Boolean beforeValue, Boolean afterValue)
        {
            Assert.AreEqual(beforeValue, searchContainer.HasComponent<T>(name));
            Assert.DoesNotThrow(() => removeContainer.RemoveComponent<T>(name));
            Assert.AreEqual(afterValue, searchContainer.HasComponent<T>(name));
        }

        private IServiceContainer _singleContainer;
        private IServiceContainer _mainContainer;
        private IServiceContainer _subContainer1;
        private IServiceContainer _subContainer2;
        private IServiceContainer _innerSubContainer;
        private readonly IContainerEntry _entry = new SimpleContainerEntry<String>(EntryValue);
        private const String EntryValue = "impulse 666";
        private const String OtherEntryValue = "impulse 9";
        // keys
        private readonly OtherKey _key = new OtherKey(666);
        private readonly OtherKey _otherKey = new OtherKey(777);
        // names
        private const String Name = "iddqd";
        private const String OtherName = "idkfa";
    }
}
