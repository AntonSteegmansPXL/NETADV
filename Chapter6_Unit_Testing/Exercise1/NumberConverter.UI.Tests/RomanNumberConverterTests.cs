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

            Assert.Throws<ArgumentException>(() => { roman.Convert(new object(), null, null, null); });
        }

        [Test]

        public void Convert_ShouldReturnInvalidNumberWhenTheValueCannotBeParsedAsAnInteger()
        {
            Assert.Fail("Test not implemented yet.");
        }

        [Test]
        public void Convert_ShouldReturnOutOfRangeWhenTheValueIsNotBetweeOneAnd3999()
        {
            Assert.Fail("Test not implemented yet.");
        }

        [Test]
        [TestCase("1", "I")]
        [TestCase("2", "V")]
        [TestCase("3", "X")]
        [TestCase("4", "L")]
        public void Convert_ShouldCorrectlyConvertValidNumbers(string een, string twee)
        {
            RomanNumberConverter roman = new RomanNumberConverter();

            Assert.That(roman.Convert(een) Is.EqualTo("I"));
        }
    }
}
