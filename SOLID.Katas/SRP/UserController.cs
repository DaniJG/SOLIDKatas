using SOLID.Katas.SRP.DTOs;
using SOLID.Katas.SRP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas.SRP
{
    class UserController
    {
        private Repository<User> repository;
        private List<User> cachedItems;

        public UserController()
        {
            this.repository = new Repository<User>();
            this.cachedItems = new List<User>();
        }

        public UserDTO Create(UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("Email cannot be empty", "user");
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new ArgumentException("Name cannot be empty", "user");
            }

            return this.repository
                .Add(user.ToEntity())
                .ToDto();            
        }

        public IEnumerable<UserDTO> GetAll()
        {
            this.EnsureCachedItems();            
            return this.cachedItems.Select(DTOMapping.ToDto);
        }

        public UserDTO Get(int id)
        {
            this.EnsureCachedItems();
            var cachedUser = this.cachedItems.FirstOrDefault(u => u.Id == id);
            if (cachedUser == null)
            {
                cachedUser = this.repository.GetById(id);
                this.cachedItems.Add(cachedUser);
            }
            return cachedUser.ToDto();
        }

        private void EnsureCachedItems()
        {
            if (this.cachedItems == null)
            {
                this.cachedItems = this.repository.GetAll().ToList();
            }
        }
    }
}
