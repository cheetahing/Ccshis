using System;
using System.Collections.Generic;
using System.Text;
using ECommon.Components;
using ECommon.Logging;
using ENode;
using Newtonsoft.Json;

namespace Ccshis.Information.Email
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="receivers">接收者邮箱</param>
    /// <param name="information">信息内容</param>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-15
    /// opt:create
    /// </remarks> 
    /// <exception cref="System.IO.IOException">调用网络错误</exception>
    [Component]
    public class EmailSender : IEmailSender, IInformationSender
    {
        private readonly ILogger _logger;

        public EmailSender(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.Create(GetType().FullName);
        }


        public void Send(List<string> receivers, EmaiInformation information)
        {
            _logger.Info("发送邮件成功:"+ JsonConvert.SerializeObject(new{ Receivers= receivers,Information= information }));
            //todo 发送邮件
        }

        void IInformationSender.Send<T>(List<string> receivers, T information)
        {
            this.Send(receivers, information as EmaiInformation);
        }
    }
}
