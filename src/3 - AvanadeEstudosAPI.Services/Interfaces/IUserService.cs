using AvanadeEstudosAPI.Services.DTO;

namespace AvanadeEstudosAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> CreateAsync(UserDTO userDTO);
        Task<UserDTO> UpdateAsync(UserDTO userDTO);
        Task RemoveAsync(int id);
        Task<UserDTO> GetAsync(int id);
        Task<IList<UserDTO>> GetAllAsync();          
    }
}