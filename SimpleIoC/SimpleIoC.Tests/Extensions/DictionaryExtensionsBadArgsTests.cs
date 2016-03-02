using System;
using System.Collections.Generic;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Extensions;

namespace SimpleIoC.Tests.Extensions
{
    [TestFixture]
    public class DictionaryExtensionsBadArgsTests
    {
        [Test]
        public void BadArgsInAddSimpleValueComponentByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddSimpleValueComponent(Name, new Object()));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent((String) null, new Object()));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(String.Empty, new Object()));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(Name, null));
        }

        [Test]
        public void BadArgsInAddLazyValueComponentByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddLazyValueComponent(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent((String) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent(Name, null));
        }

        [Test]
        public void BadArgsInAddGeneratorComponentByName()
        {
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddGeneratorComponent(Name, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent((String) null, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent(String.Empty, _ => new Object()));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent(Name, null));
        }

        [Test]
        public void BadArgsInAddSimpleValueComponentByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddSimpleValueComponent("iddqd"));
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddSimpleValueComponent(typeof (String), "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent((Type) null, "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent<String>(null));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(typeof (String), null));
        }

        [Test]
        public void BadArgsInAddLazyValueComponentByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddLazyValueComponent(_ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddLazyValueComponent(typeof (String), _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent((Type) null, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent<String>(null));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent(typeof (String), null));
        }

        [Test]
        public void BadArgsInAddGeneratorComponentByType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddGeneratorComponent(_ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddGeneratorComponent(typeof (String), _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent((Type) null, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent<String>(null));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent(typeof (String), null));
        }

        [Test]
        public void BadArgsInAddSimpleValueComponentByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddSimpleValueComponent(Name, "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddSimpleValueComponent(Name, typeof (String), "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(null, "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(String.Empty, "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(null, typeof (String), "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(String.Empty, typeof (String), "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(Name, null, "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(Name, null));
            Assert.Throws<ArgumentNullException>(() => _entries.AddSimpleValueComponent(Name, typeof (String), null));
        }

        [Test]
        public void BadArgsInAddLazyValueComponentByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddLazyValueComponent(Name, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddLazyValueComponent(Name, typeof (String), _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent(null, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent(String.Empty, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent(null, typeof (String), _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent(String.Empty, typeof (String), _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent(Name, null, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent<String>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _entries.AddLazyValueComponent(Name, typeof (String), null));
        }

        [Test]
        public void BadArgsInAddGeneratorComponentByNameType()
        {
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddGeneratorComponent(Name, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _nullEntries.AddGeneratorComponent(Name, typeof (String), _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent(null, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent(String.Empty, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent(null, typeof (String), _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent(String.Empty, typeof (String), _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent(Name, null, _ => "iddqd"));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent<String>(Name, null));
            Assert.Throws<ArgumentNullException>(() => _entries.AddGeneratorComponent(Name, typeof (String), null));
        }

        private readonly IDictionary<Object, IContainerEntry> _nullEntries = null;
        private readonly IDictionary<Object, IContainerEntry> _entries = new Dictionary<Object, IContainerEntry>();

        private const String Name = "some_name";
    }
}
