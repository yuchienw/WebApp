using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Common.Utility.Interface
{
    public interface IHttpClientUtility
    {
        Task<string> GetAsync(string url);

        Task<string> PostAsync(string url, object data);

        Task<bool> PutAsync(string url, object data);

        Task<bool> DeleteAsync(string url);
    }
}
