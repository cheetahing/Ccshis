using Consul;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ccshis.ConsulComponent
{
    /// <summary>
    /// 配置中心
    /// </summary>
    public class ConsulConfigurationService : IConfigurationService
    {
        private IConsulClient _consulClien;

        public ConsulConfigurationService(IConsulClient consulClient)
        {
            _consulClien = consulClient;
        }

        public T Get<T>(string key) where T:class,ISetting
        {
            return JsonConvert.DeserializeObject<T>(Get(key));
        }


        public string Get(string key)
        {
            return GetConfigByConsul(key).GetAwaiter().GetResult();
        }

        public async Task<string> GetConfigByConsul(string key)
        {
            var result = await _consulClien.KV.Get(key);
            var list = await _consulClien.KV.List("test/");
            return Encoding.UTF8.GetString(result.Response.Value);
        }
    }
}
