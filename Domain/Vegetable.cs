using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Domain
{
    public struct VegetableParameters
    {
        public ProductParameters productParameters;
        public float nutritionalQuality;
        public string producer;
    }
    class Vegetable:Product
    {
        public float NutritionalQuality { get; set; }

        public string Producer { get; set; }

        public Vegetable(MeasurableUnitTypes measurableUnitType, float measurableUnitWeight, DateTime entryDate, DateTime expirationDate, float pricePerUnit, float quantity, float nutritionalQuality, string producer)
: base(measurableUnitType, measurableUnitWeight, entryDate, expirationDate, pricePerUnit, quantity)
        {
            NutritionalQuality = nutritionalQuality;
            Producer = producer;
        }

        public Vegetable(VegetableParameters vegetableParameters)
            : base(vegetableParameters.productParameters)
        {
            NutritionalQuality = vegetableParameters.nutritionalQuality;
            Producer = vegetableParameters.producer;
        }

        public Vegetable() { }


        public override float ComputePrice()
        {
            throw new NotImplementedException();
        }


    }
}
