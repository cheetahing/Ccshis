using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.ConsulComponent
{
    /// <summary>
    /// 服务器发现中间件配置
    /// </summary>
    public class ConsulServerSetting
    {
        /// <summary>
        /// 默认端口号
        /// </summary>
        public const int DefaultPort = 8500;

        /// <summary>
        /// 服务发现地址，例如http://127.0.0.1
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 服务发现端口，默认8500
        /// </summary>
        public int Port { get; set; } = DefaultPort;
    }
}
