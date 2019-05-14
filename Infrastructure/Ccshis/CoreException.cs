using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// ccshis系统核心异常类
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-014
    /// opt:create
    /// </remarks>
    public class CoreException:Exception
    {
        /// <summary>
        /// 多语言编号
        /// </summary>
        public int LocalizationCode { get; private set; }

        /// <summary>
        /// 核心异常类
        /// </summary>
        /// <completionlist cref=""/>
        /// <param name="message">异常消息</param>
        /// <param name="localizationCode">多语言编码</param>
        /// <param name="innerException">内部异常</param>
        public CoreException(string message="",int localizationCode=0,Exception innerException=null):base(message,innerException)
        {
            this.LocalizationCode = localizationCode;
        }

    }
}
