using MasterMeal.Enums;
using MasterMeal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services
{
    public class MeasurementService : IMeasurementService
    {
        public string DecodeLiquidMeasurement(int fracTSP)
        {
            throw new NotImplementedException();
        }

        public string DecodeMassMeasurement(int fracOz)
        {
            throw new NotImplementedException();
        }

        public int EncodeLiquidMeasurement(int wholeNumber, Fraction fraction, LiquidMeasurementUnit unit)
        {
            int conversionFactor;
            if (unit == LiquidMeasurementUnit.Teaspoon)
            {
                conversionFactor = 24;
            }else if (unit == LiquidMeasurementUnit.Tablespoon)
            {
                conversionFactor = 3*24;
            }else if (unit == LiquidMeasurementUnit.Ounce)
            {
                conversionFactor = 2*3*24;
            }else if (unit == LiquidMeasurementUnit.Cup)
            {
                conversionFactor = 8*2*3*24;
            }else if (unit == LiquidMeasurementUnit.Pint)
            {
                conversionFactor = 2* 8 * 2 * 3 * 24;
            }else if (unit == LiquidMeasurementUnit.Quart)
            {
                conversionFactor = 2*2* 8 * 2 * 3 * 24;
            }else //Must be Gallon
            {
                conversionFactor = 4* 2 * 2 * 8 * 2 * 3 * 24;

            }
            int convertedFraction = (int)(FractionToDouble(fraction)*conversionFactor);
            int convertedWhole = wholeNumber * conversionFactor;
            return convertedFraction + convertedWhole;
        }

        public int EncodeMassMeasurement(int wholeNumber, Fraction fraction, MassMeasurementUnit unit)
        {
            throw new NotImplementedException();
        }
        public double FractionToDouble(Fraction fraction)
        {
            double res;
            if (fraction == Fraction.OneQuarter)
            {
                res = 1 / 4;
            }else if (fraction == Fraction.OneThird)
            {
                res = 1 / 3;
            }else if (fraction == Fraction.Half)
            {
                res = 1 / 2;
            }else if (fraction == Fraction.TwoThirds)
            {
                res = 2 / 3; 
            }else if (fraction == Fraction.ThreeQuarters)
            {
                res = 3 / 4;
            }else 
            {
                res = 0d;
            }
            return res;
        }
    }
}
