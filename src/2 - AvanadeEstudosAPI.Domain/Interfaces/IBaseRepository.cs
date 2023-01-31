using AvanadeEstudosAPI.Domain.Entities;

namespace AvanadeEstudosAPI.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Base{
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task RemoveAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);        
    }
}