using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Ccshis.Settings;
using Ccshis.Util;
using ECommon.Components;
using ECommon.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ccshis.Information.Sms.Ali
{
    [Component]
    public class SmsSender : ISmsSender
    {
        private const string _aliApiDomain = "dysmsapi.aliyuncs.com";
        private const string _aliApiVersion = "2017-05-25";
        private const string _AliApiAction = "SendSms";
        private const string _ApiResult_OK = "OK";

        private const string _profile_default = "default";

        private const string _param_PhoneNumbers = "PhoneNumbers";
        private const string _param_SignName = "SignName";
        private const string _param_TemplateCode = "TemplateCode";
        private const string _param_TemplateParam = "TemplateParam";

        private const string _splitPhoneNumber = ",";

        private ILogger _logger;
        private AliYunApiSetting _aliYunApiSetting;

        public SmsSender(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.Create(GetType().FullName);
        }
        public SmsSender(AliYunApiSetting aliYunApiSetting)
        {
            _aliYunApiSetting = aliYunApiSetting;
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
        public async Task SendAsync(string[] receivers, SmsInformation information)
        {
            await send(receivers, information);
        }

        private async Task send(string[] receivers, SmsInformation information)
        {
            await Task.Run(() =>
            {
                IClientProfile profile = DefaultProfile.GetProfile(_profile_default, _aliYunApiSetting.accessKeyId, _aliYunApiSetting.secret);
                DefaultAcsClient client = new DefaultAcsClient(profile);
                CommonRequest request = new CommonRequest();

                request.Method = MethodType.POST;
                request.Domain = _aliApiDomain;
                request.Version = _aliApiVersion;
                request.Action = _AliApiAction;
                // request.Protocol = ProtocolType.HTTP;

                string phoneNumbers = StringUtil.SplitJoint(receivers);

                request.AddQueryParameters(_param_PhoneNumbers, phoneNumbers);
                request.AddQueryParameters(_param_SignName, information.SignName);
                request.AddQueryParameters(_param_TemplateCode, information.TemplateCode);
                request.AddQueryParameters(_param_TemplateParam, information.TemplateParam);

                try
                {
                    CommonResponse response = client.GetCommonResponse(request);
                    var apiResult = JsonConvert.DeserializeObject<AliApiResult>(response.Data);

                    if (apiResult.Code != _ApiResult_OK)
                    {
                        sendErrorLog(Localization.Sy000100.ToString(), receivers, information);
                    }
                }
                catch (ServerException e)
                {
                    sendErrorLog(e.Message, receivers, information);
                }
                catch (ClientException e)
                {
                    sendErrorLog(e.Message, receivers, information);
                }
            });
        }

        private void sendErrorLog(string message,string[] receivers, SmsInformation information)
        {
            _logger.Error(new
            {
                message = "发送短信失败",
                exception = message,
                receivers = receivers,
                information = information
            });
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
        public async Task SendAsync<T>(string oneReceiver, T information)
        {
            await send(new[] { oneReceiver }, information as SmsInformation);
        }

        async Task ISmsSender.SendAsync(string[] receivers, SmsInformation information)
        {
            await SendAsync(receivers, information);
        }

        async Task ISmsSender.SendAsync(string receivers, SmsInformation information)
        {
            await SendAsync(receivers, information);
        }
    }
}
