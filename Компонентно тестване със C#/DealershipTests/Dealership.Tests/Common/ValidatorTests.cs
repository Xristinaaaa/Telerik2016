using System;
using NUnit.Framework;
using Dealership.Common;
using System.Text.RegularExpressions;

namespace Dealership.Tests.Common
{
    [TestFixture]
    public class ValidatorTests
    {
        [TestCase(100,2,4)]
        [TestCase(3, 30, 34)]
        public void ValidateIntRange_IfOutOfRange_ShouldThrowException(int value, int min, int max)
        {
            string message = "Value out of range!";
            Assert.Throws<ArgumentException>(() => Validator.ValidateIntRange(value, min, max, message));
        }

        [Test]
        public void ValidateIntRange_ValidInput_ShouldWork()
        {
            TestDelegate test = () => Validator.ValidateIntRange(2, 1, 4, "Index out of range!");
            Assert.DoesNotThrow(test);
        }

        [TestCase(100.2, 2.245, 4.2535)]
        [TestCase(3.0, 30.35, 34.5)]
        public void ValidateDecimalRange_IfOutOfRange_ShouldThrowException(decimal value, decimal min, decimal max)
        {
            string message = "Value out of range!";
            Assert.Throws<ArgumentException>(() => Validator.ValidateDecimalRange(value, min, max, message));
        }

        [Test]
        public void ValidateDecimalRange_ValidInput_ShouldWork()
        {
            TestDelegate test = () => Validator.ValidateDecimalRange(2.35352M, 1.5325M, 4.53M, "Index out of range!");
            Assert.DoesNotThrow(test);
        }

        [Test]
        public void ValidateNull_WrongInput_ShouldThrowException()
        {
            object obj = null;
            string message = "Object value should not be null";
            Assert.Throws<ArgumentNullException>(() => Validator.ValidateNull(obj, message));
        }

        [Test]
        public void ValidateNull_IfStringIsNotNull_ShouldWork()
        {
            object obj = "helloo";
            string message = "Object value should not be null";
            Assert.DoesNotThrow(() => Validator.ValidateNull(obj, message));
        }

        [Test]
        public void ValidateSymbols_IfNoMatch_ShouldThrowException()
        {
            string message = "Does not match!";
            string value = "fdsfs";
            string pattern = @"\b(\w+((\r?\n)|,?\s))*\w+[.?:;!]";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Assert.Throws<ArgumentException>(() => Validator.ValidateSymbols(value, pattern, message));
        }

        [Test]
        public void ValidateSymbols_IfMatch_ShouldWork()
        {
            string message = "Does not match!";
            string value = "fdsfs";
            string pattern = @"([a-z])\w+";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Assert.DoesNotThrow(() => Validator.ValidateSymbols(value, pattern, message));
        }
    }
}
