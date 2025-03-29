using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Access.Repository.Interface;

namespace WebApp.Access.Repository.Implement
{
    public abstract class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected IDbConnection? _connection => _transaction.Connection;

        protected IDbTransaction _transaction;

        protected GenericRepo(IDbTransaction transaction) {
            _transaction = transaction;
        }

        public abstract Task<object> AddAsync(T entity);

        public abstract Task<bool> UpdateAsync(T entity);

        public abstract Task<bool> DeleteAsync(T entity);

        public abstract Task<T?> FindAsync(object id);

        public abstract Task<IEnumerable<T>> FindAllAsync();
    }
}
