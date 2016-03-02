using System;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Extensions;

namespace SimpleIoC.Tests.Extensions
{
    [TestFixture]
    public class ReplaceExtensionsBadArgsTests
    {
        [Test]
        public void BadArgsInReplaceEntryByKey()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceComponent(new Object(), _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent((Object) null, _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceComponent(new Object(), null));
        }

        [Test]
        public void BadArgsInReplaceEntryByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceComponent(Name, _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent((String) null, _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent(String.Empty, _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceComponent(Name, null));
        }

        [Test]
        public void BadArgsInReplaceEntryByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceComponent<String>(_simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceComponent(typeof(String), _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent((Type) null, _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent<String>(null));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent(typeof (String), null));
        }

        [Test]
        public void BadArgsInReplaceEntryByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceComponent<String>(Name, _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceComponent(Name, typeof (String), _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent<String>(null, _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent<String>(String.Empty, _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent(null, typeof (String), _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent(Name, null, _simpleEntry));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent<String>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceComponent(Name, typeof (String), null));
        }

        [Test]
        public void BadArgsInReplaceBySimpleValueComponentByKey()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceBySimpleValueComponent(new Object(), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent((Object) null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent(new Object(), null));
        }

        [Test]
        public void BadArgsInReplaceByLazyValueComponentByKey()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByLazyValueComponent(new Object(), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent((Object) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent(new Object(), null));
        }

        [Test]
        public void BadArgsInReplaceByGeneratorComponentByKey()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByGeneratorComponent(new Object(), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent((Object) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent(new Object(), null));
        }

        [Test]
        public void BadArgsInReplaceBySimpleValueComponentByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceBySimpleValueComponent(Name, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent((String) null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent(String.Empty, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent(Name, null));
        }

        [Test]
        public void BadArgsInReplaceByLazyValueComponentByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByLazyValueComponent(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent((String) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent(Name, null));
        }

        [Test]
        public void BadArgsInReplaceByGeneratorComponentByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByGeneratorComponent(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent((String) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent(Name, null));
        }

        [Test]
        public void BadArgsInReplaceBySimpleValueComponentByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceBySimpleValueComponent(new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceBySimpleValueComponent(typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent((Type) null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent<Object>(null));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent(typeof (Object), null));
        }

        [Test]
        public void BadArgsInReplaceByLazyValueComponentByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByLazyValueComponent(_ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByLazyValueComponent(typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent((Type) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent<Object>(null));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent(typeof (Object), null));
        }

        [Test]
        public void BadArgsInReplaceByGeneratorComponentByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByGeneratorComponent(_ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByGeneratorComponent(typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent((Type) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent<Object>(null));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent(typeof (Object), null));
        }

        [Test]
        public void BadArgsInReplaceBySimpleValueComponentByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceBySimpleValueComponent<Object>(Name, new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceBySimpleValueComponent(Name, typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent<Object>(null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent<Object>(String.Empty, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent(null, typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent(String.Empty, typeof (Object), new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent(Name, null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent<Object>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceBySimpleValueComponent(Name, typeof (Object), null));
        }

        [Test]
        public void BadArgsInReplaceByLazyValueComponentByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByLazyValueComponent<Object>(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByLazyValueComponent(Name, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent<Object>(null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent<Object>(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent(null, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent(String.Empty, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent(Name, null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent<Object>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByLazyValueComponent(Name, typeof (Object), null));
        }

        [Test]
        public void BadArgsInReplaceByGeneratorComponentByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByGeneratorComponent<Object>(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _nullContainer.ReplaceByGeneratorComponent(Name, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent<Object>(null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent<Object>(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent(null, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent(String.Empty, typeof (Object), _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent(Name, null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent<Object>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _container.ReplaceByGeneratorComponent(Name, typeof (Object), null));
        }

        private readonly IServiceContainer _nullContainer = null;
        private readonly IServiceContainer _container = new ServiceContainer();
        private readonly IContainerEntry _simpleEntry = new SimpleContainerEntry<String>("IDDQD");

        private const String Name = "some_name";
    }
}
