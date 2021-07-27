using Distribution_Warehouse.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse.Repo
{
    public enum ProductOptions
    {
        Apples,
        Potatoes,
        Onions,
        Peaches,
        Oranges,
        Crackers
    }


    class Warehouse
    {
        private List<Product> products;

        public Warehouse()
        {
            this.products = new List<Product>();
            this.GenerateRandomProducts();
            this.EliminateExpiredProducts();
        }

        private static int OrderOnType(Product item)
        {
            if (item is Fruit)
                return 0;
            if (item is Vegetable)
                return 1;
            return 2;
        }



        private void GenerateRandomProducts()
        {
            int number_of_options = Enum.GetNames(typeof(ProductOptions)).Length;
            Random random = new Random();
            int days = (DateTime.Now - DateTime.Now.AddMonths(-6)).Days;
            for (int i=0;i<200;i++)
            {
                //first we instantiate our product type
                ProductOptions option = (ProductOptions)random.Next(0, number_of_options);
                //we randomize the entry date

                int entry_date_days = random.Next(0, days);
                //so we can have elements that can be deleted
                DateTime entryDate = DateTime.Now.AddMonths(-2).AddDays(-entry_date_days);
                DateTime expirationDate = entryDate.AddMonths(6);
                
                //now we check for the options


                if(option.Equals(ProductOptions.Apples))
                {
                    int quantity = random.Next(50, 250);
                    int nutritional_value = random.Next(0, 100);
                    SimpleFruitParameters simpleFruitParameters = new SimpleFruitParameters();
                    simpleFruitParameters.entryDate = entryDate;
                    simpleFruitParameters.expirationDate = expirationDate;
                    simpleFruitParameters.quantity = quantity;
                    simpleFruitParameters.nutritionalValue = nutritional_value;
                    Apple apple = new Apple(simpleFruitParameters);
                    this.products.Add(apple);
                }
                else
                    if(option.Equals(ProductOptions.Potatoes))
                {
                    int nutritional_value = random.Next(0, 100);
                    string producer = "default";
                    int quantity = random.Next(15, 25);
                    SimpleVegetableParameters simpleVegetableParameters = new SimpleVegetableParameters();
                    simpleVegetableParameters.entryDate = entryDate;
                    simpleVegetableParameters.expirationDate = expirationDate;
                    simpleVegetableParameters.quantity = quantity;
                    simpleVegetableParameters.producer = producer;
                    Potato potato = new Potato(simpleVegetableParameters);
                    this.products.Add(potato);
                }
                else
                    if (option.Equals(ProductOptions.Onions))
                {
                    int nutritional_value = random.Next(0, 100);
                    string producer = "default";
                    int quantity = random.Next(15, 25);
                    SimpleVegetableParameters simpleVegetableParameters = new SimpleVegetableParameters();
                    simpleVegetableParameters.entryDate = entryDate;
                    simpleVegetableParameters.expirationDate = expirationDate;
                    simpleVegetableParameters.quantity = quantity;
                    simpleVegetableParameters.producer = producer;
                    Onion onion = new Onion(simpleVegetableParameters);
                    this.products.Add(onion);
                }
                else
                     if (option.Equals(ProductOptions.Peaches))
                {
                    int quantity = random.Next(30, 60);
                    int nutritional_value = random.Next(0, 100);
                    SimpleFruitParameters simpleFruitParameters = new SimpleFruitParameters();
                    simpleFruitParameters.entryDate = entryDate;
                    simpleFruitParameters.expirationDate = expirationDate;
                    simpleFruitParameters.quantity = quantity;
                    simpleFruitParameters.nutritionalValue = nutritional_value;
                    Peach peach = new Peach(simpleFruitParameters);
                    this.products.Add(peach);
                }
                else
                     if (option.Equals(ProductOptions.Oranges))
                {
                    int quantity = random.Next(15, 25);
                    int nutritional_value = random.Next(0, 100);
                    SimpleFruitParameters simpleFruitParameters = new SimpleFruitParameters();
                    simpleFruitParameters.entryDate = entryDate;
                    simpleFruitParameters.expirationDate = expirationDate;
                    simpleFruitParameters.quantity = quantity;
                    simpleFruitParameters.nutritionalValue = nutritional_value;
                    Orange orange = new Orange(simpleFruitParameters);
                    this.products.Add(orange);
                }
                else
                     if (option.Equals(ProductOptions.Crackers))
                {
                    int quantity = random.Next(100,500);
                    int nutritional_value = random.Next(0, 100);
                    CrackersParameters crackerParameters = new CrackersParameters();
                    crackerParameters.entryDate = entryDate;
                    crackerParameters.expirationDate = expirationDate;
                    crackerParameters.quantity = quantity;
                    Crackers cracker = new Crackers(crackerParameters);
                    this.products.Add(cracker);
                }
            }
        }

        public void addProduct(Product product)
        {
            this.products.Add(product);
        }

        public void EliminateExpiredProducts()
        {
            this.products = this.products.Where(s => s.IsExpired() == false).ToList();
        }

        public void PrintElements()
        {
            this.products.Sort((x, y) => OrderOnType(x).CompareTo(OrderOnType(y)));
          
            
            //this.products.ForEach(s => Console.WriteLine(s.ToString()));
            List<Product> fruits = this.products.Where(s => s is Fruit).ToList();
            float fruit_weight = fruits.Select(s => s.ComputeWeight()).Sum();
            float total_price = fruits.Select(s => s.ComputePrice()).Sum();
            Console.WriteLine("Fruits Total: " + fruit_weight + " kg, Total price: " + total_price);
            fruits.ForEach(s => Console.WriteLine(s.ToString()));
            Console.WriteLine();
           
            

            List<Product> veggies = this.products.Where(s => s is Vegetable).ToList();
            float veggies_weight = veggies.Select(s => s.ComputeWeight()).Sum();
            float total_price_veggies = veggies.Select(s => s.ComputePrice()).Sum();
            Console.WriteLine("Vegetables Total: " + veggies_weight + " kg, Total price: " + total_price_veggies);
            veggies.ForEach(s => Console.WriteLine(s.ToString()));


            Console.WriteLine();
            List<Product> others = this.products.Where(s => s is Product && s is not Fruit && s is not Vegetable).ToList();
            float others_weight = others.Select(s => s.ComputeWeight()).Sum();
            float total_price_others = others.Select(s => s.ComputePrice()).Sum();
            Console.WriteLine("Others total: " + others_weight + " kg, Total price: " + total_price_others);
            others.ForEach(s => Console.WriteLine(s.ToString()));

        }


        public void writeElementsToFile()
        {
            IFormatter formatter = new BinaryFormatter();
            System.IO.File.WriteAllText(@"C:\Users\PC\source\repos\Distribution Warehouse\Warehouse.txt", string.Empty);
            Stream stream = new FileStream(@"C:\Users\PC\source\repos\Distribution Warehouse\Warehouse.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, this.products);
            stream.Close();
        }

        public void ReadElementsFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\PC\source\repos\Distribution Warehouse\Warehouse.txt", FileMode.Open, FileAccess.Read);
            this.products = (List<Product>)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
