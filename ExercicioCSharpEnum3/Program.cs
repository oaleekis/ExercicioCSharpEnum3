using ExercicioCSharpEnum3.Entities;
using ExercicioCSharpEnum3.Entities.Enums;
using System.Globalization;

namespace ExercicioCSharpEnum3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client cliente = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int qtd = int.Parse(Console.ReadLine());

            DateTime moment = DateTime.Now;
            Order order = new Order(moment, status, cliente);

            for (int i = 0; i < qtd; i++)
            {
                Console.WriteLine($"Enter #{i + 1} item data: ");
                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double priceProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(nameProduct, priceProduct);
                OrderItem item = new OrderItem(quantity, priceProduct, product);

                order.Items.Add(item);

            }

            Console.WriteLine(order);
        }
    }
}