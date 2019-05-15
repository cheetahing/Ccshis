using log4net.Appender;
using log4net.Core;
using System;

namespace Ccshis.Aliyun.LogExtend
{
    public class AliYunLogAppend : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            //todo 写入阿里云日志
        }
    }
}
