using NumberConverter.UI.Converters;
using NUnit.Framework;
using System;

namespace NumberConverter.UI.Tests
{
    [TestFixture]
    public class RomanNumberConverterTests
    {
        [Test]
        public void Convert_ShouldThrowArgumentExceptionWhenValueIsNotAString()
        {
            RomanNumberConverter roman = new RomanNumberConverter();

            Assert.That(() =>
            {
                roman.Convert(new object(), null, null, null);

            }).Throws.InstanceOf<ArgumentException>().With.Message.Contains("string");

        }

        [Test]
        [TestCase("hallo")]
        [TestCase("!")]
        [TestCase("")]
        public void Convert_ShouldReturnInvalidNumberWhenTheValueCannotBeParsedAsAnInteger(string par)
        {
            RomanNumberConverter roman = new RomanNumberConverter();
            roman.Convert(par, null, null, null);
            Assert.That(roman.Convert(par, null, null, null) == "Invalid number");
        }

        [Test]
        public void Convert_ShouldReturnOutOfRangeWhenTheValueIsNotBetweeOneAnd3999(string parameter)
        {
            RomanNumberConverter roman = new RomanNumberConverter();
            Assert.That(roman.Convert(4000, null, null, null) == "Out of range");
        }

        [Test]
        [TestCase("1", "I")]
        [TestCase("5", "V")]
        [TestCase("10", "X")]
        [TestCase("50", "L")]
        public void Convert_ShouldCorrectlyConvertValidNumbers(string een, string twee)
        {
            RomanNumberConverter roman = new RomanNumberConverter();
            Assert.That(Equals(twee, roman.Convert(een, null, null, null)));

        }
    }
}
