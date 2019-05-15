using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Information.Sms.Ali
{
    /// <summary>
    /// 阿里云短信模板
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-15
    /// opt:create
    /// </remarks> 
    public class SmsInformation:IInformation
    {
        /// <summary>
        /// 短信模板编码
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 短信签名
        /// </summary>
        public string Signs { get; set; }

        /// <summary>
        /// 发送信息的内容
        /// </summary>
        public string Body { get; set; }
    }
}
