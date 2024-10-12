using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class DigitalProductModel:IDigitalProductModel
    {
        public string Title { get; set; }
        public bool HasOrderBeenCompleted { get;private set; }

        public int TotalDownloadsLeft { get; private set; } = 5;
        public void DeliverItem(CustomerModel customer)
        {
            if (HasOrderBeenCompleted == false)
            {
                Console.WriteLine($"Simulating Emailing '{Title}' to '{customer.FirstName}'");
                TotalDownloadsLeft -= 1;
                if (TotalDownloadsLeft < 1)
                {
                    HasOrderBeenCompleted = true;
                    TotalDownloadsLeft = 0;
                }
            }
        }
    }
}
