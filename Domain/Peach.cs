using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Domain
{
    [Serializable]
    class Peach:Fruit
    {
        public Peach(SimpleFruitParameters peachParameters)
    : base()
        {
            MeasurableUnitType = MeasurableUnitTypes.Box;
            MeasurableUnitWeight = 6;
            EntryDate = peachParameters.entryDate;
            ExpirationDate = peachParameters.expirationDate;
            NutritionalQuality = peachParameters.nutritionalValue;
            Quantity = peachParameters.quantity;
            PricePerUnit = 30;
        }

        public override string ToString()
        {
            string message = "Peach :";
            message += base.ToString();
            return message;
        }
    }
}
