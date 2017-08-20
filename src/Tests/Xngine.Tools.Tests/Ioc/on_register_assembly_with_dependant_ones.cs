using Autofac;
using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Xngine.Packer.Model.ImageProcessing;
using Xngine.Tools.Commons.Ioc;
using Xngine.Tools.Commons.Xml;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Ioc
{
    public class on_register_assembly_with_dependant_ones : AAATest
    {
        private Assembly[] assembiles;
        private ContainerBuilder containerBuilder;
        private IContainer container;

        protected override void Arrange()
        {
            assembiles = AssemblyFinder.GetCurrentAssemblyWithDependencies();
            containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterDependencies(assembiles);
        }

        protected override void Act()
        {
            container = containerBuilder.Build();
        }

        [Assert]
        public void XmlSerializer_dependency_can_be_resolved()
        {
            var serializer = container.Resolve<IXmlSerializer>();
            serializer.Should().NotBeNull();
        }

        [Assert]
        public void all_ConfigCreators_should_be_resolved()
        {
            var creators = container.Resolve<IEnumerable<IConfigCreator>>();
            creators.Should().NotBeNull();
            creators.Should().NotBeEmpty();
        }
    }
}
