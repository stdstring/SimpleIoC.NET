using System;
using NUnit.Framework;
using SimpleIoC.Extensions;

namespace SimpleIoC.Tests.Extensions
{
    [TestFixture]
    public class ServiceContainerExtensionsBadArgsTests
    {
        [Test]
        public void BadArgsInAddSimpleValueComponentByKey()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddSimpleValueComponent(new Object(), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent((Object) null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent(new Object(), null));
        }

        [Test]
        public void BadArgsInAddLazyValueComponentByKey()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddLazyValueComponent(new Object(), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent((Object) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent(new Object(), null));
        }

        [Test]
        public void BadArgsInAddGeneratorComponentByKey()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddGeneratorComponent(new Object(), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent((Object) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent(new Object(), null));
        }

        [Test]
        public void BadArgsInAddSimpleValueComponentByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddSimpleValueComponent(Name, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent((String) null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent(String.Empty, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent(Name, null));
        }

        [Test]
        public void BadArgsInAddLazyValueComponentByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddLazyValueComponent(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent((String) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent(Name, null));
        }

        [Test]
        public void BadArgsInAddGeneratorComponentByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddGeneratorComponent(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent((String) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent(Name, null));
        }

        [Test]
        public void BadArgsInAddSimpleValueComponentByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddSimpleValueComponent(new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddSimpleValueComponent(typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent((Type) null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent<Object>(null));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent(typeof (Object), null));
        }

        [Test]
        public void BadArgsInAddLazyValueComponentByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddLazyValueComponent(_ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddLazyValueComponent(typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent((Type) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent<Object>(null));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent(typeof (Object), null));
        }

        [Test]
        public void BadArgsInAddGeneratorComponentByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddGeneratorComponent(_ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddGeneratorComponent(typeof(Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent((Type)null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent<Object>(null));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent(typeof(Object), null));
        }

        [Test]
        public void BadArgsInAddSimpleValueComponentByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddSimpleValueComponent<Object>(Name, new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddSimpleValueComponent(Name, typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent<Object>(null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent<Object>(String.Empty, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent(null, typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent(String.Empty, typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent(Name, null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent<Object>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _container.AddSimpleValueComponent(Name, typeof (Object), null));
        }

        [Test]
        public void BadArgsInAddLazyValueComponentByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddLazyValueComponent<Object>(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddLazyValueComponent(Name, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent<Object>(null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent<Object>(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent(null, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent(String.Empty, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent(Name, null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent<Object>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _container.AddLazyValueComponent(Name, typeof (Object), null));
        }

        [Test]
        public void BadArgsInAddGeneratorComponentByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddGeneratorComponent<Object>(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.AddGeneratorComponent(Name, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent<Object>(null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent<Object>(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent(null, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent(String.Empty, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent(Name, null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent<Object>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _container.AddGeneratorComponent(Name, typeof (Object), null));
        }

        private readonly IServiceContainer _nullContainer = null;
        private readonly IServiceContainer _container = new ServiceContainer();

        private const String Name = "some-name";
    }
}
