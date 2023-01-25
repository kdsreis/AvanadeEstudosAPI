using AutoMapper;
using AvanadeEstudosAPI.Domain.Entities;
using AvanadeEstudosAPI.Domain.Interfaces;
using AvanadeEstudosAPI.Services.DTO;
using AvanadeEstudosAPI.Services.Interfaces;

namespace AvanadeEstudosAPI.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;       
        private readonly IUserRepository _userRepository;    
       
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> CreateAsync(UserDTO userDTO)
        {

            var user = _mapper.Map<User>(userDTO); 
            user.Validate();
            user.SetDateAdded(); 
            var userCreated = await _userRepository.CreateAsync(user);
            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetAsync(userDTO.Id);

            if (userExists == null)
                throw new AppDomainUnloadedException("Não existe usuário com o Id informado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdated = await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDTO>(userUpdated);
        }

        public async Task RemoveAsync(long id)
        { 
            await _userRepository.RemoveAsync(id);
        }

        public async Task<UserDTO> GetAsync(long id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDTO>(user);

        }

        public async Task<IList<UserDTO>> GetAllAsync()
        {
            var allUsers = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(allUsers);
            
        }       

    }
}