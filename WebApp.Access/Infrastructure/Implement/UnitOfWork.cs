using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Access.Infrastructure.Interface;
using WebApp.Access.Repository.Implement;
using WebApp.Access.Repository.Interface;

namespace WebApp.Access.Infrastructure.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        // Repository
        private ICustomerRepo? _customerRepo;

        public ICustomerRepo CustomerRepo => _customerRepo ??= new CustomerRepo(_transaction);

        public UnitOfWork(ISqlConnectionFactory sqlConnectionFactory) {

            _connectionFactory = sqlConnectionFactory;
            _connection = _connectionFactory.CreateConnection();

            _transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void SaveChanges()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}
