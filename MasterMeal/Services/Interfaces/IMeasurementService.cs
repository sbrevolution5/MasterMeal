using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterMeal.Enums;

namespace MasterMeal.Services.Interfaces
{
    public interface IMeasurementService
    {
        public string DecodeLiquidMeasurement(int quarterTSP);
        public int EncodeLiquidMeasurement(int wholeNumber, Fraction fraction, LiquidMeasurementUnit unit);
        public string DecodeMassMeasurement(int quarterOz);
        public int EncodeMassMeasurement(int wholeNumber, Fraction fraction, MassMeasurementUnit unit);
    }
}
