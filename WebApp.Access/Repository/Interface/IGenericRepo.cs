using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Access.Repository.Interface
{
    public interface IGenericRepo<T>
    {
        public Task<int> AddAsync(T entity);

        public Task<bool> UpdateAsync(T entity);

        public Task<bool> DeleteAsync(T entity);

        public Task<T?> FindAsync(int id);

        public Task<IEnumerable<T>> FindAllAsync();
    }
}
