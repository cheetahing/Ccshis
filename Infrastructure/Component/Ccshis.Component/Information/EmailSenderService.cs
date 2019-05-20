using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// data:2019-05-16
    /// opt:create
    /// </remarks> 
    /// <exception cref="System.IO.IOException">调用网络错误</exception>
    [Component]
    public class EmailSenderService : IEmailSenderService, IInformationSenderService
    {
        private readonly ILogger _logger;

        public EmailSenderService(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.Create(GetType().FullName);
        }


        public async Task SendAsync(List<string> receivers, EmaiInformation information)
        {
            await Task.Run(() =>
            { 
                //todo 发送邮件
            });

            _logger.Info("发送邮件成功:"+ JsonConvert.SerializeObject(new{ Receivers= receivers,Information= information }));
        }

        async Task IInformationSenderService.SendAsync<T>(List<string> receivers, T information)
        {
            await this.SendAsync(receivers, information as EmaiInformation);
        }
    }
}
