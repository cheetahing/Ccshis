using Consul;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.ServiceDiscovery.ConsulExtend
{
    public interface IConsulSetting
    {

        /// <summary>
        /// 服务发现中间件配置
        /// </summary>
        ConsulServerSetting ConsulServerSetting { get; }

        /// <summary>
        /// 微服务配置
        /// </summary>
        MicServerSetting MicServerSetting { get; }

        /// <summary>
        /// 健康检查
        /// </summary>
        HealthCheckSetting HealthCheckSetting { get;}
    }
}
