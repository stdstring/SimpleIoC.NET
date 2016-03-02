using System;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;

namespace SimpleIoC.Tests.ContainerEntry
{
    [TestFixture]
    public class LazyContainerEntryBadArgsTests
    {
        [Test]
        public void BadArgsInCtor()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new LazyContainerEntry<Object>(null));
            // ReSharper restore ObjectCreationAsStatement
        }

        [Test]
        public void BadArgsInGetValue()
        {
            LazyContainerEntry<Object> entry = new LazyContainerEntry<Object>(_ => new Object());
            Assert.Throws<ArgumentNullException>(() => entry.GetValue(null));
            Assert.Throws<ArgumentNullException>(() => ((IContainerEntry) entry).GetValue(null));
        }
    }
}
