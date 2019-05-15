using ECommon.Configurations;
using Exceptionless;
using System;

namespace Ccshis.ExceptionlessExtend
{
    public static class ComponentManagerExtend
    {
        public static IComponentManager UseExceptionless(this IComponentManager componentManager, ExceptionlessSetting exceptionlessSetting)
        {
            initExceptionless(exceptionlessSetting);

            componentManager.RegisterAssembly(typeof(ComponentManagerExtend).Assembly);
            return componentManager;
        }

        private static void initExceptionless(ExceptionlessSetting exceptionlessSetting)
        {
            //TODO这里修改
            ExceptionlessClient.Default.Configuration.ApiKey = exceptionlessSetting.ApiKey;
            ExceptionlessClient.Default.Configuration.ServerUrl = exceptionlessSetting.ServerUrl;
        }
    }
}
