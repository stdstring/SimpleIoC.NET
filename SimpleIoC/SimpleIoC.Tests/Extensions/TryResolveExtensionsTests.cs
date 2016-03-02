using System;
using NUnit.Framework;
using SimpleIoC.Extensions;

namespace SimpleIoC.Tests.Extensions
{
    [TestFixture]
    public class TryResolveExtensionsTests
    {
        [SetUp]
        public void SetUp()
        {
            _container = new ServiceContainer();
        }

        [Test]
        public void TryResolveByKey()
        {
            Object key = new Object[] {66};
            Object otherKey = new Object[] {"IDDQD"};
            _container.AddSimpleValueComponent(key, Value);
            Assert.AreEqual(Value, _container.TryResolve(key, DefaultValue));
            Assert.AreEqual(DefaultValue, _container.TryResolve(otherKey, DefaultValue));
        }

        [Test]
        public void TryResolveByName()
        {
            const String name = "key_666";
            const String otherName = "key_6999";
            _container.AddSimpleValueComponent(name, (Object) Value);
            Assert.AreEqual(Value, _container.TryResolve(name, (Object) DefaultValue));
            Assert.AreEqual(DefaultValue, _container.TryResolve(otherName, (Object) DefaultValue));
        }

        [Test]
        public void TryResolveByType()
        {
            Int32[] defaultValue = {666};
            _container.AddSimpleValueComponent(Value);
            Assert.AreEqual(Value, _container.TryResolve(DefaultValue));
            Assert.AreEqual(Value, _container.TryResolve(typeof (String), DefaultValue));
            Assert.AreEqual(defaultValue, _container.TryResolve(defaultValue));
            Assert.AreEqual(defaultValue, _container.TryResolve(typeof (Int32[]), defaultValue));
        }

        [Test]
        public void TryResolveByNameAndType()
        {
            const String name = "key_666";
            const String otherName = "key_6999";
            Int32[] defaultValue = {666};
            _container.AddSimpleValueComponent(name, Value);
            Assert.AreEqual(Value, _container.TryResolve(name, DefaultValue));
            Assert.AreEqual(Value, _container.TryResolve(name, typeof (String), DefaultValue));
            Assert.AreEqual(DefaultValue, _container.TryResolve(otherName, DefaultValue));
            Assert.AreEqual(DefaultValue, _container.TryResolve(otherName, typeof(String), DefaultValue));
            Assert.AreEqual(defaultValue, _container.TryResolve(name, defaultValue));
            Assert.AreEqual(defaultValue, _container.TryResolve(name, typeof (Int32[]), defaultValue));
        }

        private IServiceContainer _container;
        private const String Value = "IDDQD++IDKFA";
        private const String DefaultValue = "IMPULSE_9";
    }
}
