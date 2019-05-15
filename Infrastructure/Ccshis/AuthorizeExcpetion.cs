using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// catdemon 2019-5-4
    /// 权限身份认证异常
    /// 当平台发生权限验证失败时，抛出该异常信息
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-14
    /// opt:create
    /// </remarks>
    public class AuthorizeExcpetion:CoreException
    {
        /// <summary>
        /// catdemon 2019-5-4
        /// 权限身份认证异常
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="localizationCode">多语言编码</param>
        /// <param name="innerException">内部异常</param>
        public AuthorizeExcpetion(string message = "", int localizationCode = 0, Exception innerException = null) 
            : base(message, localizationCode,innerException)
        {

        }
    }
}
