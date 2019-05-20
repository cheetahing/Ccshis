using Ccshis;
using ECommon.Components;
using NUnit.Framework;
using ECommon.Autofac;
using Ccshis.ConsulComponent;
using BaseTest;

namespace Tests
{
    public class ComponentServicerExtendUnitTest:BaseTestClass
    {
        [Test]
        public void TestUseConsul()
        {
            /*
             * author:catdemon
             * date:2019-5-16
             * remark:
             * 测试注册到注册中心
             * 该测试没有心跳回应健康检查失败
            */
            componentService
                .UseConsul
                (
                    new ConsulServerSetting()
                    {
                        Url = "http://127.0.0.1",
                        Port = 8500
                    }
                )
                .UseConsulConfiguationCenter()
                .BuildContainer();

            componentService.InitializeServiceDiscovery(
                new MicServerSetting()
                {
                    Url = "127.0.0.1",
                    Port = 80,
                    Id = 1,
                    Name = "test.server",
                    Tags = new string[] { "test.server", "checkFail" }
                },
                new HealthCheckSetting()
                {
                    CheckPath = "/api/health",
                    DeregisterCriticalServiceAfter = 2,
                    HeathInterval = 10,
                    HeathUrl = "http://127.0.0.1",
                    TimeOut = 5
                });

            var configurationService = ObjectContainer.Resolve<IConfigurationService>();
            var result = configurationService.GetAsync("test/t1");

            componentService.CloseConsul();
        }
    }
}