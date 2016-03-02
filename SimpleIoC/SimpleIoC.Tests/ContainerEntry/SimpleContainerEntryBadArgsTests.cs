using System;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;

namespace SimpleIoC.Tests.ContainerEntry
{
    [TestFixture]
    public class SimpleContainerEntryBadArgsTests
    {
        [Test]
        public void BadArgsInCtor()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new SimpleContainerEntry<Object>(null));
            // ReSharper restore ObjectCreationAsStatement
        }

        [Test]
        public void BadArgsInGetValue()
        {
            SimpleContainerEntry<Object> entry = new SimpleContainerEntry<Object>(new Object());
            Assert.Throws<ArgumentNullException>(() => entry.GetValue(null));
            Assert.Throws<ArgumentNullException>(() => ((IContainerEntry) entry).GetValue(null));
        }
    }
}
