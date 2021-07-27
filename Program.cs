using Distribution_Warehouse.Repo;
using System;

namespace Distribution_Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.PrintElements();
            // warehouse.writeElementsToFile();
            warehouse.ReadElementsFromFile();
            Console.WriteLine();
            Console.WriteLine("old stuff");
            Console.WriteLine();

            warehouse.PrintElements();
            Console.WriteLine("here");
        }
    }
}
