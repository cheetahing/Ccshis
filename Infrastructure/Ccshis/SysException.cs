using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    public class SysException:CoreException
    {
        public SysException(string message = SystemConst.EmptyString, string localizationCode = SystemConst.ValueIsEmpty, Exception innerException = null)
           : base(message, localizationCode, innerException)
        {

        }
    }
}
