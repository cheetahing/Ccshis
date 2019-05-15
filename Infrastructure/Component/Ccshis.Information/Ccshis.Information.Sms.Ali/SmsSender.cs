using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Information.Sms.Ali
{
    [ECommon.Components.Component]
    public class SmsSender: ISmsSender
    {        
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="receivers">接收者</param>
        /// <param name="information">信息内容</param>
        /// <remarks>
        /// author:catdemon
        /// data:2019-05-15
        /// opt:create
        /// </remarks> 
        public void Send(List<string> receivers, SmsInformation information)
        {
            ///todo 发送逻辑
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
