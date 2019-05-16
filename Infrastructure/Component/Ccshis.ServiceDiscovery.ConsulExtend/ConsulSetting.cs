using Ccshis.Cluster;
using Consul;

namespace Ccshis.ServiceDiscovery.ConsulExtend
{
    /// <summary>
    /// 服务发现配置类，ConsulServiceRegistration，HealthCheck用于健康检查
    /// </summary>
    public class ConsulSetting : ISetting
    {
        /// <summary>
        /// 服务发现中间件配置
        /// </summary>
        public ConsulServerSetting ConsulServerSetting { get; set; }

        /// <summary>
        /// 微服务配置
        /// </summary>
        public MicServerSetting MicServerSetting { get; set; }

        /// <summary>
        /// 健康检查
        /// </summary>
        public HealthCheckSetting HealthCheckSetting { get; set; }

        public ConsulSetting()
        {
            ConsulServerSetting = new ConsulServerSetting();
            MicServerSetting = new MicServerSetting();
            HealthCheckSetting = new HealthCheckSetting();
        }

        public ConsulSetting(ConsulServerSetting consulServerSetting,MicServerSetting micServerSetting,HealthCheckSetting healthCheckSetting)
        {
            ConsulServerSetting = consulServerSetting;
            MicServerSetting = micServerSetting;
            HealthCheckSetting = healthCheckSetting;
        }
    }

    /// <summary>
    /// 服务器发现中间件配置
    /// </summary>
    public class ConsulServerSetting
    {
        /// <summary>
        /// 服务发现地址，例如http://127.0.0.1
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 服务发现端口，默认8500
        /// </summary>
        public int Port { get; set; } = 8500;
    }

    public class MicServerSetting
    {
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
        public int Port { get; set; } = 80;

        /// <summary>
        /// 注册服务名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 注册标签
        /// </summary>
        public string[] Tags { get; set; }
    }

    /// <summary>
    /// 微服务健康检查，采用http或tcp方式进行健康检查
    /// </summary>
    public class HealthCheckSetting
    {
        /// <summary>
        /// 检查路径，默认api/health
        /// </summary>
        public string CheckPath { get; set; } = "api/health";

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; } = 80;

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
        public int DeregisterCriticalServiceAfter { get; set; } = 5;

        /// <summary>
        /// 健康检查(心跳)的秒数，单位秒，默认10秒
        /// </summary>
        /// <remarks>
        /// 微服务，每隔一定的时候间隔向注册中心发送心跳，告诉注册中心微服务还可用
        /// </remarks>
        public int HeathInterval { get; set; } = 10;

        /// <summary>
        /// 心跳检测地址，例如：http://localhost:51606/api/health
        /// </summary>
        public string HeathUrl { get; set; }

        /// <summary>
        /// 超时时间,单位秒，默认5秒
        /// </summary>
        public int TimeOut { get; set; } = 5;
    }
}