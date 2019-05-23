using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ccshis.Util
{
    public static class LocalizationUtil
    {
        /// <summary>
        /// 构建多语言
        /// </summary>
        /// <param name="localization"></param>
        /// <returns></returns>
        public static string Build(Enum[] localization)
        {
            var result = new StringBuilder();

            foreach(Enum item in localization)
            {
                result.Append($"{item.ToString()},");
            }
            return result.Remove(result.Length - 1, 1).ToString();
        }

    }
}
