namespace Ccshis.Information.Email
{
    /// <summary>
    /// 注册使用电子邮件组件，系统所有发的邮件，都由该组件提供
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-15
    /// opt:create
    /// </remarks> 
    /// <example>
    /// componentService.UseEmail(emailSetting);
    /// </example>
    public static class ComponentServiceExtend
    {
        /// <summary>
        /// 注册使用电子邮件组件
        /// </summary>
        /// <param name="IComponentService">IComponentService</param>
        /// <param name="emailSetting">发件邮箱配置项</param>
        /// <returns></returns>
        public static IComponentService UseEmail(this IComponentService componentService)
        {
            componentService.RegisterAssembly(typeof(ComponentServiceExtend).Assembly);
            return componentService;
        }
    }
}
