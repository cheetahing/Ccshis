using ECommon.Components;
using ECommon.Configurations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// 组件管理器，用于管理所有第三方组件的引入
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-16
    /// opt:create
    /// remark:
    /// 使用ecomom的容器管理类，详细参见本类的接口里说明
    /// </remarks>
    [Component]
    public class ComponentManager : IComponentManager
    {
        private List<Assembly> _assembliesList = new List<Assembly>();

        public static ComponentManager SingleInstance;

        /// <summary>
        /// enode配置组件
        /// </summary>
        private Configuration componentsConfiguration { get; set; }

        private ComponentManager() { }

        public static ComponentManager Create()
        {
            SingleInstance = new ComponentManager();
            return SingleInstance;
        }


        public void RegisterAssembly(Assembly assembly)
        {
            _assembliesList.Add(assembly);
        }

        public Configuration BuildContainer()
        {
            return componentsConfiguration.BuildContainer();
        }
        public Configuration RegisterCommonComponents()
        {
            //todo 初始化通用组件
            return componentsConfiguration.RegisterCommonComponents();
        }
        public Configuration RegisterUnhandledExceptionHandler()
        {
            return componentsConfiguration.RegisterUnhandledExceptionHandler();
        }
        public Configuration SetDefault<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            return componentsConfiguration.SetDefault<TService, TImplementer>(serviceName, life);
        }
        public Configuration SetDefault<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            return componentsConfiguration.SetDefault<TService, TImplementer>(instance, serviceName);
        }
    }
}
