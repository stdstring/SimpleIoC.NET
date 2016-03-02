using System;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Exceptions;
using SimpleIoC.Tests.Utils;

namespace SimpleIoC.Tests
{
    [TestFixture]
    public class ServiceContainerAddComponentTests
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
        public void TestServiceAlreadyRegisteredException()
        {
            const String serviceWithKeyMessage = "Service with key \"key = 666\" is registered already";
            const String serviceWithNameMessage = "Service with name \"iddqd\" is registered already";
            const String serviceWithTypeMessage = "Service with type \"System.String\" is registered already";
            const String serviceWithNameTypeMessage = "Service with name \"iddqd\" and type \"System.String\" is registered already";
            _singleContainer.AddComponent(_key, new SimpleContainerEntry<String>(EntryValue));
            _singleContainer.AddComponent(Name, new SimpleContainerEntry<String>(EntryValue));
            _singleContainer.AddComponent<String>(new SimpleContainerEntry<String>(EntryValue));
            _singleContainer.AddComponent<String>(Name, new SimpleContainerEntry<String>(EntryValue));
            CheckServiceAlreadyRegisteredException(() => _singleContainer.AddComponent(_key, new SimpleContainerEntry<String>(OtherEntryValue)), serviceWithKeyMessage);
            CheckServiceAlreadyRegisteredException(() => _singleContainer.AddComponent(Name, new SimpleContainerEntry<String>(OtherEntryValue)), serviceWithNameMessage);
            CheckServiceAlreadyRegisteredException(() => _singleContainer.AddComponent<String>(new SimpleContainerEntry<String>(OtherEntryValue)), serviceWithTypeMessage);
            CheckServiceAlreadyRegisteredException(() => _singleContainer.AddComponent<String>(Name, new SimpleContainerEntry<String>(OtherEntryValue)), serviceWithNameTypeMessage);
        }

        [Test]
        public void TestSingleContainerAddComponentByKey()
        {
            _singleContainer.AddComponent(_otherKey, new SimpleContainerEntry<String>(OtherEntryValue));
            AddComponent(_key, _singleContainer, _singleContainer, false, true, true);
            AddComponent(_key, _singleContainer, _singleContainer, true, false, true);
        }

        [Test]
        public void TestAddComponentByKey()
        {
            _innerSubContainer.AddComponent(_otherKey, new SimpleContainerEntry<String>(OtherEntryValue));
            AddComponent(_key, _subContainer1, _mainContainer, false, true, true);
            AddComponent(_key, _subContainer1, _mainContainer, true, false, true);
            AddComponent(_key, _mainContainer, _mainContainer, true, false, true);
            AddComponent(_key, _innerSubContainer, _mainContainer, true, true, true);
        }

        [Test]
        public void TestSingleContainerAddComponentByName()
        {
            _singleContainer.AddComponent(OtherName, new SimpleContainerEntry<String>(OtherEntryValue));
            AddComponent(Name, _singleContainer, _singleContainer, false, true, true);
            AddComponent(Name, _singleContainer, _singleContainer, true, false, true);
        }

        [Test]
        public void TestAddComponentByName()
        {
            _innerSubContainer.AddComponent(OtherName, new SimpleContainerEntry<String>(OtherEntryValue));
            AddComponent(Name, _subContainer1, _mainContainer, false, true, true);
            AddComponent(Name, _subContainer1, _mainContainer, true, false, true);
            AddComponent(Name, _mainContainer, _mainContainer, true, false, true);
            AddComponent(Name, _innerSubContainer, _mainContainer, true, true, true);
        }

        [Test]
        public void TestSingleContainerAddComponentByType()
        {
            _singleContainer.AddComponent<SomeData>(new SimpleContainerEntry<SomeData>(new SomeData(OtherEntryValue)));
            AddComponent<String>(_singleContainer, _singleContainer, false, true, true);
            AddComponent<String>(_singleContainer, _singleContainer, true, false, true);
            Assert.IsFalse(_singleContainer.HasComponent<String>(Name));
        }

        [Test]
        public void TestAddComponentByType()
        {
            _innerSubContainer.AddComponent<SomeData>(new SimpleContainerEntry<SomeData>(new SomeData(OtherEntryValue)));
            AddComponent<String>(_subContainer1, _mainContainer, false, true, true);
            AddComponent<String>(_subContainer1, _mainContainer, true, false, true);
            AddComponent<String>(_mainContainer, _mainContainer, true, false, true);
            AddComponent<String>(_innerSubContainer, _mainContainer, true, true, true);
        }

