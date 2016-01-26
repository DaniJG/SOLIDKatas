using SOLID.Katas.SRP.DTOs;
using SOLID.Katas.SRP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas.SRP
{
    public static class DTOMapping
    {
        public static User ToEntity(this UserDTO userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email
            };
        }

        public static UserDTO ToDto(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public static DeviceDTO ToDto(this Device device)
        {
            return new DeviceDTO
            {
                Id = device.Id,
                Model = device.Model,
                Version = device.Version,
                UserId = device.User.Id
            };
        }
    }
}
