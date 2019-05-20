using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// 默认配置服务，默认采用文件配置方式
    /// </summary>
    public class DefaultConfiguationService : IConfigurationService
    {

        public const string DefaultPath = "ConfigurationSetting";

        private Dictionary<string, object> _cache = new Dictionary<string, object>();

        /// <summary>
        /// 默认配置路径
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// 默认配置的路径，如果包含盘符则是绝对路径，如果以\开头则表示相对程序路径。所有的配置文件都存在该路径下
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public DefaultConfiguationService(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// 读取配置文件，key为文件的路径
        /// </summary>
        /// <typeparam name="T">配置对象</typeparam>
        /// <param name="key">配置相对DefaultPath路径</param>
        /// <returns>配置项</returns>
        /// <remarks>
        /// authro:catdemon
        /// date:2019-5-20
        /// </remarks>
        public T Get<T>(string key) where T : class,ISetting
        {
            //从缓存获取key
            if(_cache.ContainsKey(key))
            {
                return _cache[key] as T;
            }

            var fileContent = Get(Path.Combine(_filePath, key));
            var setting = JsonConvert.DeserializeObject<T>(fileContent);

            _cache[key] = setting;

            return setting;
        }

        /// <summary>
        /// 读取配置文件，key为文件的路径
        /// </summary>
        /// <param name="key">配置相对DefaultPath路径</param>
        /// <returns>配置项</returns>
        /// <remarks>
        /// authro:catdemon
        /// date:2019-5-20
        /// </remarks>
        public string Get(string key)
        {
            return File.ReadAllText(Path.Combine(_filePath, key));
        }
    }
}
