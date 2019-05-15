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
    /// componentManager.UseEmail(emailSetting);
    /// </example>
    public static class ComponentManagerExtend
    {
        /// <summary>
        /// 注册使用电子邮件组件
        /// </summary>
        /// <param name="IComponentManager">IComponentManager</param>
        /// <param name="emailSetting">发件邮箱配置项</param>
        /// <returns></returns>
        public static IComponentManager UseEmail(this IComponentManager componentManager,EmailSetting emailSetting)
        {
            componentManager.RegisterAssembly(typeof(ComponentManagerExtend).Assembly);
            return componentManager;
        }
    }
}
