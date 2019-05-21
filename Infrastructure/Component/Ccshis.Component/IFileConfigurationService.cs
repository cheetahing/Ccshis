using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ccshis
{
    /// <summary>
    /// 文件配置服务
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// date:2019-5-21
    /// reamark:
    /// </remarks>
    public interface IFileConfigurationService:IConfigurationService
    {
        Task SetAsync<T>(string key,T value) where T:class,ISetting;
        Task SetAsync(string key, string value);
    }
}
