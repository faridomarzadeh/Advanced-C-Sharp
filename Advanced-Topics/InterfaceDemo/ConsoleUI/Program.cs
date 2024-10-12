
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IProductModel> cart = AddSampleData();
            CustomerModel customer = GetCustomer();

            foreach (var product in cart)
            {
                product.DeliverItem(customer);
                if(product is IDigitalProductModel digital)
                {
                    Console.WriteLine($"for '{digital.Title}' You have {digital.TotalDownloadsLeft} Downloads Left.");
                }
            }
        }

        private static CustomerModel GetCustomer()
        {
            return new CustomerModel
            {
                FirstName = "Tim",
                LastName = "Johnson",
                EmailAddress = "tjohnson@test.com",
                City = "New York",
                PhoneNumber = "1234567890",
            };
        }

        private static List<IProductModel> AddSampleData()
        {
            List<IProductModel> products = new List<IProductModel>();
            products.Add(new PhysicalProductModel()
            {
                Title = "Hat"
            });
            products.Add(new PhysicalProductModel()
            {
                Title = "Shoe"
            });
            products.Add(new PhysicalProductModel()
            {
                Title = "Jeans"
            });
            products.Add(new DigitalProductModel()
            {
                Title = "C# Tutorial"
            });
            return products;
        }
    }
}