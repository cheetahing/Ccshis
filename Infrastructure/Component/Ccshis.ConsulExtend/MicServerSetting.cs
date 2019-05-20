using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.ConsulComponent
{

    public class MicServerSetting
    {
        /// <summary>
        /// 默认端口号
        /// </summary>
        public const int DefaultPort = 80;

        /// <summary>
        /// 注册id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 微服务器健康url地址，例如http://127.0.0.1
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 端口号，默认60
        /// </summary>
        public int Port { get; set; } = DefaultPort;

        /// <summary>
        /// 注册服务名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 注册标签
        /// </summary>
        public string[] Tags { get; set; }
    }
}
