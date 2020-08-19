using MyBlog.Business.Interfaces;
using MyBlog.DataAccess.Interfaces;
using MyBlog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class, ITable, new()
    {
        IGenericDal<T> _genericDal;
        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task AddAsync(T entity)
        {
            await _genericDal.AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
            {
               return await _genericDal.GetAllAsync();
            }
            else
              return  await _genericDal.GetAllAsync(filter);
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector)
        {
            if (filter == null)
            {
                return await _genericDal.GetAllAsync(keySelector);
            }
            else
                return await _genericDal.GetAllAsync(filter, keySelector);
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return await _genericDal.GetAllAsync(keySelector);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _genericDal.GetAsync(filter);
        }

        public async Task RemoveAsync(T entity)
        {
           await _genericDal.RemoveAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
    }
}
