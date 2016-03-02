using System;
using NUnit.Framework;
using Rhino.Mocks;
using SimpleIoC.ContainerEntry;
using SimpleIoC.Extensions;

namespace SimpleIoC.Tests.Extensions
{
    [TestFixture]
    public class ReplaceExtensionsTests
    {
        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository();
            _container = _repository.StrictMock<IServiceContainer>();
        }

        [Test]
        public void ReplaceKey()
        {
            IContainerEntry entry = _repository.Stub<IContainerEntry>();
            ReplaceComponentKeyExpectations(entry);
            using (_repository.Playback())
                _container.ReplaceComponent(_key, entry);
        }

        [Test]
        public void ReplaceKeyBySimpleValueComponent()
        {
            ReplaceComponentKeyExpectations(typeof (SimpleContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceBySimpleValueComponent(_key, _value);
        }

        [Test]
        public void ReplaceKeyByLazyValueComponent()
        {
            ReplaceComponentKeyExpectations(typeof (LazyContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByLazyValueComponent(_key, _ => _value);
        }

        [Test]
        public void ReplaceKeyByGeneratorValueComponent()
        {
            ReplaceComponentKeyExpectations(typeof (GeneratorContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByGeneratorComponent(_key, _ => _value);
        }

        [Test]
        public void ReplaceName()
        {
            IContainerEntry entry = _repository.Stub<IContainerEntry>();
            ReplaceComponentNameExpectations(entry);
            using (_repository.Playback())
                _container.ReplaceComponent(Name, entry);
        }

        [Test]
        public void ReplaceNameBySimpleValueComponent()
        {
            ReplaceComponentNameExpectations(typeof (SimpleContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceBySimpleValueComponent(Name, _value);
        }

        [Test]
        public void ReplaceNameByLazyValueComponent()
        {
            ReplaceComponentNameExpectations(typeof (LazyContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByLazyValueComponent(Name, _ => _value);
        }

        [Test]
        public void ReplaceNameByGeneratorValueComponent()
        {
            ReplaceComponentNameExpectations(typeof (GeneratorContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByGeneratorComponent(Name, _ => _value);
        }

        [Test]
        public void ReplaceType()
        {
            IContainerEntry entry = _repository.Stub<IContainerEntry>();
            ReplaceComponentTypeExpectations<Object>(entry);
            using (_repository.Playback())
                _container.ReplaceComponent<Object>(entry);
        }

        [Test]
        public void ReplaceTypeBySimpleValueComponent()
        {
            ReplaceComponentTypeExpectations<Object>(typeof (SimpleContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceBySimpleValueComponent(_value);
        }

        [Test]
        public void ReplaceTypeByLazyValueComponent()
        {
            ReplaceComponentTypeExpectations<Object>(typeof (LazyContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByLazyValueComponent(_ => _value);
        }

        [Test]
        public void ReplaceTypeByGeneratorValueComponent()
        {
            ReplaceComponentTypeExpectations<Object>(typeof (GeneratorContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByGeneratorComponent(_ => _value);
        }

        [Test]
        public void ReplaceTypeExact()
        {
            IContainerEntry entry = _repository.Stub<IContainerEntry>();
            ReplaceComponentTypeExactExpectations(typeof (Object), entry);
            using (_repository.Playback())
                _container.ReplaceComponent(typeof (Object), entry);
        }

        [Test]
        public void ReplaceTypeExactBySimpleValueComponent()
        {
            ReplaceComponentTypeExactExpectations(typeof (Object), typeof (SimpleContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceBySimpleValueComponent(typeof (Object), _value);
        }

        [Test]
        public void ReplaceTypeExactByLazyValueComponent()
        {
            ReplaceComponentTypeExactExpectations(typeof (Object), typeof (LazyContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByLazyValueComponent(typeof (Object), _ => _value);
        }

        [Test]
        public void ReplaceTypeExactByGeneratorValueComponent()
        {
            ReplaceComponentTypeExactExpectations(typeof (Object), typeof (GeneratorContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByGeneratorComponent(typeof (Object), _ => _value);
        }

        [Test]
        public void ReplaceNameType()
        {
            IContainerEntry entry = _repository.Stub<IContainerEntry>();
            ReplaceComponentNameTypeExpectations<Object>(entry);
            using (_repository.Playback())
                _container.ReplaceComponent<Object>(Name, entry);
        }

        [Test]
        public void ReplaceNameTypeBySimpleValueComponent()
        {
            ReplaceComponentNameTypeExpectations<Object>(typeof (SimpleContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceBySimpleValueComponent<Object>(Name, _value);
        }

        [Test]
        public void ReplaceNameTypeByLazyValueComponent()
        {
            ReplaceComponentNameTypeExpectations<Object>(typeof (LazyContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByLazyValueComponent<Object>(Name, _ => _value);
        }

        [Test]
        public void ReplaceNameTypeByGeneratorValueComponent()
        {
            ReplaceComponentNameTypeExpectations<Object>(typeof (GeneratorContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByGeneratorComponent<Object>(Name, _ => _value);
        }

        [Test]
        public void ReplaceNameTypeExact()
        {
            IContainerEntry entry = _repository.Stub<IContainerEntry>();
            ReplaceComponentNameTypeExactExpectations(typeof (Object), entry);
            using (_repository.Playback())
                _container.ReplaceComponent(Name, typeof (Object), entry);
        }

        [Test]
        public void ReplaceNameTypeExactBySimpleValueComponent()
        {
            ReplaceComponentNameTypeExactExpectations(typeof (Object), typeof (SimpleContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceBySimpleValueComponent(Name, typeof (Object), _value);
        }

        [Test]
        public void ReplaceNameTypeExactByLazyValueComponent()
        {
            ReplaceComponentNameTypeExactExpectations(typeof (Object), typeof (LazyContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByLazyValueComponent(Name, typeof (Object), _ => _value);
        }

        [Test]
        public void ReplaceNameTypeExactByGeneratorValueComponent()
        {
            ReplaceComponentNameTypeExactExpectations(typeof (Object), typeof (GeneratorContainerEntry<Object>));
            using (_repository.Playback())
                _container.ReplaceByGeneratorComponent(Name, typeof (Object), _ => _value);
        }

        private void ReplaceComponentKeyExpectations(IContainerEntry entry)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent(_key)).Repeat.Once();
                Expect.Call(() => _container.AddComponent(_key, entry)).Repeat.Once();
            }
        }

        private void ReplaceComponentKeyExpectations(Type entryType)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent(_key)).Repeat.Once();
                Expect.Call(() => _container.AddComponent(Arg<Object>.Is.Equal(_key), Arg<IContainerEntry>.Matches(entry => entry.GetType() == entryType)))
                    .Repeat
                    .Once();
            }
        }

        private void ReplaceComponentNameExpectations(IContainerEntry entry)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent(Name)).Repeat.Once();
                Expect.Call(() => _container.AddComponent(Name, entry)).Repeat.Once();
            }
        }

        private void ReplaceComponentNameExpectations(Type entryType)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent(Name)).Repeat.Once();
                Expect.Call(() => _container.AddComponent(Arg<String>.Is.Equal(Name), Arg<IContainerEntry>.Matches(entry => entry.GetType() == entryType)))
                    .Repeat
                    .Once();
            }
        }

        private void ReplaceComponentTypeExpectations<T>(IContainerEntry entry)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent<T>()).Repeat.Once();
                Expect.Call(() => _container.AddComponent<T>(entry)).Repeat.Once();
            }
        }

        private void ReplaceComponentTypeExpectations<T>(Type entryType)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent<T>()).Repeat.Once();
                Expect.Call(() => _container.AddComponent<T>(Arg<IContainerEntry>.Matches(entry => entry.GetType() == entryType)))
                    .Repeat
                    .Once();
            }
        }

        private void ReplaceComponentTypeExactExpectations(Type componentType, IContainerEntry entry)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent(componentType)).Repeat.Once();
                Expect.Call(() => _container.AddComponent(componentType, entry)).Repeat.Once();
            }
        }

        private void ReplaceComponentTypeExactExpectations(Type componentType, Type entryType)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent(componentType)).Repeat.Once();
                Expect.Call(() => _container.AddComponent(Arg<Type>.Is.Equal(componentType), Arg<IContainerEntry>.Matches(entry => entry.GetType() == entryType)))
                    .Repeat
                    .Once();
            }
        }

        private void ReplaceComponentNameTypeExpectations<T>(IContainerEntry entry)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent<T>(Name)).Repeat.Once();
                Expect.Call(() => _container.AddComponent<T>(Name, entry)).Repeat.Once();
            }
        }

        private void ReplaceComponentNameTypeExpectations<T>(Type entryType)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent<T>(Name)).Repeat.Once();
                Expect.Call(() => _container.AddComponent<T>(Arg<String>.Is.Equal(Name), Arg<IContainerEntry>.Matches(entry => entry.GetType() == entryType)))
                    .Repeat
                    .Once();
            }
        }

        private void ReplaceComponentNameTypeExactExpectations(Type componentType, IContainerEntry entry)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent(Name, componentType)).Repeat.Once();
                Expect.Call(() => _container.AddComponent(Name, componentType, entry)).Repeat.Once();
            }
        }

        private void ReplaceComponentNameTypeExactExpectations(Type componentType, Type entryType)
        {
            using (_repository.Record())
            {
                Expect.Call(() => _container.RemoveComponent(Name, componentType)).Repeat.Once();
                Expect.Call(() => _container.AddComponent(Arg<String>.Is.Equal(Name), Arg<Type>.Is.Equal(componentType), Arg<IContainerEntry>.Matches(entry => entry.GetType() == entryType)))
                    .Repeat
                    .Once();
            }
        }

        private MockRepository _repository;
        private IServiceContainer _container;

        private readonly Object _key = new Object();
        private readonly Object _value = new Object();

        private const String Name = "some_name";
    }
}
