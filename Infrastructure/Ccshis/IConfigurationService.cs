using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ccshis
{
    public interface IConfigurationService
    {
        Task<T> GetAsync<T>(string key) where T : class, ISetting;

        Task<string> GetAsync(string key);
    }
}
