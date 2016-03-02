using System;
using NUnit.Framework;
using SimpleIoC.Key;

namespace SimpleIoC.Tests.Key
{
    [TestFixture]
    public class NameKeyBadArgsTests
    {
        [Test]
        public void BadArgsInCtor()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new NameKey(null));
            Assert.Throws<ArgumentNullException>(() => new NameKey(String.Empty));
            // ReSharper restore ObjectCreationAsStatement
        }
    }
}
