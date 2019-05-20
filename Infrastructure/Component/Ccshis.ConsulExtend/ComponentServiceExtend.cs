using Consul;
using System;

namespace Ccshis.ConsulComponent
{
    public static class ComponentServiceExtend
    {
        private static ConsulClient _consulClient;
        private static ConsulServerSetting _consulServerSetting;
        private static MicServerSetting _micServerSetting;
        private static HealthCheckSetting _healthCheckSetting;


        #region consul
        public static IComponentService UseConsul(this IComponentService componentService, ConsulServerSetting consulServerSetting)
        {
            _consulServerSetting = consulServerSetting;
            //初始化
            initializeConsulClient(componentService);

            //组件注册到容器中
            componentService.SetDefault<IConsulClient, ConsulClient>(_consulClient);

            componentService.RegisterAssembly(typeof(ComponentServiceExtend).Assembly);

            return componentService;
        }
               
        /// <summary>
        /// 初始化consul客户端
        /// </summary>
        /// <param name="componentService"></param>
        private static void initializeConsulClient(IComponentService componentService)
        {
            /*
             * 创建Consul客户端
             */
            ConsulClientConfiguration consulClientConfiguration = new ConsulClientConfiguration()
            {
                Address = new Uri($"{_consulServerSetting.Url}:{_consulServerSetting.Port}")
            };
            _consulClient = new ConsulClient(x => x = consulClientConfiguration);//请求注册的 Consul 地址
        }

        /// <summary>
        /// 取消组件注册
        /// </summary>
        /// <param name="componentService"></param>
        /// <returns></returns>
        public static IComponentService CloseConsul(this IComponentService componentService)
        {
            _consulClient.Agent.ServiceDeregister(_micServerSetting.Id.ToString()).Wait();//服务停止时取消注册
            return componentService;
        }
        #endregion

        #region 服务发现
        /// <summary>
        /// 初始化服务发现
        /// </summary>
        /// <param name="componentService">componentService</param>
        /// <param name="consulSetting">服务发现配置</param>
        /// <returns></returns>
        public static IComponentService InitializeServiceDiscovery(this IComponentService componentService, MicServerSetting micServerSetting, HealthCheckSetting healthCheckSetting)
        {
            _micServerSetting = micServerSetting;
            _healthCheckSetting = healthCheckSetting;

            /*
             * 设置健康检查
             */
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(_healthCheckSetting.DeregisterCriticalServiceAfter),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(_healthCheckSetting.HeathInterval),//健康检查时间间隔，或者称为心跳间隔
                HTTP = $"{_healthCheckSetting.HeathUrl}:{_healthCheckSetting.Port}{_healthCheckSetting.CheckPath}",//健康检查地址
                Timeout = TimeSpan.FromSeconds(_healthCheckSetting.TimeOut)
            };

            /*
             * 注册微信服信息
             */
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = _micServerSetting.Id.ToString(),
                Name = _micServerSetting.Name,
                Address = _micServerSetting.Url,
                Port = _micServerSetting.Port,
                Tags = _micServerSetting.Tags
            };

            _consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）

            return componentService;
        }
        #endregion

        #region 配置中心
        /// <summary>
        /// 初始化配置中心
        /// </summary>
        /// <param name="componentService"></param>
        /// <param name="consulServerSetting"></param>
        /// <returns></returns>
        public static IComponentService UseConsulConfiguationCenter(this IComponentService componentService)
        {
            //注册ConsulConfigurationService组件
            componentService.SetDefault<IConfigurationService, ConsulConfigurationService>();

            return componentService;
        }

        #endregion

    }
}
