using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// 框架领域聚合根
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-14
    /// opt:create
    /// remark:框架使用雪花算法id，要求使用long作为聚合根id
    /// </remarks> 
    public class AggregateRoot:ENode.Domain.AggregateRoot<long>,IAggregateRoot
    {
    }
}
