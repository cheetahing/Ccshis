using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Information.Sms.Ali
{
    /// <summary>
    /// 阿里云短信发送
    /// </summary>    
    /// /// <remarks>
    /// author:catdemon
    /// data:2019-05-15
    /// opt:create
    /// </remarks> 
    interface ISmsSender    {
        void Send(List<string> receivers, SmsInformation information);
    }
}
