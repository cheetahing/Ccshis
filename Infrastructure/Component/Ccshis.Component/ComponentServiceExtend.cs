using System;
using System.Collections.Generic;
using System.Text;
using ECommon.Configurations;
using Ccshis.Cluster;

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

        /// <summary>
        /// 使用通用模块
        /// </summary>
        /// <param name="componentService"></param>
        /// <param name="defaultPath"></param>
        /// <returns></returns>
        /// <remarks>
        /// author:catdemon
        /// date:2019-5-21
        /// </remarks>
        public static IComponentService UseCommonComponent(this IComponentService componentService, string defaultPath = DefaultConfiguationService.DefaultPath)
        {
            //文件配置
            componentService.SetDefault<IFileConfigurationService, DefaultConfiguationService>(new DefaultConfiguationService(defaultPath));

            //集群组件
            componentService.SetDefault<IClusterService, ClusterService>();

            return componentService;
        }

        /// <summary>
        /// 使用默认配置中心，生产环境不建议使用该方法，请使用配置中心
        /// </summary>
        /// <param name="componentService"></param>
        /// <param name="defaultPath"></param>
        /// <returns></returns>
        public static IComponentService UseDefaultConfigurationService(this IComponentService componentService,string defaultPath= DefaultConfiguationService.DefaultPath)
        {
            //使用默认配置中心
            componentService.SetDefault<IConfigurationService, DefaultConfiguationService>(new DefaultConfiguationService(defaultPath));


            return componentService;
        }
    }
}
