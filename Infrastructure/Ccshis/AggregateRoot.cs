using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis
{
    /// <summary>
    /// ccshis领域聚合根
    /// </summary>
    /// <remarks>
    /// author:catdemon
    /// data:2019-05-014
    /// opt:create
    /// </remarks> 
    public class AggregateRoot:ENode.Domain.AggregateRoot<long>,IAggregateRoot
    {
    }
}
