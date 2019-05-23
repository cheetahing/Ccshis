using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{    
    /// <summary>
    /// ccshis系统业务异常类
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-14
    /// opt:create
    /// </remarks>
    public class BizException:CoreException
    {
        public BizException(string message = SystemConst.EmptyString, string localizationCode = SystemConst.ValueIsEmpty, Exception innerException = null)
           :base(message,localizationCode,innerException)
        {

        }
        public BizException(Enum[] messageCode = null, Enum[] localizationCode = null, Exception innerException = null)
            : base(messageCode, localizationCode, innerException)
        {

        }
    }
}
