using AvanadeEstudosAPI.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvanadeEstudosAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> CreateAsync(UserDTO userDTO);
        Task<UserDTO> UpdateAsync(UserDTO userDTO);
        Task RemoveAsync(long id);
        Task<UserDTO> GetAsync(long id);
        Task<IList<UserDTO>> GetAllAsync();          
    }
}