using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ccshis
{
    /// <summary>
    /// 默认配置服务，默认采用文件配置方式
    /// </summary>
    public class DefaultConfiguationService : IConfigurationService,IFileConfigurationService
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
        public async Task<T> GetAsync<T>(string key) where T : class, ISetting
        {
            //从缓存获取key
            if (_cache.ContainsKey(key))
            {
                return _cache[key] as T;
            }

            string filePath = getFilePath(key);

            if(!File.Exists(filePath))
            {
                return null;
            }

            var fileContent = await GetAsync(filePath);
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
        public async Task<string> GetAsync(string key)
        {
            return await Task.Run(() =>
            {
                return File.ReadAllText(getFilePath(key));
            });
        }

        /// <summary>
        /// 设置配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>
        /// author:catdemon
        /// date:2019-5-21
        /// </remarks>
        public async Task SetAsync<T>(string key, T value) where T:class,ISetting
        {
            await SetAsync(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>
        /// author:catdemon
        /// date:2019-5-21
        /// </remarks>
        public async Task SetAsync(string key, string value)
        {
            var filePath = getFilePath(key);

            await Task.Run(() =>
            {
                createFile(filePath);

                File.WriteAllText(filePath, value);
            });
        }

        /// <summary>
        /// 如果配置文件不存在，则创建配置文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <remarks>
        /// author:catdemon
        /// date:2019-5-21
        /// </remarks>
        private void createFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                var dir = Path.GetDirectoryName(filePath);
                Directory.CreateDirectory(dir);
                using (var filr = File.Create(filePath)) { }
            }
        }

        /// <summary>
        /// 获取文件路径
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string getFilePath(string key)
        {
            return Path.Combine(_filePath, key);
        }
    }
}
