using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Aliyun.LogExtend
{
    public static class ComponentManagerExtend
    {        
        /// <summary>
        /// 注册使用阿里云日志
        /// </summary>
        /// <param name="IComponentManager">IComponentManager</param>
        /// <param name="emailSetting">发件邮箱配置项</param>
        /// <returns></returns>
        public static IComponentManager UseEmail(this IComponentManager componentManager, AliyunLogSetting aliyunLogSetting)
        {
            componentManager.RegisterAssembly(typeof(ComponentManagerExtend).Assembly);
            return componentManager;
        }
    }
}
