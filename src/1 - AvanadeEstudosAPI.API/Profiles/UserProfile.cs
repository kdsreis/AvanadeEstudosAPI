using AutoMapper;
using AvanadeEstudosAPI.Domain.Entities;
using AvanadeEstudosAPI.Services.DTO;
using AvanadeEstudosAPI.API.ViewModels;

namespace AvanadeEstudosAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
            CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();
        }   

    }
    
}