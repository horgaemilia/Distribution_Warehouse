using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Domain
{
    public struct SimpleFruitParameters
        {
        public float quantity;
        public float nutritionalValue;
        public DateTime entryDate;
        public DateTime expirationDate;
        }
    class Apple:Fruit
    {
        public Apple(SimpleFruitParameters appleParameters)
            : base()
        {
            MeasurableUnitType = MeasurableUnitTypes.Kg;
            MeasurableUnitWeight = 1;
            EntryDate = appleParameters.entryDate;
            ExpirationDate = appleParameters.expirationDate;
            NutritionalQuality = appleParameters.nutritionalValue;
            Quantity = appleParameters.quantity;
            PricePerUnit = 4;
        }

    }
}
