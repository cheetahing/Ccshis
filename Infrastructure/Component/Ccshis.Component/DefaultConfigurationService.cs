using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// 默认配置服务，默认采用文件配置方式
    /// </summary>
    public class DefaultConfiguationService : IConfigurationService
    {
        /// <summary>
        /// 默认配置路径
        /// </summary>
        public const string FilePath = "D:/CcshisConfig/";

        public T Get<T>(string key) where T : ISetting
        {
            throw new NotImplementedException();

        }

        public string Get(string key)
        {
            throw new NotImplementedException();
        }
    }
}
