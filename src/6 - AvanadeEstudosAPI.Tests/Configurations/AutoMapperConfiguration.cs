using AutoMapper;
using AvanadeEstudosAPI.API.ViewModels;
using AvanadeEstudosAPI.Domain.Entities;
using AvanadeEstudosAPI.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanadeEstudosAPI.Tests.Configurations
{
    public class AutoMapperConfiguration
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, Services.DTO.UserDTO>()
                    .ReverseMap();

                cfg.CreateMap<CreateUserViewModel, UserDTO>()
                    .ReverseMap();

                cfg.CreateMap<UpdateUserViewModel, UserDTO>()
                    .ReverseMap();
            });

            return autoMapperConfig.CreateMapper();
        }
    }
}
