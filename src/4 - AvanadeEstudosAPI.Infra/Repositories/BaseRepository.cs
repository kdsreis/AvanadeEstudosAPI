using System.Linq;
using AvanadeEstudosAPI.Infra.Context;
using System.Threading.Tasks;
using AvanadeEstudosAPI.Domain.Entities;
using AvanadeEstudosAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace AvanadeEstudosAPI.Infra.Repositories{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base{

        private readonly AvanadeEstudosAPIContext _context;

        public BaseRepository(AvanadeEstudosAPIContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T obj){
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> UpdateAsync(T obj){
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task RemoveAsync(int id){
            var obj = await GetAsync(id);

            if(obj != null){
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> GetAsync(int id){
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x=>x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }         

    }

}