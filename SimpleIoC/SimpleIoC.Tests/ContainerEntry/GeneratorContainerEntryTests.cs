using System;
using NUnit.Framework;
using Rhino.Mocks;
using SimpleIoC.ContainerEntry;

namespace SimpleIoC.Tests.ContainerEntry
{
    [TestFixture]
    public class GeneratorContainerEntryTests
    {
        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository();
        }

        [Test]
        public void TestValueCreation()
        {
            IServiceContainer container = _repository.Stub<IServiceContainer>();
            CreateFunc<String> initializer;
            using (_repository.Record())
            {
                initializer = _repository.StrictMock<CreateFunc<String>>();
                Expect.Call(initializer(container)).Return("IDDQD").Repeat.Times(2);
            }
            using (_repository.Playback())
            {
                GeneratorContainerEntry<String> entry = new GeneratorContainerEntry<String>(initializer);
                Assert.AreEqual("IDDQD", entry.GetValue(container));
                Assert.AreEqual("IDDQD", entry.GetValue(container));
            }
        }

        private MockRepository _repository;
    }
}
