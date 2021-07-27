using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Domain
{
    public struct CrackersParameters
    {
        public int quantity;
        public DateTime entryDate;
        public DateTime expirationDate;
    }
    [Serializable]
    class Crackers : Product
    {
        public Crackers(CrackersParameters crackersParameters)
: base()
        {
            MeasurableUnitType = MeasurableUnitTypes.Pack;
            MeasurableUnitWeight = 1;
            EntryDate = crackersParameters.entryDate;
            ExpirationDate = crackersParameters.expirationDate;
            Quantity = crackersParameters.quantity;
            PricePerUnit = 2;
        }

        public override float ComputePrice()
        {
            float price = Quantity * PricePerUnit;
            return price;
        }


        public override string ToString()
        {
            float price = ComputePrice();
            float weight = this.ComputeWeight();
            string message = "Crackers: " +this.Quantity + " " + this.MeasurableUnitType + " (" + weight + " kg), " +
                "Unit price: " + this.PricePerUnit + " total price: " + price.ToString();
            return message;
        }

    }
}
