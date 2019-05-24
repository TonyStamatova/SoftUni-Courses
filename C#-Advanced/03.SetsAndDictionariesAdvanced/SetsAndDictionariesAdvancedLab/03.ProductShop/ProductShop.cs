namespace _03.ProductShop
{
    using System;
    using System.Collections.Generic;

    public class ProductShop
    {
        public static void Main()
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Revision")
            {
                var shopData = input.Split(", ");
                var shop = shopData[0];
                var product = shopData[1];
                var price = double.Parse(shopData[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);               
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
