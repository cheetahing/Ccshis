namespace Ccshis.ExceptionlessExtend
{
    /// <summary>
    /// Exceptionless配制项
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-15
    /// opt:create
    /// </remarks> 
    public class ExceptionlessSetting : ISetting
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string ServerUrl { get; set; }

        /// <summary>
        /// apikey
        /// </summary>
        public string ApiKey { get; set; }
    }
}