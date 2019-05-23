using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// 框架级别的错误
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// date:2019-5-23
    /// opt:create
    /// </remarks>
    public class SysException:CoreException
    {
        public SysException(string message = SystemConst.EmptyString, string localizationCode = SystemConst.ValueIsEmpty, Exception innerException = null)
           : base(message, localizationCode, innerException)
        {

        }

        public SysException(Enum[] messageCode, Enum[] localizationCode, Exception innerException = null)
            : base(messageCode, localizationCode, innerException)
        {

        }
    }
}
