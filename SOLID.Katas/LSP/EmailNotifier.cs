
namespace SOLID.Katas.LSP
{
    using System;
    using System.Collections.Generic;

    public class EmailNotifier
    {
        public void SendDiscountNotification(IList<Customer> customers)
        {
            foreach (var customer in customers)
            {
                var message = string.Format("Sending notification to {0} with {1}% discount.", customer.Email, customer.CalculateDiscount());
                Console.WriteLine(message);
            }
        }
    }
}
