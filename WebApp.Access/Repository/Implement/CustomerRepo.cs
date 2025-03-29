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

        public override async Task<object?> AddAsync(Customer entity)
        {
            var sql = "Insert into Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)" +
                "Values (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";

            var rowsAffected = await _connection.ExecuteAsync(sql, entity, _transaction);

            if (rowsAffected > 0)
                return entity.CustomerID;

            return null;
        }

        public override async Task<bool> UpdateAsync(Customer entity)
        {
            var sql = "Update Customers Set CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax Where CustomerID = @CustomerID";
            var res = await _connection.ExecuteAsync(sql, entity, _transaction);
            return res > 0;
        }

        public override async Task<bool> DeleteAsync(object id)
        {
            var sql = "Delete From Customers Where CustomerID = @CustomerID";
            var res = await _connection.ExecuteAsync(sql, new { CustomerID = id }, _transaction);
            return res > 0;
        }

        public override async Task<IEnumerable<Customer>> FindAllAsync()
        {
            var sql = "Select * From Customers With(nolock)";
            return await _connection.QueryAsync<Customer>(sql, new { }, _transaction);
        }

        public override async Task<Customer?> FindAsync(object id)
        {
            var sql = "Select * From Customers With(nolock) Where CustomerID = @CustomerID";
            return await _connection.QuerySingleOrDefaultAsync<Customer>(sql, new { CustomerID = id }, _transaction);
        }
    }
}
