using System;
using IntergalacticTravel;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.ResourceFactory.Tests
{
    [TestFixture]
    public class ResourceFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_WhenValidInput_ShouldReturnNewResources(string command)
        {
            var resourcesFactory = new ResourcesFactory();

            var result = resourcesFactory.GetResources(command);

            Assert.IsInstanceOf<Resources>(result);
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand ")]
        public void GetResources_WhenInvalidInputIsPassed_ShouldThrowException(string command)
        {
            var resourcesFactory = new ResourcesFactory();
            
            Assert.That(() => resourcesFactory.GetResources(command), Throws.InvalidOperationException.With.Message.Contains("command"));
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444) ")]
        public void GetResources_WhenInputStringIsNotInCorrectFormat_ShouldThrowException(string command)
        {
            var resourcesFactory = new ResourcesFactory();

            Assert.Throws<OverflowException>(() => resourcesFactory.GetResources(command));
        }
    }
}
