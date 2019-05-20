using ECommon.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// 组件容器
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// date:2019-5-17
    /// remark:
    /// 引用ecommon的容器管理，ecommon使用了autofac容器管理器
    /// 为了避免ecommon的重构或变更引起框架变更，这里做了一层解耦
    /// </remarks>
    public class ComponentContainer
    {
        public static void Build()
        {
            ObjectContainer.Build();
        }

        public static void RegisterType(Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            ObjectContainer.RegisterType(implementationType, serviceName, life);
        }

        public static void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            ObjectContainer.RegisterType(serviceType,implementationType, serviceName,life);
        }

        public static TService Resolve<TService>() where TService : class
        {
            return ObjectContainer.Resolve<TService>();
        }

        public static object Resolve(Type serviceType)
        {
            return ObjectContainer.Resolve(serviceType);
        }

        public static TService ResolveNamed<TService>(string serviceName) where TService : class
        {
            return ObjectContainer.ResolveNamed<TService>(serviceName);
        }

        public static object ResolveNamed(string serviceName, Type serviceType)
        {
            return ObjectContainer.ResolveNamed(serviceName, serviceType);
        }

        public static bool TryResolve<TService>(out TService instance) where TService : class
        {
            return ObjectContainer.TryResolve<TService>(out instance);
        }

        public static bool TryResolve(Type serviceType, out object instance)
        {
            return ObjectContainer.TryResolve(serviceType, out instance);
        }

        public static bool TryResolveNamed(string serviceName, Type serviceType, out object instance)
        {
           return  ObjectContainer.TryResolveNamed(serviceName, serviceType,out instance);
        }

        public static void Register<TService, TImplementer>(string serviceName, LifeStyle life)
            where TService : class
            where TImplementer : class, TService
        {
            ObjectContainer.Register<TService,TImplementer>(serviceName, life);
        }

        public void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName)
            where TService : class
            where TImplementer : class, TService
        {
            ObjectContainer.RegisterInstance<TService, TImplementer>(instance, serviceName);
        }
    }
}
