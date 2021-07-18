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
            LiquidMeasurementUnit unit;
            int conversionFactor;
            string unitString;
            if (fracTSP >= 4 * 2 * 2 * 8 * 2 * 3 * 24)
            {
                unitString = "Gallon";
                unit = LiquidMeasurementUnit.Gallon;
                conversionFactor = 4 * 2 * 2 * 8 * 2 * 3 * 24;
            }
            else if (fracTSP >= 2 * 2 * 8 * 2 * 3 * 24)
            {
                unitString = "Quart";
                unit = LiquidMeasurementUnit.Quart;
                conversionFactor = 2 * 2 * 8 * 2 * 3 * 24;
            }
            else if (fracTSP >= 2 * 8 * 2 * 3 * 24)
            {
                unitString = "Pint";
                unit = LiquidMeasurementUnit.Pint;
                conversionFactor = 2 * 8 * 2 * 3 * 24;
            }
            else if (fracTSP >= 8 * 2 * 3 * 24)
            {
                unitString = "Cup";
                unit = LiquidMeasurementUnit.Cup;
                conversionFactor = 8 * 2 * 3 * 24;

            }
            else if (fracTSP >= 24 * 3 * 2)
            {
                unitString = "Ounce";
                unit = LiquidMeasurementUnit.Ounce;
                conversionFactor = 2 * 3 * 24;
            }
            else if (fracTSP <= 24 * 3)
            {
                unitString = "Tablespoon";
                unit = LiquidMeasurementUnit.Tablespoon;
                conversionFactor = 3 * 24;
            }
            else //Must be Teaspoon or less
            {
                unitString = "Teaspoon";
                unit = LiquidMeasurementUnit.Teaspoon;
                conversionFactor = 24;

            }
            //Get whats left from remainder
            string measurement = "";
            int remainder = fracTSP % conversionFactor;
            int howMany;
            if (remainder > 0)
            {
                //Add s to unit
                unitString += "s";
                //round down to whole unit
                fracTSP -= remainder;
                //Round up to fraction
                string fraction = RemainderToFraction(remainder, unit);
                howMany = fracTSP / conversionFactor;
                measurement = howMany + fraction + unitString;

            }
            else
            {
                howMany = fracTSP / conversionFactor;
                //add S to plurals
                if (howMany != 1)
                {
                    unitString += "s";
                }
                measurement = howMany + unitString;

            }
            return measurement;
        }

        private string RemainderToFraction(int remainder, LiquidMeasurementUnit unit)
        {
            string frac = "";
            if (remainder == 0)
            {
                return frac;
            }
            else if (unit == LiquidMeasurementUnit.Teaspoon)
            {
                DoubleToFraction(remainder / 24);
            }
            else if (unit == LiquidMeasurementUnit.Tablespoon)
            {
                DoubleToFraction(remainder / 24 * 3);

            }
            else if (unit == LiquidMeasurementUnit.Ounce)
            {
                DoubleToFraction(remainder / 24 * 3 * 2);

            }
            else if (unit == LiquidMeasurementUnit.Cup)
            {
                DoubleToFraction(remainder / 24 * 3 * 2 * 8);

            }
            else if (unit == LiquidMeasurementUnit.Pint)
            {
                DoubleToFraction(remainder / 24 * 3 * 2 * 8 * 2);

            }
            else if (unit == LiquidMeasurementUnit.Quart)
            {
                DoubleToFraction(remainder / 24 * 3 * 2 * 8 * 2 * 2);

            }
            else if (unit == LiquidMeasurementUnit.Gallon)
            {
                DoubleToFraction(remainder / 24 * 3 * 2 * 8 * 2 * 2 * 4);

            }
            return frac;
        }
        /// <summary>
        /// Rounds up to ensure you have enough ingredient
        /// </summary>
        /// <param name="input">double to be converted</param>
        /// <returns></returns>
        public Fraction DoubleToFraction(double input)
        {
            if (input == 0)
            {
                return Fraction.Zero;
            }
            else if (input <= .25)
            {
                return Fraction.OneQuarter;
            }
            else if (input <= .34)
            {
                return Fraction.OneThird;
            }
            else if (input <= .5)
            {
                return Fraction.Half;
            }
            else if (input <= .68)
            {
                return Fraction.TwoThirds;
            }
            else
            {
                return Fraction.ThreeQuarters;
            }
        }

        public string DecodeMassMeasurement(int fracOz)
        {
            string unitString = "";
            LiquidMeasurementUnit unit;
            int conversionFactor;
            if (fracOz >= 4 * 2 * 2 * 8 * 2 * 3 * 24)
            {
                unitString = "Gallon";
                unit = LiquidMeasurementUnit.Gallon;
                conversionFactor = 4 * 2 * 2 * 8 * 2 * 3 * 24;
            }
            else if (fracOz >= 2 * 2 * 8 * 2 * 3 * 24)
            {
                unitString = "Quart";
                unit = LiquidMeasurementUnit.Quart;
                conversionFactor = 2 * 2 * 8 * 2 * 3 * 24;
            }
            else if (fracOz >= 2 * 8 * 2 * 3 * 24)
            {
                unitString = "Pint";
                unit = LiquidMeasurementUnit.Pint;
                conversionFactor = 2 * 8 * 2 * 3 * 24;
            }
            else if (fracOz >= 8 * 2 * 3 * 24)
            {
                unitString = "Cup";
                unit = LiquidMeasurementUnit.Cup;
                conversionFactor = 8 * 2 * 3 * 24;

            }
            else if (fracOz >= 24 * 3 * 2)
            {
                unitString = "Ounce";
                unit = LiquidMeasurementUnit.Ounce;
                conversionFactor = 2 * 3 * 24;
            }
            else if (fracOz <= 24 * 3)
            {
                unitString = "Tablespoon";
                unit = LiquidMeasurementUnit.Tablespoon;
                conversionFactor = 3 * 24;
            }
            else //Must be Teaspoon or less
            {
                unitString = "Teaspoon";
                unit = LiquidMeasurementUnit.Teaspoon;
                conversionFactor = 24;

            }
            //Get whats left from remainder
            string measurement = "";
            int remainder = fracOz % conversionFactor;
            int howMany;
            if (remainder > 0)
            {
                //Add s to unit
                unitString += "s";
                //round down to whole unit
                fracOz -= remainder;
                //Round up to fraction
                string fraction = RemainderToFraction(remainder, unit);
                howMany = fracOz / conversionFactor;
                measurement = howMany + fraction + unitString;

            }
            else
            {
                howMany = fracOz / conversionFactor;
                //add S to plurals
                if (howMany != 1)
                {
                    unitString += "s";
                }
                measurement = howMany + unitString;

            }
            return measurement;
        }

        public int EncodeLiquidMeasurement(int wholeNumber, Fraction fraction, LiquidMeasurementUnit unit)
        {
            int conversionFactor;
            if (unit == LiquidMeasurementUnit.Teaspoon)
            {
                conversionFactor = 24;
            }
            else if (unit == LiquidMeasurementUnit.Tablespoon)
            {
                conversionFactor = 3 * 24;
            }
            else if (unit == LiquidMeasurementUnit.Ounce)
            {
                conversionFactor = 2 * 3 * 24;
            }
            else if (unit == LiquidMeasurementUnit.Cup)
            {
                conversionFactor = 8 * 2 * 3 * 24;
            }
            else if (unit == LiquidMeasurementUnit.Pint)
            {
                conversionFactor = 2 * 8 * 2 * 3 * 24;
            }
            else if (unit == LiquidMeasurementUnit.Quart)
            {
                conversionFactor = 2 * 2 * 8 * 2 * 3 * 24;
            }
            else //Must be Gallon
            {
                conversionFactor = 4 * 2 * 2 * 8 * 2 * 3 * 24;

            }
            int convertedFraction = (int)(FractionToDouble(fraction) * conversionFactor);
            int convertedWhole = wholeNumber * conversionFactor;
            return convertedFraction + convertedWhole;
        }

        public int EncodeMassMeasurement(int wholeNumber, Fraction fraction, MassMeasurementUnit unit)
        {
            int conversionFactor;
            if (unit == MassMeasurementUnit.ounce)
            {
                conversionFactor = 24;
            }
            else //Unit must be pounds
            {
                conversionFactor = 24 * 16;
            }
            int convertedFraction = (int)(FractionToDouble(fraction) * conversionFactor);
            int convertedWhole = wholeNumber * conversionFactor;
            return convertedFraction + convertedWhole;
        }
        public double FractionToDouble(Fraction fraction)
        {
            double res;
            if (fraction == Fraction.OneQuarter)
            {
                res = 1 / 4;
            }
            else if (fraction == Fraction.OneThird)
            {
                res = 1 / 3;
            }
            else if (fraction == Fraction.Half)
            {
                res = 1 / 2;
            }
            else if (fraction == Fraction.TwoThirds)
            {
                res = 2 / 3;
            }
            else if (fraction == Fraction.ThreeQuarters)
            {
                res = 3 / 4;
            }
            else
            {
                res = 0d;
            }
            return res;
        }
        public string FractionToString(Fraction fraction)
        {
            string res;
            if (fraction == Fraction.OneQuarter)
            {
                res = "1/4";
            }
            else if (fraction == Fraction.OneThird)
            {
                res = "1/3";
            }
            else if (fraction == Fraction.Half)
            {
                res = "1/2";
            }
            else if (fraction == Fraction.TwoThirds)
            {
                res = "2/3";
            }
            else if (fraction == Fraction.ThreeQuarters)
            {
                res = "3/4";
            }
            else
            {
                res = "";
            }
            return res;
        }
    }
}
