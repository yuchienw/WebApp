using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Access.Infrastructure.Interface
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    } 
}
