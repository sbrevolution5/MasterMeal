using NUnit.Framework;
using MasterMeal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterMeal.Enums;

namespace MasterMeal.Services.Tests
{
    [TestFixture()]
    public class MeasurementServiceTests
    {
        private MeasurementService _measurementService;
        [SetUp]
        public void SetUp()
        {
            _measurementService = new();
        }
        [Test]
        [TestCase(24,"1 Teaspoon")]
        [TestCase(72,"1 Tablespoon")]
        [TestCase(144, "1 Ounce")]
        [TestCase(1152, "1 Cup")]
        [TestCase(2304, "1 Pint")]
        [TestCase(4608, "1 Quart")]
        [TestCase(18432, "1 Gallon")]
        public void DecodeLiquidMeasurement_SimpleInput_ReturnsCorrectUnit(int input, string expected)
        {
            var result = _measurementService.DecodeLiquidMeasurement(input);
            Assert.That(result, Does.Contain(expected));
        }
        [Test]
        [TestCase(12,"1/2 Teaspoons")]
        [TestCase(18,"1/4 Tablespoons")]
        public void DecodeLiquidMeasurement_FractionalInput_ReturnsCorrectUnit(int input, string expected)
        {
            var result = _measurementService.DecodeLiquidMeasurement(input);
            Assert.That(result, Does.Contain(expected));
        }

        [Test()]
        public void DoubleToFractionTest()
        {
            Assert.Fail();
        }

        [Test()]
        [TestCase(2,"1 Ounce")]
        [TestCase(32,"1 Pound")]
        [TestCase(16, "8 Ounces")]
        [TestCase(40, "1 1/4 Pounds")]
        [TestCase(34, "1 1/4 Pounds")]
        public void DecodeMassMeasurementTest_SimpleInput_ReturnsCorrectUnit(int input, string expected)
        {
            var result = _measurementService.DecodeMassMeasurement(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test()]
        [TestCase(4, Fraction.Half, LiquidMeasurementUnit.Cup, 5184)]
        public void EncodeLiquidMeasurementTest(int wholeNum, Fraction fraction, LiquidMeasurementUnit unit, int expected)
        {
            var result = _measurementService.EncodeLiquidMeasurement(wholeNum, fraction, unit);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test()]
        public void EncodeMassMeasurementTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void FractionToDoubleTest()
        {
            var result = _measurementService.FractionToDouble(Fraction.Half);
            Assert.That(result, Is.EqualTo(0.5f));
        }

        [Test()]
        public void FractionToStringTest()
        {
            Assert.Fail();
        }
    }
}

namespace MasterMealTests.Services
{
    class MeasurementServiceTests
    {
    }
}
