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
        [TestCase(144, "2 Tablespoons")]
        [TestCase(1152, "1 Cup")]
        [TestCase(2304, "1 Pint")]
        [TestCase(4608, "1 Quart")]
        [TestCase(18432, "1 Gallon")]
        public void DecodeLiquidMeasurement_SimpleInput_ReturnsCorrectUnit(int input, string expected)
        {
            var result = _measurementService.DecodeVolumeMeasurement(input);
            Assert.That(result, Does.Contain(expected));
        }
        [Test]
        [TestCase(12,"1/2 Teaspoons")]
        [TestCase(18,"1/4 Tablespoons")]
        [TestCase(54, "3/4 Tablespoons")]
        [TestCase(36, "1/2 Tablespoons")]
        public void DecodeLiquidMeasurement_FractionalInput_ReturnsCorrectUnit(int input, string expected)
        {
            var result = _measurementService.DecodeVolumeMeasurement(input);
            Assert.That(result, Does.Contain(expected));
        }
        [Test]
        [TestCase(1152,"8 oz.")]
        [TestCase(18,"0.125 oz.")]
        public void DecodeLiquidMeasurement_FractionalInput_ReturnsCorrectOunce(int input, string expected)
        {
            var result = _measurementService.DecodeVolumeMeasurement(input);
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
        [TestCase(16, "1/2 Pounds")]
        [TestCase(40, "1 1/4 Pounds")]
        [TestCase(34, "1 1/4 Pounds")]
        public void DecodeMassMeasurementTest_SimpleInput_ReturnsCorrectUnit(int input, string expected)
        {
            var result = _measurementService.DecodeMassMeasurement(input);
            Assert.That(result, Does.Contain(expected));
        }
        [Test()]
        [TestCase(32,"(16 oz.)")]
        [TestCase(16, "(8 oz.)")]
        [TestCase(40, "(20 oz.)")]
        [TestCase(34, "(17 oz.)")]
        public void DecodeMassMeasurementTest_SimpleInput_ReturnsCorrectOunce(int input, string expected)
        {
            var result = _measurementService.DecodeMassMeasurement(input);
            Assert.That(result, Does.Contain(expected));
        }

        [Test()]
        [TestCase(4, Fraction.Half, VolumeMeasurementUnit.Cup, 5184)]
        [TestCase(1, Fraction.Zero, VolumeMeasurementUnit.Gallon, 18432)]
        public void EncodeLiquidMeasurementTest(int wholeNum, Fraction fraction, VolumeMeasurementUnit unit, int expected)
        {
            var result = _measurementService.EncodeVolumeMeasurement(wholeNum, fraction, unit);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test()]
        [TestCase(1, Fraction.Half, MassMeasurementUnit.pound, 48)]
        [TestCase(1, Fraction.Zero, MassMeasurementUnit.ounce, 2)]
        [TestCase(15, Fraction.Zero, MassMeasurementUnit.ounce, 30)]
        public void EncodeMassMeasurementTest(int wholeNum, Fraction fraction, MassMeasurementUnit unit, int expected)
        {
            var result = _measurementService.EncodeMassMeasurement(wholeNum, fraction, unit);
            Assert.That(result, Is.EqualTo(expected));
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

