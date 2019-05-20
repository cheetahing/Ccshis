using ECommon.Configurations;
using Exceptionless;
using System;

namespace Ccshis.ExceptionlessExtend
{
    public static class ComponentServiceExtend
    {
        public static IComponentService UseExceptionless(this IComponentService componentService, ExceptionlessSetting exceptionlessSetting)
        {
            initExceptionless(exceptionlessSetting);

            componentService.RegisterAssembly(typeof(ComponentManagerExtend).Assembly);
            return componentService;
        }

        private static void initExceptionless(ExceptionlessSetting exceptionlessSetting)
        {
            //TODO这里修改
            ExceptionlessClient.Default.Configuration.ApiKey = exceptionlessSetting.ApiKey;
            ExceptionlessClient.Default.Configuration.ServerUrl = exceptionlessSetting.ServerUrl;
        }
    }
}
