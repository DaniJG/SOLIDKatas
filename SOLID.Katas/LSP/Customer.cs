
namespace SOLID.Katas.LSP
{
    using System;
    using System.Collections.Generic;

    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Guid> OrdersIds { get; set; }

        public Customer(Guid id, string name, string email, List<Guid> orders)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.OrdersIds = orders;
        }

        public virtual int CalculateDiscount()
        {
            return OrdersIds.Count > 1 ? 25 : 15;
        }
    }
}
