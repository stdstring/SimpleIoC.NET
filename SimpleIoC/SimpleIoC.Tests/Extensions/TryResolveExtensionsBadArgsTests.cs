using System;
using NUnit.Framework;
using SimpleIoC.Extensions;

namespace SimpleIoC.Tests.Extensions
{
    [TestFixture]
    public class TryResolveExtensionsBadArgsTests
    {
        [Test]
        public void BadArgsInTryResolveByKey()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.TryResolve(new Object(), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.TryResolve((Object) null, new Object()));
        }

        [Test]
        public void BadArgsInTryResolveByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.TryResolve(Name, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.TryResolve((String) null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.TryResolve(String.Empty, new Object()));
        }

        [Test]
        public void BadArgsInTryResolveByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.TryResolve(new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.TryResolve(typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.TryResolve((Type) null, new Object()));
        }

        [Test]
        public void BadArgsInTryResolveByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.TryResolve<Object>(Name, new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.TryResolve(Name, typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.TryResolve<Object>(null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.TryResolve<Object>(String.Empty, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.TryResolve(null, typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.TryResolve(String.Empty, typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.TryResolve(Name, null, new Object()));
        }

        private readonly IServiceContainer _nullContainer = null;
        private readonly IServiceContainer _container = new ServiceContainer();

        private const String Name = "some_name";
    }
}
