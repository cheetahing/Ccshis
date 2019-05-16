using Ccshis;
using Ccshis.ServiceDiscovery.ConsulExtend;
using NUnit.Framework;

namespace Tests
{
    public class ComponentManagerExtendUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestUseConsul()
        {
            var componentManager=ComponentManager.Create();
            /*
             * author:catdemon
             * date:2019-5-16
             * remark:
             * 测试注册到注册中心
             * 该测试没有心跳回应健康检查失败
            */
            componentManager.UseConsul(new ConsulSetting(
                new ConsulServerSetting()
                {
                    Url="http://127.0.0.1",
                    Port=8500
                },
                new MicServerSetting()
                {
                    Url="127.0.0.1",
                    Port=80,
                    Id=1,
                    Name="test.server",
                    Tags = new string[]{ "test.server", "checkFail" }
                },
                new HealthCheckSetting()
                {
                    CheckPath="/api/health",
                    DeregisterCriticalServiceAfter=2,
                    HeathInterval=10,
                    HeathUrl="http://127.0.0.1",
                    TimeOut=5
                }
            ));
            componentManager.CloseConsul();
        }
    }
}