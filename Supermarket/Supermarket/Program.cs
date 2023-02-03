using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cart cart1 = new Cart();
            cart1.AddProduct(new Product("Пельмени", 400));
            cart1.AddProduct(new Product("Сосиски", 250));
            cart1.AddProduct(new Product("Зефир", 150));
            cart1.AddProduct(new Product("Креветки", 600));
            cart1.AddProduct(new Product("Яблоки", 80));
            cart1.AddProduct(new Product("Молоко", 75));
            cart1.AddProduct(new Product("Масло", 150));
            cart1.AddProduct(new Product("Макароны", 155));
            cart1.AddProduct(new Product("Сыр", 200));
            cart1.AddProduct(new Product("Сметана", 80));

            Cart cart2 = new Cart();
            cart2.AddProduct(new Product("Вино", 500));
            cart2.AddProduct(new Product("Игристое вино", 820));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));
            cart2.AddProduct(new Product("Вискас", 20));

            Cart cart3 = new Cart();
            cart3.AddProduct(new Product("Пиво", 80));
            cart3.AddProduct(new Product("Пиво", 80));
            cart3.AddProduct(new Product("Пиво", 80));
            cart3.AddProduct(new Product("Коньяк", 600));
            cart3.AddProduct(new Product("Шоколад", 70));

            Cart cart4 = new Cart();
            cart4.AddProduct(new Product("Каталог", 0));

            Cart cart5 = new Cart();
            cart5.AddProduct(new Product("Киндер", 115));
            cart5.AddProduct(new Product("Cola", 50));

            Cart cart6 = new Cart();
            cart6.AddProduct(new Product("", 0));

            Customer firstCustomer = new Customer(1000, cart1);
            Customer secondCustomer = new Customer(1000, cart2);
            Customer thirdCustomer = new Customer(1000, cart3);
            Customer fourthCustomer = new Customer(1000, cart4);
            Customer fifthCustomer = new Customer(0, cart5);
            Customer sixthCustomer = new Customer(1000, cart6);

            Queue<Customer> queue = new Queue<Customer>();
            queue.Enqueue(firstCustomer);
            queue.Enqueue(secondCustomer);
            queue.Enqueue(thirdCustomer);
            queue.Enqueue(fourthCustomer);
            queue.Enqueue(fifthCustomer);
            queue.Enqueue(sixthCustomer);

            CashRegister cashRegister = new CashRegister(queue);

            cashRegister.CalculateCustomer();
        }
    }

    class Customer
    {
        public int Money { get; }
        public Cart Cart { get; }

        public Customer(int money, Cart cart)
        {
            Money = money;
            Cart = cart;
        }
    }

    class Cart
    {
        public List<Product> Products { get; }

        public Cart()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void DeleteProduct(int index)
        {
            Products.RemoveAt(index);
        }
    }

    class Product
    {
        private string _nameProduct;
        public int Price { get; }

        public Product(string nameProduct, int price)
        {
            _nameProduct = nameProduct;
            Price = price;
        }

        public void ShowProduct()
        {
            Console.WriteLine($"\t{_nameProduct} - {Price}");
        }
    }

    class CashRegister
    {
        private Queue<Customer> _queueAtCashRegister = new Queue<Customer>();

        public CashRegister(Queue<Customer> queueAtCashRegister)
        {
            _queueAtCashRegister = queueAtCashRegister;
        }

        public void AddCustomer(Customer customer)
        {
            _queueAtCashRegister.Enqueue(customer);
        }

        public int CalculateTotalSum(Customer customer)
        {
            int sumTotal = 0;

            foreach (Product product in customer.Cart.Products)
            {
                sumTotal += product.Price;
            }

            return sumTotal;
        }

        public void PayProducts(Customer customer)
        {
            int sumTotal = CalculateTotalSum(customer);

            Console.WriteLine("\n Здравствуйте, пакет нужен, карта магазина\n");

            if (sumTotal == 0)
            {
                Console.WriteLine("\n\n\tТвоя корзина пуста.\n\n"
                    + " Начни покупки, а после приходи для оплаты");
            }
            else if (0 >= customer.Money)
            {
                Console.WriteLine("\n\n\tУ тебя нет денег?..\n\n"
                    + " Давай я отложу корзину, а ты сходишь за деньгами");
            }
            else if (sumTotal <= customer.Money)
            {
                Console.WriteLine("\n\tСпасибо. Возьмите чек!");
            }
            else if (sumTotal > customer.Money)
            {
                Console.WriteLine($"\n\n Оу...\n\tИтоговая сумма превышет на {sumTotal - customer.Money}  денег!\n\n"
                    + " Ну что... \n\n\tНачинаем выкидывать "
                    + "рандомный товар из корзины\n\tпока твоих денег не хватит для оплаты\n");

                RemoveProductFromCart(customer);

                Console.WriteLine("\n Не зубудьте взять чек. Спасибо. Следующий..");
            }

            Console.WriteLine("\n\n\nДля продолжения нажми любую клавишу, пожалуйста :)");
            Console.ReadKey();
            Console.Clear();
        }

        public void RemoveProductFromCart(Customer customer)
        {
            int productIndex;
            Random random = new Random();
            int sumTotal = CalculateTotalSum(customer);

            Console.WriteLine($" Убираю из корзины: ");

            while (sumTotal >= customer.Money)
            {
                productIndex = random.Next(customer.Cart.Products.Count);

                customer.Cart.Products[productIndex].ShowProduct();
                sumTotal -= customer.Cart.Products[productIndex].Price;
                customer.Cart.DeleteProduct(productIndex);
            }
        }

        public void CalculateCustomer()
        {
            Customer customer;

            while (_queueAtCashRegister.Count > 0)
            {
                customer = _queueAtCashRegister.Dequeue();

                PayProducts(customer);
            }            
        }
    }
}
