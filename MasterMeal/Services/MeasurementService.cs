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
        public string DecodeVolumeMeasurement(int fracTSP)
        {
            VolumeMeasurementUnit unit;
            int conversionFactor;
            string unitString;
            if (fracTSP >= 4 * 2 * 2 * 8 * 2 * 3 * 24)
            {
                unitString = "Gallon";
                unit = VolumeMeasurementUnit.Gallon;
                conversionFactor = 4 * 2 * 2 * 8 * 2 * 3 * 24;
            }
            else if (fracTSP >= 2 * 2 * 8 * 2 * 3 * 24)
            {
                unitString = "Quart";
                unit = VolumeMeasurementUnit.Quart;
                conversionFactor = 2 * 2 * 8 * 2 * 3 * 24;
            }
            else if (fracTSP >= 2 * 8 * 2 * 3 * 24)
            {
                unitString = "Pint";
                unit = VolumeMeasurementUnit.Pint;
                conversionFactor = 2 * 8 * 2 * 3 * 24;
            }
            else if (fracTSP >= 4 * 3 * 24)
            {
                unitString = "Cup";
                unit = VolumeMeasurementUnit.Cup;
                conversionFactor = 8 * 2 * 3 * 24;

            }
            //else if (fracTSP >= 24 * 3 * 2)
            //{
            //    unitString = "Ounce";
            //    unit = VolumeMeasurementUnit.Ounce;
            //    conversionFactor = 2 * 3 * 24;
            //}
            else if (fracTSP >= 24 * 3 || fracTSP == 18 || fracTSP == 36 || fracTSP == 54)
            {
                unitString = "Tablespoon";
                unit = VolumeMeasurementUnit.Tablespoon;
                conversionFactor = 3 * 24;
            }
            else //Must be Teaspoon or less
            {
                unitString = "Teaspoon";
                unit = VolumeMeasurementUnit.Teaspoon;
                conversionFactor = 24;

            }
            //Get whats left from remainder
            string measurement = "";
            int remainder = fracTSP % conversionFactor;
            int howMany;
            float ozConversion = (float)fracTSP / (24f * 3f * 2f);
            if (remainder > 0)
            {
                //Add s to unit
                unitString += "s";
                //round down to whole unit
                fracTSP -= remainder;
                //if fraction > .75, just round to next whole number.
                if (remainder / conversionFactor > 0.75)
                {
                    fracTSP += conversionFactor;
                    howMany = fracTSP / conversionFactor;
                    measurement = howMany + " " + unitString + "(" + ozConversion + " oz.)";
                }
                else
                {
                    //Round up to fraction
                    string fraction = RemainderToFraction(remainder, unit);
                    howMany = fracTSP / conversionFactor;
                    if (howMany == 0)
                    {
                        measurement = fraction + " " + unitString + "(" + ozConversion + " oz.)";

                    }
                    else
                    {

                        measurement = howMany + " " + fraction + " " + unitString + "(" + ozConversion + " oz.)";
                    }
                }

            }
            else
            {
                howMany = fracTSP / conversionFactor;
                //add S to plurals
                if (howMany != 1)
                {
                    unitString += "s";
                }
                measurement = howMany + " " + unitString + "(" + ozConversion + " oz.)";

            }
            return measurement;
        }

        private string RemainderToFraction(int remainder, MassMeasurementUnit unit)
        {
            if (unit == MassMeasurementUnit.ounce)
            {
                return FractionToString(DoubleToFraction(remainder / 24d));
            }
            else
            {
                double fractionDouble = remainder / 24d*16d;
                return FractionToString(DoubleToFraction(fractionDouble));

            }
        }
        private string RemainderToFraction(int remainder, VolumeMeasurementUnit unit)
        {
            //TODO What if 1/3 And 3/4 are combined, or 1/3 1/2???
            if (unit == VolumeMeasurementUnit.Teaspoon)
            {
                return FractionToString(DoubleToFraction(remainder / 24d));
            }
            else if (unit == VolumeMeasurementUnit.Tablespoon)
            {
                var fraction = DoubleToFraction(remainder / (24d * 3d));
                return FractionToString(fraction);

            }
            else if (unit == VolumeMeasurementUnit.Ounce)
            {
                Fraction fraction = DoubleToFraction(remainder / (24d * 3d * 2d));
                return FractionToString(fraction);

            }
            else if (unit == VolumeMeasurementUnit.Cup)
            {
                Fraction fraction = DoubleToFraction(remainder / (24d * 3d * 2d * 8d));
                return FractionToString(fraction);

            }
            else if (unit == VolumeMeasurementUnit.Pint)
            {
                Fraction fraction = DoubleToFraction(remainder / (24d * 3d * 2d * 8d * 2d));
                return FractionToString(fraction);
            }
            else if (unit == VolumeMeasurementUnit.Quart)
            {
                Fraction fraction = DoubleToFraction(remainder / (24d * 3d * 2d * 8d * 2d * 2d));
                return FractionToString(fraction);

            }
            else if (unit == VolumeMeasurementUnit.Gallon)
            {
                Fraction fraction = DoubleToFraction(remainder / (24d * 3d * 2d * 8d * 2d * 2d * 4d));
                return FractionToString(fraction);

            }
            else
            {
                return "";
            }
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
        /// <summary>
        /// Converts a number of 1/2 ounce into real measurements
        /// </summary>
        /// <param name="fracOz"></param>
        /// <returns></returns>
        public string DecodeMassMeasurement(int fracOz)
        {
            string unitString = "";
            MassMeasurementUnit unit;
            int conversionFactor;
            if (fracOz >= 24*16 || fracOz == 24*8 || fracOz == 24*4 || fracOz == 24*12)
            {
                unitString = "Pound";
                unit = MassMeasurementUnit.pound;
                conversionFactor = 24*16;
            }
            else //Must be Ounce or less
            {
                unitString = "Ounce";
                unit = MassMeasurementUnit.ounce;
                conversionFactor = 24;

            }
            float ozConversion = (float)fracOz / 2f;
            //Get whats left from remainder
            string measurement;
            int remainder = fracOz % conversionFactor;
            int howMany;
            if (remainder > 0d)
            {
                //Add s to unit
                unitString += "s";
                //round down to whole unit
                fracOz -= remainder;
                if (remainder / conversionFactor > 0.75d)
                {
                    fracOz += conversionFactor;
                    howMany = fracOz / conversionFactor;
                    if (unitString != "Ounces")
                    {
                        measurement = howMany + " " + unitString + "(" + ozConversion + " oz.)";
                    }
                    else
                    {
                        measurement = howMany + " " + unitString;
                    }
                }
                else
                {

                    //Round up to fraction
                    string fraction = RemainderToFraction(remainder, unit);
                    howMany = fracOz / conversionFactor;
                    if (howMany == 0)
                    {
                        if (unitString != "Ounces")
                        {
                            measurement = fraction + " " + unitString + "(" + ozConversion + " oz.)";
                        }
                        else
                        {
                            measurement = fraction + " " + unitString;
                        }
                    }
                    else
                    {

                        if (unitString != "Ounces")
                        {
                            measurement = howMany + " " + fraction + " " + unitString + "(" + ozConversion + " oz.)";
                        }
                        else
                        {
                            measurement = howMany + " " + fraction + " " + unitString;
                        }
                    }
                }

            }
            else //no remainder
            {
                howMany = fracOz / conversionFactor;
                //add S to plurals
                if (howMany != 1)
                {
                    unitString += "s";
                }
                if (unitString != "Ounces")
                {
                    measurement = howMany + " " + unitString + "(" + ozConversion + " oz.)";
                }
                else
                {
                    measurement = howMany + " " + unitString;
                }

            }
            return measurement;
        }

        public int EncodeVolumeMeasurement(int wholeNumber, Fraction fraction, VolumeMeasurementUnit unit)
        {
            int conversionFactor;
            if (unit == VolumeMeasurementUnit.Teaspoon)
            {
                conversionFactor = 24;
            }
            else if (unit == VolumeMeasurementUnit.Tablespoon)
            {
                conversionFactor = 3 * 24;
            }
            else if (unit == VolumeMeasurementUnit.Ounce)
            {
                conversionFactor = 2 * 3 * 24;
            }
            else if (unit == VolumeMeasurementUnit.Cup)
            {
                conversionFactor = 8 * 2 * 3 * 24;
            }
            else if (unit == VolumeMeasurementUnit.Pint)
            {
                conversionFactor = 2 * 8 * 2 * 3 * 24;
            }
            else if (unit == VolumeMeasurementUnit.Quart)
            {
                conversionFactor = 2 * 2 * 8 * 2 * 3 * 24;
            }
            else //Must be Gallon
            {
                conversionFactor = 4 * 2 * 2 * 8 * 2 * 3 * 24;

            }
            int convertedFraction = Convert.ToInt32(FractionToDouble(fraction) * conversionFactor);
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
                res = 1d / 4d;
            }
            else if (fraction == Fraction.OneThird)
            {
                res = 1d / 3d;
            }
            else if (fraction == Fraction.Half)
            {
                res = 1d / 2d;
            }
            else if (fraction == Fraction.TwoThirds)
            {
                res = 2d / 3d;
            }
            else if (fraction == Fraction.ThreeQuarters)
            {
                res = 3d / 4d;
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

        public int EncodeUnitMeasurement(int quantityNumber, Fraction fraction)
        {
            int conversionFactor= 24;
            
            int convertedFraction = (int)(FractionToDouble(fraction) * conversionFactor);
            int convertedWhole = quantityNumber * conversionFactor;
            return convertedFraction + convertedWhole;
        }

        public string DecodeUnitMeasurement(int numberOfUnits)
        {
            string measurement;
            int remainder = numberOfUnits % 24;
            int howMany = (numberOfUnits -remainder)/24;
            double fractionDec = remainder/24d;
            string fraction = FractionToString(DoubleToFraction(fractionDec));
            if (fraction == "")
            {
                measurement = howMany.ToString();
            }
            else
            {
            measurement = $"{howMany} {fraction}";
            }
            return measurement;
        }
    }
}
