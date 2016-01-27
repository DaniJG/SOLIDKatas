
namespace SOLID.Katas.LSP
{
    using System;
    using System.Collections.Generic;

    public class DataLayer
    {
        public void Persist(IList<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("Persisting customer with email: " + customer.Email);

                // Persist customer orders
                // Enquirers don't have orders so if we try to persist we might get exception
                if (!(customer is Enquirer))
                {
                    foreach (var order in customer.OrdersIds)
                    {
                        Console.WriteLine("Persisting order with ID: " + order);
                    }
                }
            }
        }
    }
}
