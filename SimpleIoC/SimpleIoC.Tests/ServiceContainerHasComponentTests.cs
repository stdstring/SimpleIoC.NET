using System;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Tests.Utils;

namespace SimpleIoC.Tests
{
    [TestFixture]
    public class ServiceContainerHasComponentTests
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
        public void TestSingleContainerHasComponentByKey()
        {
            _singleContainer.AddComponent(_key, _entry);
            _singleContainer.AddComponent(_otherKey, new SimpleContainerEntry(OtherEntryValue));
            Assert.IsTrue(_singleContainer.HasComponent(_key));
            Assert.IsFalse(_singleContainer.HasComponent(_unknownKey));
        }

        [Test]
        public void TestHasComponentByKey()
        {
            _innerSubContainer.AddComponent(_key, _entry);
            _innerSubContainer.AddComponent(_otherKey, new SimpleContainerEntry(OtherEntryValue));
            Assert.IsTrue(_mainContainer.HasComponent(_key));
            Assert.IsTrue(_subContainer1.HasComponent(_key));
            Assert.IsTrue(_innerSubContainer.HasComponent(_key));
            Assert.IsFalse(_subContainer2.HasComponent(_key));
            Assert.IsFalse(_mainContainer.HasComponent(_unknownKey));
        }

        [Test]
        public void TestHasComponentByKeyWithDuplicates()
        {
            IContainerEntry entry = new SimpleContainerEntry(EntryValue);
            IContainerEntry otherEntry = new SimpleContainerEntry(OtherEntryValue);
            _subContainer1.AddComponent(_key, entry);
            _innerSubContainer.AddComponent(_key, otherEntry);
            Assert.IsTrue(_mainContainer.HasComponent(_key));
            Assert.IsTrue(_subContainer1.HasComponent(_key));
            Assert.IsTrue(_innerSubContainer.HasComponent(_key));
            Assert.IsFalse(_subContainer2.HasComponent(_key));
        }

        [Test]
        public void TestSingleContainerHasComponentByName()
        {
            _singleContainer.AddComponent(Name, _entry);
            _singleContainer.AddComponent(OtherName, new SimpleContainerEntry(OtherEntryValue));
            Assert.IsTrue(_singleContainer.HasComponent(Name));
            Assert.IsFalse(_singleContainer.HasComponent(UnknownName));
        }

        [Test]
        public void TestHasComponentByName()
        {
            _innerSubContainer.AddComponent(Name, _entry);
            _innerSubContainer.AddComponent(OtherName, new SimpleContainerEntry(OtherEntryValue));
            Assert.IsTrue(_mainContainer.HasComponent(Name));
            Assert.IsTrue(_subContainer1.HasComponent(Name));
            Assert.IsTrue(_innerSubContainer.HasComponent(Name));
            Assert.IsFalse(_subContainer2.HasComponent(Name));
            Assert.IsFalse(_mainContainer.HasComponent(UnknownName));
        }

        [Test]
        public void TestHasComponentByNameWithDuplicates()
        {
            IContainerEntry entry = new SimpleContainerEntry(EntryValue);
            IContainerEntry otherEntry = new SimpleContainerEntry(OtherEntryValue);
            _subContainer1.AddComponent(Name, entry);
            _innerSubContainer.AddComponent(Name, otherEntry);
            Assert.IsTrue(_mainContainer.HasComponent(Name));
            Assert.IsTrue(_subContainer1.HasComponent(Name));
            Assert.IsTrue(_innerSubContainer.HasComponent(Name));
            Assert.IsFalse(_subContainer2.HasComponent(Name));
        }

        [Test]
        public void TestSingleContainerHasComponentByType()
        {
            _singleContainer.AddComponent<String>(_entry);
            _singleContainer.AddComponent<SomeData>(new SimpleContainerEntry(new SomeData(OtherEntryValue)));
            Assert.IsTrue(_singleContainer.HasComponent<String>());
            Assert.IsFalse(_singleContainer.HasComponent<Uri>());
            Assert.IsFalse(_singleContainer.HasComponent<String>(Name));
        }

