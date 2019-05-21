using Ccshis;
using NUnit.Framework;
using System;

namespace BaseTest
{
    public class BaseTestClass
    {

        protected IComponentService componentService;

        [SetUp]
        public void SetUp()
        {
            componentService = ComponentService.Create();
            componentService
                .UseAutofac()
                .UseCommonComponent();
        }
    }
}
