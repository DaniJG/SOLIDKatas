using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOLID.Katas.SRP;
using SOLID.Katas.SRP.DTOs;

namespace SOLID.Katas.Test.SRP
{
    [TestClass]
    public class UserControllerIntegrationTest
    {
        private UserController controller;

        [TestInitialize]
        public void Initialize()
        {
            this.controller = new UserController();
        }

        [TestMethod]
        public void UserCanBeCreated_And_Returned()
        {
            var user = new UserDTO { Name = "Foo", Email = "foo@foo.com" };
            var createdUser = controller.Create(user);

            var userById = controller.Get(createdUser.Id);
            Assert.IsNotNull(userById);
            Assert.AreEqual(createdUser.Email, userById.Email);
        }

        [TestMethod]
        public void MultipleUsersCanBeCreated_And_Returned()
        {
            var foo = controller.Create(new UserDTO { Name = "Foo", Email = "foo@foo.com" });
            var bar = controller.Create(new UserDTO { Name = "Bar", Email = "bar@bar.com" });

            var fooUserById = controller.Get(foo.Id);
            var barUserById = controller.Get(bar.Id);
            Assert.AreEqual(foo.Email, fooUserById.Email);
            Assert.AreEqual(bar.Email, barUserById.Email);
        }

        [TestMethod]
        public void MultipleUsersCanBeCreated_And_ReturnedInTheUserList()
        {
            controller.Create(new UserDTO { Name = "Foo", Email = "foo@foo.com" });
            controller.Create(new UserDTO { Name = "Bar", Email = "bar@bar.com" });

            var users = controller.Get();
            Assert.AreEqual(2, users.Count());            
        }

        [TestMethod]
        public void UserListWillBeRefreshed_WhenNewUsersAreCreated()
        {
            controller.Create(new UserDTO { Name = "Foo", Email = "foo@foo.com" });
            var users = controller.Get();
            Assert.AreEqual(1, users.Count());

            controller.Create(new UserDTO { Name = "Bar", Email = "bar@bar.com" });
            users = controller.Get();
            Assert.AreEqual(2, users.Count());
        }
    }
}
