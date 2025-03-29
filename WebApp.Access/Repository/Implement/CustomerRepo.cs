using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WebApp.Access.Entity;
using WebApp.Access.Infrastructure.Implement;
using WebApp.Access.Repository.Interface;

namespace WebApp.Access.Repository.Implement
{
    public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
    {
        public CustomerRepo(IDbTransaction transaction) : base(transaction)
        {

        }

        public override async Task<int> AddAsync(Customer entity)
        {
            var sql = "Insert into Customer (CustomerName, ContactName, Address, City, Region, PostalCode, Country, Phone, Fax)" +
                "Values (@CustomerName, @ContactName, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";
            return await _connection.ExecuteAsync(sql, entity, _transaction);
        }

        public override async Task<bool> UpdateAsync(Customer entity)
        {
            var sql = "Update Customer Set CustomerName = @CustomerName, ContactName = @ContactName, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax Where CustomerID = @CustomerID";
            var res = await _connection.ExecuteAsync(sql, entity, _transaction);
            return res > 0;
        }

        public override async Task<bool> DeleteAsync(Customer entity)
        {
            var sql = "Delete From Customer Where CustomerID = @CustomerID";
            var res = await _connection.ExecuteAsync(sql, entity, _transaction);
            return res > 0;
        }

        public override async Task<IEnumerable<Customer>> FindAllAsync()
        {
            var sql = "Select * From CustomerID With(nolock)";
            return await _connection.QueryAsync<Customer>(sql, _transaction);
        }

        public override async Task<Customer?> FindAsync(int id)
        {
            var sql = "Select * From CustomerID With(nolock) Where CustomerID = @CustomerID";
            return await _connection.QuerySingleOrDefaultAsync<Customer>(sql,new { CustomerID = id }, _transaction);
        }
    }
}
