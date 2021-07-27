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

    }
}
