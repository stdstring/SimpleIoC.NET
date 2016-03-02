using System;
using System.Collections.Generic;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Exceptions;
using SimpleIoC.Key;
using SimpleIoC.Tests.Utils;

namespace SimpleIoC.Tests
{
    [TestFixture]
    public class ServiceContainerResolveTests
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
            const String serviceByKeyMessage = "Service by key \"key = 666\" is not found";
            const String serviceByNameMessage = "Service by name \"iddqd\" is not found";
            const String serviceByTypeMessage = "Service by type \"System.String\" is not found";
            const String serviceByNameTypeMessage = "Service by name \"iddqd\" and type \"System.String\" is not found";
            CheckServiceNotFoundException(() => _singleContainer.Resolve(_key), serviceByKeyMessage);
            CheckServiceNotFoundException(() => _singleContainer.Resolve(Name), serviceByNameMessage);
            CheckServiceNotFoundException(() => _singleContainer.Resolve<String>(), serviceByTypeMessage);
            CheckServiceNotFoundException(() => _singleContainer.Resolve<String>(Name), serviceByNameTypeMessage);
        }

        [Test]
        public void TestSingleContainerResolveByKey()
        {
            _singleContainer.AddComponent(_key, _entry);
            _singleContainer.AddComponent(_otherKey, _otherEntry);
            Assert.AreEqual(EntryValue, _singleContainer.Resolve(_key));
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve(_unknownKey));
        }

        [Test]
        public void TestResolveByKey()
        {
            _innerSubContainer.AddComponent(_key, _entry);
            _innerSubContainer.AddComponent(_otherKey, _otherEntry);
            Assert.AreEqual(EntryValue, _mainContainer.Resolve(_key));
            Assert.AreEqual(EntryValue, _subContainer1.Resolve(_key));
            Assert.AreEqual(EntryValue, _innerSubContainer.Resolve(_key));
            Assert.Throws<ServiceNotFoundException>(() => _subContainer2.Resolve(_key));
            Assert.Throws<ServiceNotFoundException>(() => _mainContainer.Resolve(_unknownKey));
        }

        [Test]
        public void TestResolveByKeyWithDuplicates()
        {
            _subContainer1.AddComponent(_key, _entry);
            _innerSubContainer.AddComponent(_key, _otherEntry);
            Assert.AreEqual(EntryValue, _mainContainer.Resolve(_key));
            Assert.AreEqual(EntryValue, _subContainer1.Resolve(_key));
            Assert.AreEqual(OtherEntryValue, _innerSubContainer.Resolve(_key));
            Assert.Throws<ServiceNotFoundException>(() => _subContainer2.Resolve(_key));
        }

        [Test]
        public void TestSingleContainerResolveByName()
        {
            _singleContainer.AddComponent(Name, _entry);
            _singleContainer.AddComponent(OtherName, _otherEntry);
            Assert.AreEqual(EntryValue, _singleContainer.Resolve(Name));
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve(UnknownName));
        }

        [Test]
        public void TestResolveByName()
        {
            _innerSubContainer.AddComponent(Name, _entry);
            _innerSubContainer.AddComponent(OtherName, _otherEntry);
            Assert.AreEqual(EntryValue, _mainContainer.Resolve(Name));
            Assert.AreEqual(EntryValue, _subContainer1.Resolve(Name));
            Assert.AreEqual(EntryValue, _innerSubContainer.Resolve(Name));
            Assert.Throws<ServiceNotFoundException>(() => _subContainer2.Resolve(Name));
            Assert.Throws<ServiceNotFoundException>(() => _mainContainer.Resolve(UnknownName));
        }

        [Test]
        public void TestResolveByNameWithDuplicates()
        {
            _subContainer1.AddComponent(Name, _entry);
            _innerSubContainer.AddComponent(Name, _otherEntry);
            Assert.AreEqual(EntryValue, _mainContainer.Resolve(Name));
            Assert.AreEqual(EntryValue, _subContainer1.Resolve(Name));
            Assert.AreEqual(OtherEntryValue, _innerSubContainer.Resolve(Name));
            Assert.Throws<ServiceNotFoundException>(() => _subContainer2.Resolve(Name));
        }

        [Test]
        public void TestSingleContainerResolveByType()
        {
            _singleContainer.AddComponent<String>(_entry);
            _singleContainer.AddComponent<SomeData>(new SimpleContainerEntry<SomeData>(_data));
            Assert.AreEqual(EntryValue, _singleContainer.Resolve<String>());
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve<Uri>());
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve<String>(Name));
        }

        [Test]
        public void TestResolveByType()
        {
            _innerSubContainer.AddComponent<String>(_entry);
            _singleContainer.AddComponent<SomeData>(new SimpleContainerEntry<SomeData>(_data));
            Assert.AreEqual(EntryValue, _mainContainer.Resolve<String>());
            Assert.AreEqual(EntryValue, _subContainer1.Resolve<String>());
            Assert.AreEqual(EntryValue, _innerSubContainer.Resolve<String>());
            Assert.Throws<ServiceNotFoundException>(() => _subContainer2.Resolve<String>());
            Assert.Throws<ServiceNotFoundException>(() => _mainContainer.Resolve<Uri>());
            Assert.Throws<ServiceNotFoundException>(() => _mainContainer.Resolve<String>(Name));
        }

        [Test]
        public void TestResolveByTypeWithDuplicates()
        {
            _subContainer1.AddComponent<String>(_entry);
            _innerSubContainer.AddComponent<String>(_otherEntry);
            Assert.AreEqual(EntryValue, _mainContainer.Resolve<String>());
            Assert.AreEqual(EntryValue, _subContainer1.Resolve<String>());
            Assert.AreEqual(OtherEntryValue, _innerSubContainer.Resolve<String>());
            Assert.Throws<ServiceNotFoundException>(() => _subContainer2.Resolve<String>());
        }

        [Test]
        public void TestResolveByTypeMethodEquality()
        {
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve<String>());
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve(typeof(String)));
            Assert.DoesNotThrow(() => _singleContainer.AddComponent<String>(_entry));
            Assert.IsNotNull(_singleContainer.Resolve<String>());
            Assert.IsNotNull(_singleContainer.Resolve(typeof(String)));
        }

        [Test]
        public void TestSingleContainerResolveByTypeAndName()
        {
            _singleContainer.AddComponent<String>(Name, _entry);
            _singleContainer.AddComponent<String>(OtherName, _entry);
            _singleContainer.AddComponent<SomeData>(AnotherName, new SimpleContainerEntry<SomeData>(_data));
            Assert.AreEqual(EntryValue, _singleContainer.Resolve<String>(Name));
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve<String>(UnknownName));
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve<String>());
        }

        [Test]
        public void TestResolveByTypeAndName()
        {
            _innerSubContainer.AddComponent<String>(Name, _entry);
            _innerSubContainer.AddComponent<String>(OtherName, _entry);
            _innerSubContainer.AddComponent<SomeData>(AnotherName, new SimpleContainerEntry<SomeData>(_data));
            Assert.AreEqual(EntryValue, _mainContainer.Resolve<String>(Name));
            Assert.AreEqual(EntryValue, _subContainer1.Resolve<String>(Name));
            Assert.AreEqual(EntryValue, _innerSubContainer.Resolve<String>(Name));
            Assert.Throws<ServiceNotFoundException>(() => _subContainer2.Resolve<String>(Name));
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve<String>(UnknownName));
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve<String>());
        }

        [Test]
        public void TestResolveByTypeAndNameWithDuplicates()
        {
            _subContainer1.AddComponent<String>(Name, _entry);
            _innerSubContainer.AddComponent<String>(Name, _otherEntry);
            Assert.AreEqual(EntryValue, _mainContainer.Resolve<String>(Name));
            Assert.AreEqual(EntryValue, _subContainer1.Resolve<String>(Name));
            Assert.AreEqual(OtherEntryValue, _innerSubContainer.Resolve<String>(Name));
            Assert.Throws<ServiceNotFoundException>(() => _subContainer2.Resolve<String>(Name));
        }

        [Test]
        public void TestResolveByTypeAndNameMethodEquality()
        {
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve<String>(Name));
            Assert.Throws<ServiceNotFoundException>(() => _singleContainer.Resolve(Name, typeof(String)));
            Assert.DoesNotThrow(() => _singleContainer.AddComponent<String>(Name, _entry));
            Assert.IsNotNull(_singleContainer.Resolve<String>(Name));
            Assert.IsNotNull(_singleContainer.Resolve(Name, typeof(String)));
        }

        [Test]
        public void TestSingleContainerResolveByPredicate()
        {
            _singleContainer.AddComponent(Name, _entry);
            _singleContainer.AddComponent(OtherName, _otherEntry);
            _singleContainer.AddComponent(AnotherName, new SimpleContainerEntry<SomeData>(_data));
            ResolveByPredicateCommonBody(_singleContainer);
        }

        [Test]
        public void TestResolveByPredicate()
        {
            _mainContainer.AddComponent(Name, _entry);
            _subContainer1.AddComponent(OtherName, _otherEntry);
            _subContainer2.AddComponent(AnotherName, new SimpleContainerEntry<SomeData>(_data));
            ResolveByPredicateCommonBody(_mainContainer);
        }

        [Test]
        public void TestSingleContainerResolveEntriesByPredicate()
        {
            _singleContainer.AddComponent(Name, _entry);
            _singleContainer.AddComponent(OtherName, _otherEntry);
            _singleContainer.AddComponent(AnotherName, new SimpleContainerEntry<SomeData>(_data));
            ResolveEntriesByPredicateCommonBody(_singleContainer);
        }

        [Test]
        public void TestResolveEntriesByPredicate()
        {
            _mainContainer.AddComponent(Name, _entry);
            _subContainer1.AddComponent(OtherName, _otherEntry);
            _subContainer2.AddComponent(AnotherName, new SimpleContainerEntry<SomeData>(_data));
            ResolveEntriesByPredicateCommonBody(_mainContainer);
        }

        private void CheckServiceNotFoundException(Action action, String exceptionMessage)
        {
            ExceptionChecker.Throws<ServiceNotFoundException>(action, exceptionMessage);
        }

        private void ResolveByPredicateCommonBody(IServiceContainer container)
        {
            IList<Object> untypedActual = container.Resolve(key => ((NameKey)key).Name.StartsWith("id"));
            CheckObjectList(new Object[] {EntryValue, OtherEntryValue, _data}, untypedActual);
            IList<String> typedActual = container.Resolve<String>(key => ((NameKey)key).Name.StartsWith("id"));
            CheckObjectList(new[] {EntryValue, OtherEntryValue}, typedActual);
        }

        private void ResolveEntriesByPredicateCommonBody(IServiceContainer container)
        {
            IList<IContainerEntry> entries = container.ResolveEntries(key => ((NameKey)key).Name.StartsWith("id"));
            CheckObjectList(new Object[] {EntryValue, OtherEntryValue, _data}, entries, container);
        }

        private void CheckObjectList<T>(IList<T> expected, IList<T> actual)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Count));
            foreach (T item in expected)
                Assert.IsTrue(actual.Contains(item));
        }

        private void CheckObjectList<T>(IList<T> expected, IList<IContainerEntry> actual, IServiceContainer container)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Count));
            foreach (IContainerEntry entry in actual)
                Assert.IsTrue(expected.Contains((T)entry.GetValue(container)));
        }

        private IServiceContainer _singleContainer;
        private IServiceContainer _mainContainer;
        private IServiceContainer _subContainer1;
        private IServiceContainer _subContainer2;
        private IServiceContainer _innerSubContainer;

        private readonly IContainerEntry _entry = new SimpleContainerEntry<String>(EntryValue);
        private readonly IContainerEntry _otherEntry = new SimpleContainerEntry<String>(OtherEntryValue);
        private readonly SomeData _data = new SomeData(OtherEntryValue);

        private const String EntryValue = "impulse 666";
        private const String OtherEntryValue = "impulse 9";
        // keys
        private readonly OtherKey _key = new OtherKey(666);
        private readonly OtherKey _otherKey = new OtherKey(777);
        private readonly OtherKey _unknownKey = new OtherKey(999);
        // names
        private const String Name = "iddqd";
        private const String OtherName = "idkfa";
        private const String AnotherName = "iddqd+idkfa";
        private const String UnknownName = "idclip";
    }
}
