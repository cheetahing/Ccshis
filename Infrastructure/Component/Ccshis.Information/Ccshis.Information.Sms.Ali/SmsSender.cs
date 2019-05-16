using ECommon.Components;
using ECommon.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ccshis.Information.Sms.Ali
{
    [Component]
    public class SmsSender: ISmsSender, IInformationSender
    {
        private ILogger _logger;

        public SmsSender(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.Create(GetType().FullName);
        }

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
        public async Task SendAsync(List<string> receivers, SmsInformation information)
        {
            await Task.Run(() => 
            {
                ///todo 发送短信逻辑
                //
            });
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
        async Task IInformationSender.SendAsync<T>(List<string> receivers, T information)
        {
            await SendAsync(receivers, information as SmsInformation);
        }
    }
}
