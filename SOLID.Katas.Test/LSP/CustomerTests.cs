using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOLID.Katas.Test.LSP
{
    using System.Collections.Generic;
    using Katas.LSP;

    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void PersistMultipleCustomers()
        {
            // Setup
            var dataLayer = new DataLayer();

            var customers = new[]
            {
                new Customer(Guid.NewGuid(), "customer1", "customer1@email.com", new List<Guid>()),
                new Customer(Guid.NewGuid(), "customer2", "customer2@email.com", new List<Guid>()),
                new Enquirer("enquirer@email.com"), 
            };

            // Act
            dataLayer.Persist(customers);
        }

        [TestMethod]
        public void SendDiscountNotification()
        {
            // Setup
            var emailNotifier = new EmailNotifier();

            var customers = new[]
            {
                new Customer(Guid.NewGuid(), "customer1", "customer1@email.com", new List<Guid>()),
                new Customer(Guid.NewGuid(), "customer2", "customer2@email.com", new List<Guid>()),
                new Enquirer("customer2@email.com"),
            };

            // Act
            emailNotifier.SendDiscountNotification(customers);
        }

        [TestMethod]
        public void CalculateDiscount()
        {
            // Setup
            var customer1 = new Customer(Guid.NewGuid(), "customer1", "customer1@email.com", new List<Guid> { Guid.NewGuid(), Guid.NewGuid() });
            var customer2 = new Customer(Guid.NewGuid(), "customer1", "customer1@email.com", new List<Guid> { Guid.NewGuid() });
            var enquirer = new Enquirer("enquirer@email.com");

            // Act
            var discount1 = customer1.CalculateDiscount();
            var discount2 = customer2.CalculateDiscount();
            var discount3 = enquirer.CalculateDiscount();

            // Verify
            Assert.AreNotEqual(discount1, discount2, "Discounts should be different for customers with different amount of orders.");
            Assert.AreNotEqual(discount1, discount3, "Discounts should be different for customers and enquirers.");
        }

    }
}
