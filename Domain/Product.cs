using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Domain
{
    public struct Discount
    {
        public float DiscountPercenage;
        public float DiscountValue;
    }
    public enum MeasurableUnitTypes
    {
        Kg,
        Bag,
        Box,
        Pack
    }

    public enum Types
    {
        Apples,
        Potatoes,
        Onions,
        Peaches,
        Oranges,
        Crackers
    }

    public struct ProductParameters
    {
        public MeasurableUnitTypes measurableUnitTypes;
        public float measurableUnitWeight;
        public DateTime entryDate;
        public DateTime expirationDate;
        public float pricePerUnit;
        public float Quantity;
    }


    abstract class Product
    {
        public MeasurableUnitTypes MeasurableUnitType { get; set; }
        public float MeasurableUnitWeight { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public float PricePerUnit { get; set; }

        public float Quantity { get; set; }


        public Product(MeasurableUnitTypes measurableUnitType, float measurableUnitWeight, DateTime entryDate, DateTime expirationDate, float pricePerUnit, float Quantity)
        {
            MeasurableUnitType = measurableUnitType;
            MeasurableUnitWeight = measurableUnitWeight;
            EntryDate = entryDate;
            ExpirationDate = expirationDate;
            PricePerUnit = pricePerUnit;
        }

        public Product(ProductParameters productParameters)
        {
            MeasurableUnitType = productParameters.measurableUnitTypes;
            MeasurableUnitWeight = productParameters.measurableUnitWeight;
            EntryDate = productParameters.entryDate;
            ExpirationDate = productParameters.expirationDate;
            PricePerUnit = productParameters.pricePerUnit;
        }

        public Product() { }


        public bool IsExpired()
        {
            return DateTime.Compare(ExpirationDate, DateTime.Now) >= 0;
        }

        public abstract float ComputePrice();

        public float ComputeWeight()
        {
            return Quantity * MeasurableUnitWeight;
        }
    }
}
