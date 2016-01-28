using SOLID.Katas.SRP.DTOs;
using SOLID.Katas.SRP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas.SRP
{
    public class UserController
    {
        private Repository<User> repository;
        private List<User> cachedItems;

        public UserController()
        {
            this.repository = new Repository<User>();
            this.cachedItems = null;
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

        public IEnumerable<UserDTO> Get()
        {
            this.EnsureCachedItems();            
            return this.cachedItems.Select(DTOMapping.ToDto);
        }

        public UserDTO Get(int id)
        {
            return this.repository
                .GetById(id)
                .ToDto();
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
