using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Domain
{
    public struct SimpleVegetableParameters
    {
        public int quantity;
        public int nutritionalValue;
        public string producer;
        public DateTime entryDate;
        public DateTime expirationDate;
    }
    [Serializable]
    class Potato:Vegetable
    {
        public Potato(SimpleVegetableParameters potatoParameters)
    : base()
        {
            MeasurableUnitType = MeasurableUnitTypes.Bag;
            MeasurableUnitWeight = 10;
            EntryDate = potatoParameters.entryDate;
            ExpirationDate = potatoParameters.expirationDate;
            NutritionalQuality = potatoParameters.nutritionalValue;
            Quantity = potatoParameters.quantity;
            Producer = potatoParameters.producer;
            PricePerUnit = 15;
        }

        public override string ToString()
        {
            string message = "Potato :";
            message += base.ToString();
            return message;
        }
    }
}
