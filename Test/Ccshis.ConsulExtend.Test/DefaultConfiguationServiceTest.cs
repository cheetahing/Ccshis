using BaseTest;
using ECommon.Components;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

            var fileName = "test.json";
            var fileContext = "testFielContext";
            //var filePath = Path.Combine(DefaultConfiguationService.DefaultPath,fileName);

            //set configFile
            var fileConfigurationService = ObjectContainer.Resolve<IFileConfigurationService>();
            fileConfigurationService.SetAsync(fileName,fileContext);

            //get configFile
            var configurationService=ObjectContainer.Resolve<IConfigurationService>();
            var result=configurationService.GetAsync(fileName).GetAwaiter().GetResult();

            Assert.AreEqual(fileContext, result);

        }
    }
}
