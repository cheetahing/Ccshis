using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Aliyun.LogExtend
{
    public static class ComponentServiceExtend
    {        
        /// <summary>
        /// 注册使用阿里云日志
        /// </summary>
        /// <param name="IComponentService">IComponentService</param>
        /// <param name="emailSetting">发件邮箱配置项</param>
        /// <returns></returns>
        public static IComponentService UseEmail(this IComponentService componentService, AliyunLogSetting aliyunLogSetting)
        {
            componentService.RegisterAssembly(typeof(ComponentServiceExtend).Assembly);
            return componentService;
        }
    }
}
