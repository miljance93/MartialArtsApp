using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<TOutput>> GetAllAsync<TOutput>();
        Task<TOutput> GetByIdAsync<TOutput>(Expression<Func<TOutput, bool>> expression) where TOutput : class;
        Task<bool> PostAsync<TInput>(TInput input) where TInput : class;
        Task<bool> UpdateAsync<TInput>(TInput input) where TInput : class;
        Task<bool> DeleteAsync<TInput>(TInput input) where TInput : class;
        Task<TInput> FindAsync<TInput>(Expression<Func<T, bool>> expression) where TInput : class;
        IQueryable<TInput> FindAll<TInput>() where TInput : class;
        Task<IEnumerable<TOutput>> FilterAllAsync<TOutput>(Expression<Func<TOutput, bool>> expression) where TOutput : class;
        Task<bool> Exists<TOutput>(TOutput output) where TOutput : class;
    }
}
