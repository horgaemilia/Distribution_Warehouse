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
    [Serializable]
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
            Discount discount = new Discount();
            int daysDifference = (int) (ExpirationDate - DateTime.Now).TotalDays;
            int weeks = daysDifference / 7;
            float priceWithoutDiscount = this.ComputePriceWithoutDiscount();
            float currentPrice = priceWithoutDiscount;
            if (weeks <= 5)
            {
                while (weeks <= 5)
                {
                    currentPrice = currentPrice * 0.9f;
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

        public Fruit() { }

        private float ComputePriceWithoutDiscount()
        {
            float price = Quantity * PricePerUnit;
            return price;
        }



        public override float ComputePrice()
        {
            Discount discount = this.Discount();
            return (this.ComputePriceWithoutDiscount() - discount.DiscountValue);
        }

        public override string ToString()
        {
            float price = ComputePrice();
            float weight = this.ComputeWeight();
            Discount discount = this.Discount();
            string message = this.Quantity + " " + this.MeasurableUnitType + " (" + weight + " kg), " +
                "Unit price: " + this.PricePerUnit + " total price: " + price.ToString() + " , Discount " +
                discount.DiscountPercenage.ToString() + " % (" + discount.DiscountValue.ToString() + " )";
            return message;
        }

    }
}
