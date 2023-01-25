using System.Threading.Tasks;
using AvanadeEstudosAPI.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace AvanadeEstudosAPI.Domain.Interfaces{
    public interface IBaseRepository<T> where T : Base{
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task RemoveAsync(long id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(long id);        
    }
}