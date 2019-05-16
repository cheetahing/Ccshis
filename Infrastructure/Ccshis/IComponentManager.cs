using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using ECommon.Configurations;
using ECommon.Components;

namespace Ccshis
{
    /// <summary>
    /// 组件及容器管理器
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-5-16
    /// opt:create
    /// remark:
    /// 引入ecommon的ioc容器管理，ecommon ioc容器抽象一层容器管理器无关的配置类。
    /// 由于ecommon中容器管理是单例，不允许继承，架构把他的方法重新实现了一遍。
    /// 目前整个架构容器管理器默认使用autofac
    /// </remarks>
    public interface IComponentManager
    {
        void RegisterAssembly(Assembly assembly);

        #region ecommon ioc容器管理的相关方法
        /// <summary>
        /// 造告整个容器
        /// </summary>
        /// <returns></returns>
        Configuration BuildContainer();

        /// <summary>
        /// 注册默认公共组件
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// author:catdemon
        /// data:2019-5-16
        /// opt:create
        /// </remarks>
        Configuration RegisterCommonComponents();

        Configuration RegisterUnhandledExceptionHandler();

        /// <summary>
        /// 设置默认的组件
        /// </summary>
        /// <typeparam name="TService">组件接口</typeparam>
        /// <typeparam name="TImplementer">组件实现类</typeparam>
        /// <param name="serviceName">组件名称</param>
        /// <param name="life">生命周期，默认为单例</param>
        /// <returns></returns>
        /// <remarks>
        /// author:catdemon
        /// data:2019-5-16
        /// opt:create
        /// </remarks>
        Configuration SetDefault<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService;

        /// <summary>
        /// 设置默认的组件
        /// </summary>
        /// <typeparam name="TService">组件接口</typeparam>
        /// <typeparam name="TImplementer">组件实现类</typeparam>
        /// <param name="instance">组件实例</param>
        /// <param name="serviceName">组件名称</param>
        /// <returns></returns>
        /// <remarks>
        /// author:catdemon
        /// data:2019-5-16
        /// opt:create
        /// </remarks>
        Configuration SetDefault<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService;
        #endregion
    }
}
