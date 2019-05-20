using BaseTest;
using ECommon.Components;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.ConsulExtend.Test
{
    public class DefaultConfiguationServiceTest:BaseTestClass
    {
        [Test]
        public void TestGet()
        {
            this.componentService
                .UseDefaultConfigurationService()
                .BuildContainer();
            var configurationService=ObjectContainer.Resolve<IConfigurationService>();
            var test=configurationService.Get("test.json");

        }
    }
}
