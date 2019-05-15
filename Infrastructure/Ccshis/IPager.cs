using System;

namespace Ccshis
{
    /// <summary>
    /// 分页数据接口
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-15
    /// opt:create
    /// </remarks>
    public interface IPager
    {
        int pageIndex { get; set; }

        int PageSize { get; set; }

        int Totle { get; set; }
    }
}
