using System;
using NUnit.Framework;
using SimpleIoC.Key;

namespace SimpleIoC.Tests.Key
{
    [TestFixture]
    public class NameTypeKeyBadArgsTests
    {
        [Test]
        public void BadArgsInCtor()
        {
            // ReSharper disable ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new NameTypeKey(null, typeof (String)));
            Assert.Throws<ArgumentNullException>(() => new NameTypeKey(String.Empty, typeof (String)));
            Assert.Throws<ArgumentNullException>(() => new NameTypeKey("IDDQD", null));
            // ReSharper restore ObjectCreationAsStatement
        }
    }
}
