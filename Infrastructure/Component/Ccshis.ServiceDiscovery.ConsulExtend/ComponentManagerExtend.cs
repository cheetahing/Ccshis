using Consul;
using System;

namespace Ccshis.ServiceDiscovery.ConsulExtend
{
    public static class ComponentManagerExtend
    {
        private static ConsulSetting _consulSetting;
        private static ConsulClient _consulClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentManager">componentManager</param>
        /// <param name="consulSetting">服务发现配置</param>
        /// <param name="deregisterAction">取消注册委托，当程序关闭或服务下线时，该委托会取消服务注册</param>
        /// <returns></returns>
        public static IComponentManager UseConsul(this IComponentManager componentManager, ConsulSetting consulSetting)
        {
            _consulSetting = consulSetting;
            initConsul(componentManager);
            componentManager.RegisterAssembly(typeof(ComponentManagerExtend).Assembly);
            return componentManager;
        }

        /// <summary>
        /// 取消组件注册
        /// </summary>
        /// <param name="componentManager"></param>
        /// <returns></returns>
        public static IComponentManager CloseConsul(this IComponentManager componentManager)
        {
            _consulClient.Agent.ServiceDeregister(_consulSetting.MicServerSetting.Id.ToString()).Wait();//服务停止时取消注册
            return componentManager;
        }
        
        /// <summary>
        /// 实始化客户端并注册到注册中心
        /// </summary>
        /// <remarks>
        /// author:catdemon
        /// date:2019-5-16
        /// </remarks>
        /// <param name="componentManager"></param>
        private static void initConsul(IComponentManager componentManager)
        {
            /*
             * 创建Consul客户端
             */
            var consulServerSetting = _consulSetting.ConsulServerSetting;
            ConsulClientConfiguration consulClientConfiguration = new ConsulClientConfiguration()
            {
                Address = new Uri($"{consulServerSetting.Url}:{consulServerSetting.Port}")
            };
            _consulClient = new ConsulClient(x => x = consulClientConfiguration);//请求注册的 Consul 地址

            /*
             * 设置健康检查
             */
            var healthCheck = _consulSetting.HealthCheckSetting;
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(healthCheck.DeregisterCriticalServiceAfter),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(healthCheck.HeathInterval),//健康检查时间间隔，或者称为心跳间隔
                HTTP = $"{healthCheck.HeathUrl}:{healthCheck.Port}{healthCheck.CheckPath}",//健康检查地址
                Timeout = TimeSpan.FromSeconds(healthCheck.TimeOut)
            };

            /*
             * 注册微信服信息
             */
            var micServerSetting = _consulSetting.MicServerSetting;
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = micServerSetting.Id.ToString(),
                Name = micServerSetting.Name,
                Address = micServerSetting.Url,
                Port = micServerSetting.Port,
                Tags = micServerSetting.Tags
            };

            _consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
        }
    }
}
