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
        public void Convert_ShouldReturnOutOfRangeWhenTheValueIsNotBetweeOneAnd3999()
        {
            RomanNumberConverter roman = new RomanNumberConverter();
        }

        [Test]
        [TestCase("1", "I")]
        [TestCase("2", "V")]
        [TestCase("3", "X")]
        [TestCase("4", "L")]
        public void Convert_ShouldCorrectlyConvertValidNumbers(string een, string twee)
        {
            RomanNumberConverter roman = new RomanNumberConverter();
        }
    }
}
