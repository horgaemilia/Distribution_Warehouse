using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Domain
{
    [Serializable]
    class Onion: Vegetable
    {
        public Onion(SimpleVegetableParameters onionParameters)
    : base()
        {
            MeasurableUnitType = MeasurableUnitTypes.Bag;
            MeasurableUnitWeight = 4;
            EntryDate = onionParameters.entryDate;
            ExpirationDate = onionParameters.expirationDate;
            NutritionalQuality = onionParameters.nutritionalValue;
            Quantity = onionParameters.quantity;
            Producer = onionParameters.producer;
            PricePerUnit = 2.5F;
        }

        public override string ToString()
        {
            string message = "Onion :";
            message += base.ToString();
            return message;
        }
    }


}
