using System;
using NUnit.Framework;
using SimpleIoC.Key;

namespace SimpleIoC.Tests.Key
{
    [TestFixture]
    public class TypeKeyBadArgsTests
    {
        [Test]
        public void BadArgsInCtor()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new TypeKey(null));
            // ReSharper restore ObjectCreationAsStatement
        }
    }
}
