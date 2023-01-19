using System;
using System.Collections.Generic;
using System.Linq;
/**
* Допустим мы заупаемся в продуктовом магазине
* 
* Когда мы создаём новый лист продуктов, 
* нам надо выделить ещё место в области памяти, т.е. создать экземпляр
* т.к. помним, что массивы и коллекции это ссылочный тип
*  
*/
namespace GroceryStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new Cart();
            cart.ShowProducts();
         
            List<Product> newProductsList = new List<Product>();

            // Присвоить значения в новом списке продуктов
            for (int i = 0; i < cart.GetProductCount(); i++)
            {
                newProductsList.Add(cart.GetProductByIndex(i));
            }

            // и видим, что внутренняя корзина осталась без изменений
            newProductsList.RemoveAt(0);
            cart.ShowProducts();
        }
    }

    class Product
    {
        public string Name { get; set; }

        public Product(string name)
        {
            Name = name;
        }
    }

    class Cart
    {
        private readonly List<Product> _products = new List<Product>();

        public Cart()
        {
            _products.Add(new Product("Яброко"));
            _products.Add(new Product("Банан"));
            _products.Add(new Product("Апельсин"));
            _products.Add(new Product("Груша"));
            _products.Add(new Product("Авокадо"));
            _products.Add(new Product("Зелень"));
        }

        public void ShowProducts()
        {
            foreach (Product product in _products)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine();
        }

        public int GetProductCount()
        {
            return _products.Count;
        }

        public Product GetProductByIndex(int index)
        {
            return _products.ElementAt(index);
        }
    }
}
