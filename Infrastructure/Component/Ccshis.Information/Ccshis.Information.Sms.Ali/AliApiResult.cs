using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Information.Sms.Ali
{
    /// <summary>
    /// 阿里云短信调用结果
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// date:2019-5-23
    /// opt:create
    /// </remarks>
    class AliApiResult
    {
        public string Message { get; set; }
        public string RequestId { get; set; }
        public string BizId { get; set; }

        /// <summary>
        /// 返回代码，如果成功返回OK
        /// </summary>
        public string Code { get; set; }
    }
}
