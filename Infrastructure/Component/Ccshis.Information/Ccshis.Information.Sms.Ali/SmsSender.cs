using ECommon.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Information.Sms.Ali
{
    [Component]
    public class SmsSender: ISmsSender, IInformationSender
    {        
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="receivers">接收者手机号码</param>
        /// <param name="information">信息内容</param>
        /// <remarks>
        /// author:catdemon
        /// data:2019-05-15
        /// opt:create
        /// </remarks> 
        /// <exception cref="System.IO.IOException">调用网络错误</exception>
        /// <exception cref="Ccshis.AuthorizeExcpetion">阿里云授权异常</exception>"
        /// <exception cref="Ccshis.BizException">业务异常</exception>
        public void Send(List<string> receivers, SmsInformation information)
        {
            ///todo 发送短信逻辑
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <typeparam name="T"><see cref="SmsInformation"/></typeparam>
        /// <param name="receivers">接收者</param>
        /// <param name="information">信息内容</param>
        /// <remarks>
        /// author:catdemon
        /// data:2019-05-15
        /// opt:create
        /// remark:显示实现接口
        /// </remarks> 
        void IInformationSender.Send<T>(List<string> receivers, T information)
        {
            this.Send(receivers, information as SmsInformation);
        }
    }
}
