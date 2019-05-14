using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// ccshis系统数据异常类
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-014
    /// opt:create
    /// </remarks>
    public class DataException:CoreException
    {
        public DataException(string message = "", int localizationCode = 0, Exception innerException = null)
           : base(message, localizationCode, innerException)
        {
        }
    }
}
