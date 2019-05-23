using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Settings
{
    /// <summary>
    /// 阿里去配制
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// date；2019-5-22
    /// </remarks>
    public class AliYunApiSetting:ISetting
    {
        public string accessKeyId { get; set; }
        public string secret { get; set; }

    }
}
