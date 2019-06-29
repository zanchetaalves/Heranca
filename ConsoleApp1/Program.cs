using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productList = new List<Product>();

            Console.Write("Enter the number of products: ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                switch (type)
                {
                    case 'i':
                        Console.Write("Custom free: ");
                        double cf = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Product productI = new ImportedProduct(name, price, cf);
                        productList.Add(productI);

                        break;
                    case 'u':
                        Console.Write("Manufacture date (DD/MM/YYYY): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        Product productU = new UsedProduct(name, price, date);
                        productList.Add(productU);

                        break;
                    default:
                        Product product = new Product(name, price);
                        productList.Add(product);
                        break;
                }
            }

            Console.WriteLine();

            foreach (Product p in productList)
            {
                Console.WriteLine("PRICE TAGS");
                Console.WriteLine(p.PriceTag());
            }

            Console.WriteLine("Teste");
            string teste = Console.ReadLine();
        }
    }
}
