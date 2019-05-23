using Ccshis.Settings;
using ECommon.Configurations;

namespace Ccshis.Information.Sms.Ali
{
    /// <summary>
    /// 注册使用阿里云短信
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-15
    /// opt:create
    /// </remarks> 
    /// <example>
    /// componentService.UseAliSms(aliSmsSetting);
    /// </example>
    public static class ComponentServiceExtend
    {
        /// <summary>
        /// 注册使用阿里云短信组件
        /// </summary>
        /// <param name="IComponentService">IComponentService</param>
        /// <param name="aliSmsSetting">阿里云配置<see cref="Ccshis.Information.Sms.Ali.AliSmsSetting"/></param>
        /// <returns></returns>
        public static IComponentService UseAliSms(this IComponentService componentService)
        {
            componentService.SetDefault<ISmsSender, SmsSender>();

            componentService.RegisterAssembly(typeof(ComponentServiceExtend).Assembly);
            return componentService;
        }

        public static IComponentService InitializeAliSms(this IComponentService componentService,AliYunApiSetting aliYunApiSetting)
        {
            var smsSender=ComponentContainer.Resolve<ISmsSender>();
            return componentService;
        }
    }
}
