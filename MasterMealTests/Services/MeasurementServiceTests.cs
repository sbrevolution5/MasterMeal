using NUnit.Framework;
using MasterMealBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterMealBlazor.Enums;

namespace MasterMealBlazor.Services.Tests
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
        [TestCase(24,"1 Ounce")]
        [TestCase(384,"1 Pound")]
        [TestCase(24*8, "1/2 Pounds")]
        [TestCase(20*24, "1 1/4 Pounds")]
        [TestCase(24*24, "1 1/2 Pounds")]
        public void DecodeMassMeasurementTest_SimpleInput_ReturnsCorrectUnit(int input, string expected)
        {
            var result = _measurementService.DecodeMassMeasurement(input);
            Assert.That(result, Does.Contain(expected));
        }
        [Test()]
        [TestCase(16*24,"(16 oz.)")]
        [TestCase(8*24, "(8 oz.)")]
        [TestCase(20*24, "(20 oz.)")]
        [TestCase(17*24, "(17 oz.)")]
        public void DecodeMassMeasurementTest_SimpleInput_ReturnsCorrectOunce(int input, string expected)
        {
            var result = _measurementService.DecodeMassMeasurement(input);
            Assert.That(result, Does.Contain(expected));
        }

        [Test()]
        [TestCase(4, Fraction.Half, VolumeMeasurementUnit.Cup, 5184)]
        [TestCase(1, Fraction.NoFraction, VolumeMeasurementUnit.Gallon, 18432)]
        public void EncodeLiquidMeasurementTest(int wholeNum, Fraction fraction, VolumeMeasurementUnit unit, int expected)
        {
            var result = _measurementService.EncodeVolumeMeasurement(wholeNum, fraction, unit);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test()]
        [TestCase(1, Fraction.Half, MassMeasurementUnit.pound, 24*24)]
        [TestCase(1, Fraction.NoFraction, MassMeasurementUnit.ounce, 24)]
        [TestCase(15, Fraction.NoFraction, MassMeasurementUnit.ounce, 15*24)]
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
        [TestCase(Fraction.Half, "1/2")]
        public void FractionToStringTest(Fraction input, string expected)
        {
            var result = _measurementService.FractionToString(input);
            Assert.That(result, Is.EqualTo(expected));

        }
    }
}

