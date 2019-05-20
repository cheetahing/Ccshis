using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.ConsulComponent
{

    /// <summary>
    /// 微服务健康检查，采用http或tcp方式进行健康检查
    /// </summary>
    public class HealthCheckSetting
    {
        /// <summary>
        /// 默认健康检查路径，默认值api/ServerHealthCheck
        /// </summary>
        public const string DefaultCheckPath = "api/ServerHealthCheck";

        /// <summary>
        /// 默认健康检查端口，默认值80
        /// </summary>
        public const int DefaultPort = 80;

        /// <summary>
        /// 默认延迟注册到服务中心时间，默认值5秒
        /// </summary>
        public const int DefaultDeregisterCriticalServiceAfter = 5;

        /// <summary>
        /// 默认健康检查时间间隔，默认值10秒
        /// </summary>
        public const int DefaultHeathInterval = 10;

        /// <summary>
        /// 默认超时时间，默认值5秒
        /// </summary>
        public const int DefaultTimeOut = 5;

        /// <summary>
        /// 检查路径，默认api/health
        /// </summary>
        public string CheckPath { get; set; } = DefaultCheckPath;

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; } = DefaultPort;

        /// <summary>
        /// 健康检查tcp地址，如果不填，默认使用MicServerSetting的http地址
        /// </summary>
        public string TcpAddress { get; set; }

        /// <summary>
        /// 服务启动后延迟注册秒数，默认5秒后注册
        /// </summary>
        /// <remarks>
        /// 由于启动后，服务不是马上可用，在初始化注册中心后，延迟指定的秒数让服务器有充分的启动时间
        /// </remarks>
        public int DeregisterCriticalServiceAfter { get; set; } = DefaultDeregisterCriticalServiceAfter;

        /// <summary>
        /// 健康检查(心跳)的秒数，单位秒，默认10秒
        /// </summary>
        /// <remarks>
        /// 微服务，每隔一定的时候间隔向注册中心发送心跳，告诉注册中心微服务还可用
        /// </remarks>
        public int HeathInterval { get; set; } = DefaultHeathInterval;

        /// <summary>
        /// 心跳检测地址，例如：http://localhost:51606/api/health
        /// </summary>
        public string HeathUrl { get; set; }

        /// <summary>
        /// 超时时间,单位秒，默认5秒
        /// </summary>
        public int TimeOut { get; set; } = DefaultTimeOut;
    }
}