        [Test]
        public void TestAddComponentByTypeMethodEquality()
        {
            Assert.IsFalse(_singleContainer.HasComponent<String>());
            Assert.DoesNotThrow(() => _singleContainer.AddComponent(typeof (String), _entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>());
            Assert.Throws<ServiceAlreadyRegisteredException>(() => _singleContainer.AddComponent<String>(_entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>());
        }

        [Test]
        public void TestSingleContainerAddComponentByTypeAndName()
        {
            _singleContainer.AddComponent<String>(OtherName, new SimpleContainerEntry<String>(OtherEntryValue));
            AddComponent<String>(Name, _singleContainer, _singleContainer, false, true, true);
            AddComponent<String>(Name, _singleContainer, _singleContainer, true, false, true);
        }

        [Test]
        public void TestAddComponentByTypeAndName()
        {
            _innerSubContainer.AddComponent<String>(OtherName, new SimpleContainerEntry<String>(OtherEntryValue));
            AddComponent<String>(Name, _subContainer1, _mainContainer, false, true, true);
            AddComponent<String>(Name, _subContainer1, _mainContainer, true, false, true);
            AddComponent<String>(Name, _mainContainer, _mainContainer, true, false, true);
            AddComponent<String>(Name, _innerSubContainer, _mainContainer, true, true, true);
        }

        [Test]
        public void TestAddComponentByTypeAndNameMethodEquality()
        {
            Assert.IsFalse(_singleContainer.HasComponent<String>(Name));
            Assert.DoesNotThrow(() => _singleContainer.AddComponent(Name, typeof(String), _entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>(Name));
            Assert.Throws<ServiceAlreadyRegisteredException>(() => _singleContainer.AddComponent<String>(Name, _entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>(Name));
        }

        private void CheckServiceAlreadyRegisteredException(Action action, String exceptionMessage)
        {
            ExceptionChecker.Throws<ServiceAlreadyRegisteredException>(action, exceptionMessage);
        }

        private void AddComponent(OtherKey key, IServiceContainer addContainer, IServiceContainer searchContainer, Boolean beforeValue, Boolean addValue, Boolean afterValue)
        {
            Assert.AreEqual(beforeValue, searchContainer.HasComponent(key));
            if (addValue)
                Assert.DoesNotThrow(() => addContainer.AddComponent(key, _entry));
            else
                Assert.Throws<ServiceAlreadyRegisteredException>(() => addContainer.AddComponent(key, _entry));
            Assert.AreEqual(afterValue, searchContainer.HasComponent(key));
        }

        private void AddComponent(String name, IServiceContainer addContainer, IServiceContainer searchContainer, Boolean beforeValue, Boolean addValue, Boolean afterValue)
        {
            Assert.AreEqual(beforeValue, searchContainer.HasComponent(name));
            if (addValue)
                Assert.DoesNotThrow(() => addContainer.AddComponent(name, _entry));
            else
                Assert.Throws<ServiceAlreadyRegisteredException>(() => addContainer.AddComponent(name, _entry));
            Assert.AreEqual(afterValue, searchContainer.HasComponent(name));
        }

        private void AddComponent<T>(IServiceContainer addContainer, IServiceContainer searchContainer, Boolean beforeValue, Boolean addValue, Boolean afterValue)
        {
            Assert.AreEqual(beforeValue, searchContainer.HasComponent<T>());
            if (addValue)
                Assert.DoesNotThrow(() => addContainer.AddComponent<T>(_entry));
            else
                Assert.Throws<ServiceAlreadyRegisteredException>(() => addContainer.AddComponent<T>(_entry));
            Assert.AreEqual(afterValue, searchContainer.HasComponent<T>());
        }

        private void AddComponent<T>(String name, IServiceContainer addContainer, IServiceContainer searchContainer, Boolean beforeValue, Boolean addValue, Boolean afterValue)
        {
            Assert.AreEqual(beforeValue, searchContainer.HasComponent<T>(name));
            if (addValue)
                Assert.DoesNotThrow(() => addContainer.AddComponent<T>(name, _entry));
            else
                Assert.Throws<ServiceAlreadyRegisteredException>(() => addContainer.AddComponent<T>(name, _entry));
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
