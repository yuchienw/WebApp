using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Access.Repository.Interface
{
    public interface IGenericRepo<T>
    {
        public Task<object?> AddAsync(T entity);

        public Task<bool> UpdateAsync(T entity);

        public Task<bool> DeleteAsync(object id);

        public Task<T?> FindAsync(object id);

        public Task<IEnumerable<T>> FindAllAsync();
    }
}
