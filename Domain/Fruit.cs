using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Domain
{
    public struct FruitParameters
    {
        public ProductParameters productParameters;
        public float NutritionalQuality;
    }
    class Fruit:Product
    {
        public float NutritionalQuality { get; set; }

        public Fruit(MeasurableUnitTypes measurableUnitType, float measurableUnitWeight, DateTime entryDate, DateTime expirationDate, float pricePerUnit, float nutritionalQuality, float quantity)
        :base(measurableUnitType,measurableUnitWeight,entryDate,expirationDate,pricePerUnit,quantity)
        {
            NutritionalQuality = nutritionalQuality;
        }

        public Fruit(FruitParameters fruitParameters)
            :base (fruitParameters.productParameters)
        {
            NutritionalQuality = fruitParameters.NutritionalQuality;   
        }

        public Discount Discount()
        {
            throw new NotImplementedException();
        }

        public Fruit() { }

        public override float ComputePrice()
        {
            throw new NotImplementedException();
        }

    }
}
