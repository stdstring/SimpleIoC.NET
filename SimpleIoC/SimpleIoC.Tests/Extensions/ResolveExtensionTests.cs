using System;
using System.Collections.Generic;
using NUnit.Framework;
using SimpleIoC.Extensions;
using SimpleIoC.Tests.Utils;

namespace SimpleIoC.Tests.Extensions
{
    [TestFixture]
    public class ResolveExtensionTests
    {
        [Test]
        public void ResolveNameTypeServicesInSimpleContainer()
        {
            IServiceContainer container = new ServiceContainer();
            container.AddSimpleValueComponent("some name", "some value");
            container.AddSimpleValueComponent<String>("some other value");
            container.AddSimpleValueComponent<String>("key1", "IDDQD");
            container.AddSimpleValueComponent<String>("key2", "IDKFA");
            container.AddSimpleValueComponent<SomeData>("key3", new SomeData("IDCLIP"));
            TestCommonBody(container, new[] {"IDDQD", "IDKFA"});
        }

        [Test]
        public void ResolveNameTypeServicesInComplexContainer()
        {
            IServiceContainer mainContainer = new ServiceContainer();
            IServiceContainer subContainer = new ServiceContainer();
            mainContainer.AddSubContainer(subContainer);
            mainContainer.AddSimpleValueComponent("some name", "some value");
            subContainer.AddSimpleValueComponent<String>("some other value");
            mainContainer.AddSimpleValueComponent<String>("key1", "IDDQD");
            subContainer.AddSimpleValueComponent<String>("key2", "IDKFA");
            mainContainer.AddSimpleValueComponent<SomeData>("key3", new SomeData("IDCLIP"));
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
