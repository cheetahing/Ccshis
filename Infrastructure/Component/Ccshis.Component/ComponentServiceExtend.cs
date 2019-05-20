using System;
using System.Collections.Generic;
using System.Text;
using ECommon.Configurations;

namespace Ccshis
{
    public static class ComponentServiceExtend
    {
        /// <summary>
        /// 使用autofac作为依赖注入组件
        /// </summary>
        /// <param name="componentService"></param>
        /// <returns></returns>
        public static IComponentService UseAutofac(this IComponentService componentService)
        {
            var componentServiceImpl = componentService as ComponentService;
            componentServiceImpl.ComponentsConfiguration.UseAutofac();

            return componentService;
        }

        public static IComponentService UseDefaultConfigurationService(this IComponentService componentService)
        {
            componentService.SetDefault<IConfigurationService, DefaultConfiguationService>();

            return componentService;
        }
    }
}
