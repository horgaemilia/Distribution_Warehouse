using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Domain
{
    [Serializable]
    class Orange:Fruit
    {
        public Orange(SimpleFruitParameters orangeParameters)
: base()
        {
            MeasurableUnitType = MeasurableUnitTypes.Bag;
            MeasurableUnitWeight = 2.5f;
            EntryDate = orangeParameters.entryDate;
            ExpirationDate = orangeParameters.expirationDate;
            NutritionalQuality = orangeParameters.nutritionalValue;
            Quantity = orangeParameters.quantity;
            PricePerUnit = 13;
        }

        public override string ToString()
        {
            string message = "Orange :";
            message += base.ToString();
            return message;
        }
    }
}
