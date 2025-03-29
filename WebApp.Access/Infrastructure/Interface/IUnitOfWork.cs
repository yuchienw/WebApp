using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Data.SqlClient.Diagnostics;
using WebApp.Access.Repository.Interface;

namespace WebApp.Access.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public void SaveChanges();

        public ICustomerRepo CustomerRepo { get; }
    }
}
