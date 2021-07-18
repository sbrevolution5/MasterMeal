using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterMeal.Enums;

namespace MasterMeal.Services.Interfaces
{
    public interface IMeasurementService
    {
        public string DecodeLiquidMeasurement(int fracTSP);
        public int EncodeLiquidMeasurement(int wholeNumber, Fraction fraction, LiquidMeasurementUnit unit);
        public string DecodeMassMeasurement(int fracOz);
        public int EncodeMassMeasurement(int wholeNumber, Fraction fraction, MassMeasurementUnit unit);
        public double FractionToDouble(Fraction fraction);
        public Fraction DoubleToFraction(double input);
        public string FractionToString(Fraction fraction);

    }
}
