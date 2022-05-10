using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext context;
        protected readonly IMapper mapper;

        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteAsync<TInput>(TInput input) where TInput : class
        {
            context.Set<T>().Remove(mapper.Map<T>(input));
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Exists<TOutput>(TOutput output) where TOutput : class
        {
            return await context.Set<T>().ContainsAsync(mapper.Map<T>(output));
        }

        public async Task<IEnumerable<TOutput>> FilterAllAsync<TOutput>(Expression<Func<TOutput, bool>> expression) where TOutput : class
        {
            return await context.Set<TOutput>().Where(expression).ToListAsync();
        }

        public IQueryable<TInput> FindAll<TInput>() where TInput : class
        {
            return context.Set<TInput>().AsNoTracking();
        }

        
 
        public async Task<TInput> FindAsync<TInput>(Expression<Func<T, bool>> expression) where TInput : class
        {
            return await context.Set<T>().Where(expression)
                .ProjectTo<TInput>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TOutput>> GetAllAsync<TOutput>()
        {
            return await context.Set<T>()
                .ProjectTo<TOutput>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TOutput> GetByIdAsync<TOutput>(Expression<Func<TOutput, bool>> expression) where TOutput : class
        {
            return await context.Set<T>()
                .ProjectTo<TOutput>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<bool> PostAsync<TInput>(TInput input) where TInput : class
        {
            context.Set<T>().Add(mapper.Map<T>(input));
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync<TInput>(TInput input) where TInput : class
        {
            context.Set<T>().Update(mapper.Map<T>(input));
            return await context.SaveChangesAsync() > 0;
        }
    }
}
