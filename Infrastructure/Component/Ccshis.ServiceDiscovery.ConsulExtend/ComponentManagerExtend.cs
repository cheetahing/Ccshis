using System;

namespace Ccshis.ServiceDiscovery.ConsulExtend
{
    public static class ComponentManagerExtend
    {
        public static IComponentManager UseConsul(this IComponentManager componentManager, ConsulSetting consulSetting)
        {
            componentManager.RegisterAssembly(typeof(ComponentManagerExtend).Assembly);
            return componentManager;
        }
    }
}
