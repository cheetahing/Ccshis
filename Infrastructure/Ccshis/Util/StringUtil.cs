using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Util
{
    /// <summary>
    /// 字符串处理工具类
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// date:2019-5-23
    /// </remarks>
    public static class StringUtil
    {
        private const string _default_splitChar = ",";

        /// <summary>
        /// 把数组对象拼接为字符串，使用默认obj.ToString()转为字符串
        /// </summary>
        /// <param name="objArray">数组对象</param>
        /// <param name="splitChar">拼接字符串，默认为逗号","</param>
        /// <returns>拼接后字符串</returns>
        public static string SplitJoint(object[] objArray,string splitChar= _default_splitChar)
        {
            return SplitJoint(objArray, splitChar, p => p.ToString());
        }

        /// <summary>
        /// 把数组对象拼接为字符串，使用默认objToStringAction委托把对象转为字符串
        /// </summary>
        /// <param name="objArray">数组对象</param>
        /// <param name="splitChar">拼接字符串</param>
        /// <param name="objToStringAction">返回拼接后字符串</param>
        /// <returns>拼接后字符串</returns>
        public static string SplitJoint(object[] objArray, string splitChar,Func<object,string> objToStringAction)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in objArray)
            {
                result.Append($"{objToStringAction(item)}{splitChar}");
            }
            return result.Remove(result.Length - 1, 1).ToString();
        }
    }
}
