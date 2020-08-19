using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.DataAccess.Interfaces;
using MyBlog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, ITable, new()
    {
        public async Task AddAsync(T entity)
        {
            using var context =new BlogContext();
           await context.AddAsync(entity);
           await context.SaveChangesAsync();
        }

        public async Task<T> FindAsync(int id)
        {
            using var context = new BlogContext();
            
            return await context.FindAsync<T>(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new BlogContext();
            return await context.Set<T>().ToListAsync();

        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T,TKey>>keySelector)
        {
            using var context = new BlogContext();
            return await context.Set<T>().OrderByDescending(keySelector).ToListAsync();

        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new BlogContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter,Expression<Func<T,TKey>>keySelector)
        {
            using var context = new BlogContext();
            return await context.Set<T>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new BlogContext();
            return await context.Set<T>().Where(filter).SingleOrDefaultAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            using var context = new BlogContext();
            context.Remove(entity);
          await  context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new BlogContext();
            context.Update(entity);
           await context.SaveChangesAsync();

        }
    }
}
