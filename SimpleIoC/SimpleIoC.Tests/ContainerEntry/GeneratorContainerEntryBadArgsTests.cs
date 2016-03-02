using System;
using NUnit.Framework;
using SimpleIoC.ContainerEntry;

namespace SimpleIoC.Tests.ContainerEntry
{
    [TestFixture]
    public class GeneratorContainerEntryBadArgsTests
    {
        [Test]
        public void BadArgsInCtor()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new GeneratorContainerEntry<Object>(null));
            // ReSharper restore ObjectCreationAsStatement
        }

        [Test]
        public void BadArgsInGetValue()
        {
            GeneratorContainerEntry<Object> entry = new GeneratorContainerEntry<Object>(_ => new Object());
            Assert.Throws<ArgumentNullException>(() => entry.GetValue(null));
            Assert.Throws<ArgumentNullException>(() => ((IContainerEntry) entry).GetValue(null));
        }
    }
}
