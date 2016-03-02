using System;
using System.Collections.Generic;
using NUnit.Framework;
using SimpleIoC.Extensions;
using SimpleIoC.Tests.Utils;

namespace SimpleIoC.Tests.Extensions
{
    [TestFixture]
    public class ResolveExtensionsTests
    {
        [Test]
        public void BadArgsInResolveNameTypeServices()
        {
            IServiceContainer container = null;
            // ReSharper disable ExpressionIsAlwaysNull
            Assert.Throws<ArgumentNullException>(() => container.ResolveNameTypeServices<String>());
            // ReSharper restore ExpressionIsAlwaysNull
        }

        [Test]
        public void ResolveNameTypeServicesInSimpleContainer()
        {
            IServiceContainer container = new ServiceContainer();
            container.AddSimpleValueComponent("some name", new Object());
            container.AddSimpleValueComponent("some other value");
            container.AddSimpleValueComponent("key1", "IDDQD");
            container.AddSimpleValueComponent("key2", "IDKFA");
            container.AddSimpleValueComponent("key3", new SomeData("IDCLIP"));
            TestCommonBody(container, new[] {"IDDQD", "IDKFA"});
        }

        [Test]
        public void ResolveNameTypeServicesInComplexContainer()
        {
            IServiceContainer mainContainer = new ServiceContainer();
            IServiceContainer subContainer = new ServiceContainer();
            mainContainer.AddSubContainer(subContainer);
            mainContainer.AddSimpleValueComponent("some name", new Object());
            subContainer.AddSimpleValueComponent("some other value");
            mainContainer.AddSimpleValueComponent("key1", "IDDQD");
            subContainer.AddSimpleValueComponent("key2", "IDKFA");
            mainContainer.AddSimpleValueComponent("key3", new SomeData("IDCLIP"));
            TestCommonBody(mainContainer, new[] {"IDDQD", "IDKFA"});
        }

        private void TestCommonBody(IServiceContainer container, IList<String> expected)
        {
            IList<String> actual = container.ResolveNameTypeServices<String>();
            Assert.That(actual.Count, Is.EqualTo(expected.Count));
            foreach (String actualValue in actual)
                Assert.True(expected.Contains(actualValue));
        }
    }
}
