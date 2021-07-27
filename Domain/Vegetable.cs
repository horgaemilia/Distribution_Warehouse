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
    [Serializable]
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

        private float ComputePriceWithoutDiscount()
        {
            float price = Quantity * PricePerUnit;
            return price;
        }
        public override float ComputePrice()
        {
            Discount discount = this.ComputeDiscount();
            return (this.ComputePriceWithoutDiscount() + discount.DiscountValue);
        }
        public Discount ComputeDiscount()
        {
            Discount discount = new Discount();
            int daysDifference = (int)(ExpirationDate - DateTime.Now).TotalDays;
            int weeks = daysDifference / 7;
            float priceWithoutDiscount = this.ComputePriceWithoutDiscount();
            float currentPrice = priceWithoutDiscount;
            if (weeks <= 4)
            {
                while (weeks <= 4)
                {
                    currentPrice = currentPrice * 0.95f;
                    weeks += 1;
                }
                discount.DiscountValue = priceWithoutDiscount - currentPrice;
                if (discount.DiscountValue == 0)
                {
                    discount.DiscountPercenage = 0;
                    return discount;
                }

                float percentage = (discount.DiscountValue / priceWithoutDiscount) * 100;
                discount.DiscountPercenage = percentage;
                return discount;
            }
            else
            {
                discount.DiscountValue = 0;
                discount.DiscountPercenage = 0;
                return discount;
            }
        }

        public override string ToString()
        {
            float price = ComputePrice();
            float weight = this.ComputeWeight();
            Discount discount = this.ComputeDiscount();
            string message = this.Quantity + " " + this.MeasurableUnitType + " (" + weight + " kg), " +
                "Unit price: " + this.PricePerUnit + " total price: " + price.ToString() + " , Discount " +
                discount.DiscountPercenage.ToString() + " % (" + discount.DiscountValue.ToString() + " )";
            return message;
        }
    }
}