        [Test]
        public void TestHasComponentByType()
        {
            _innerSubContainer.AddComponent<String>(_entry);
            _singleContainer.AddComponent<SomeData>(new SimpleContainerEntry(new SomeData(OtherEntryValue)));
            Assert.IsTrue(_mainContainer.HasComponent<String>());
            Assert.IsTrue(_subContainer1.HasComponent<String>());
            Assert.IsTrue(_innerSubContainer.HasComponent<String>());
            Assert.IsFalse(_subContainer2.HasComponent<String>());
            Assert.IsFalse(_mainContainer.HasComponent<Uri>());
            Assert.IsFalse(_mainContainer.HasComponent<String>(Name));
        }

        [Test]
        public void TestHasComponentByTypeWithDuplicates()
        {
            IContainerEntry entry = new SimpleContainerEntry(EntryValue);
            IContainerEntry otherEntry = new SimpleContainerEntry(OtherEntryValue);
            _subContainer1.AddComponent<String>(entry);
            _innerSubContainer.AddComponent<String>(otherEntry);
            Assert.IsTrue(_mainContainer.HasComponent<String>());
            Assert.IsTrue(_subContainer1.HasComponent<String>());
            Assert.IsTrue(_innerSubContainer.HasComponent<String>());
            Assert.IsFalse(_subContainer2.HasComponent<String>());
        }

        [Test]
        public void TestHasComponentByTypeMethodEquality()
        {
            Assert.IsFalse(_singleContainer.HasComponent<String>());
            Assert.IsFalse(_singleContainer.HasComponent(typeof(String)));
            Assert.DoesNotThrow(() => _singleContainer.AddComponent<String>(_entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>());
            Assert.IsTrue(_singleContainer.HasComponent(typeof(String)));
        }

        [Test]
        public void TestSingleContainerHasComponentByTypeAndName()
        {
            _singleContainer.AddComponent<String>(Name, _entry);
            _singleContainer.AddComponent<String>(OtherName, _entry);
            _singleContainer.AddComponent<SomeData>(AnotherName, new SimpleContainerEntry(new SomeData(OtherEntryValue)));
            Assert.IsTrue(_singleContainer.HasComponent<String>(Name));
            Assert.IsFalse(_singleContainer.HasComponent<String>(UnknownName));
            Assert.IsFalse(_singleContainer.HasComponent<String>());
        }

        [Test]
        public void TestHasComponentByTypeAndName()
        {
            _innerSubContainer.AddComponent<String>(Name, _entry);
            _innerSubContainer.AddComponent<String>(OtherName, _entry);
            _innerSubContainer.AddComponent<SomeData>(AnotherName, new SimpleContainerEntry(new SomeData(OtherEntryValue)));
            Assert.IsTrue(_mainContainer.HasComponent<String>(Name));
            Assert.IsTrue(_subContainer1.HasComponent<String>(Name));
            Assert.IsTrue(_innerSubContainer.HasComponent<String>(Name));
            Assert.IsFalse(_subContainer2.HasComponent<String>(Name));
            Assert.IsFalse(_singleContainer.HasComponent<String>(UnknownName));
            Assert.IsFalse(_singleContainer.HasComponent<String>());
        }

        [Test]
        public void TestHasComponentByTypeAndNameWithDuplicates()
        {
            IContainerEntry entry = new SimpleContainerEntry(EntryValue);
            IContainerEntry otherEntry = new SimpleContainerEntry(OtherEntryValue);
            _subContainer1.AddComponent<String>(Name, entry);
            _innerSubContainer.AddComponent<String>(Name, otherEntry);
            Assert.IsTrue(_mainContainer.HasComponent<String>(Name));
            Assert.IsTrue(_subContainer1.HasComponent<String>(Name));
            Assert.IsTrue(_innerSubContainer.HasComponent<String>(Name));
            Assert.IsFalse(_subContainer2.HasComponent<String>(Name));
        }

        [Test]
        public void TestHasComponentByTypeAndNameMethodEquality()
        {
            Assert.IsFalse(_singleContainer.HasComponent<String>(Name));
            Assert.IsFalse(_singleContainer.HasComponent(Name, typeof(String)));
            Assert.DoesNotThrow(() => _singleContainer.AddComponent<String>(Name, _entry));
            Assert.IsTrue(_singleContainer.HasComponent<String>(Name));
            Assert.IsTrue(_singleContainer.HasComponent(Name, typeof(String)));
        }

        private IServiceContainer _singleContainer;
        private IServiceContainer _mainContainer;
        private IServiceContainer _subContainer1;
        private IServiceContainer _subContainer2;
        private IServiceContainer _innerSubContainer;

        private readonly IContainerEntry _entry = new SimpleContainerEntry(EntryValue);

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
