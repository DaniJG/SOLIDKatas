
namespace SOLID.Katas.LSP
{
    using System;
    using System.Collections.Generic;

    public class Enquirer : Customer
    {
        public Enquirer(string email)
            : base(Guid.Empty, string.Empty, email, null)
        {
        }

        public Enquirer(Guid id, string name, string email, List<Guid> orders) 
            : base(id, name, email, orders)
        {
        }

        public override int CalculateDiscount()
        {
            return 5;
        }
    }
}
