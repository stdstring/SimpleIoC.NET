using System;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;

namespace SimpleIoC.Tests
{
    [TestFixture]
    public class ServiceContainerInitializeTests
    {
        [SetUp]
        public void SetUp()
        {
            _container = new ServiceContainer();
        }

        [Test]
        public void TestInitialize()
        {
            Assert.IsFalse(_container.HasComponent<String>());
            Action<IServiceContainer> initializer = container => container.AddComponent<String>(new SimpleContainerEntry(EntryValue));
            _container.Initialize(initializer);
            Assert.IsTrue(_container.HasComponent<String>());
        }

        [Test]
        public void TestClear()
        {
            _container.AddComponent<String>(new SimpleContainerEntry(EntryValue));
            Assert.IsTrue(_container.HasComponent<String>());
            _container.Clear();
            Assert.IsFalse(_container.HasComponent<String>());
        }

        private IServiceContainer _container;
        private const String EntryValue = "impulse 666";
    }
}
