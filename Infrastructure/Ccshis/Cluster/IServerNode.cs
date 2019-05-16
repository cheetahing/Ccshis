using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ccshis.Cluster
{
    /// <summary>
    /// 服务节点
    /// </summary>
    public interface IServerNode
    {
        /// <summary>
        /// 服务器Id
        /// </summary>
        long Id { get; }

        /// <summary>
        /// 虚拟化类型
        /// </summary>
        VirtualizationEnum Virtualization { get; }

        /// <summary>
        /// 服务器地址
        /// </summary>
        IPAddress IPAddress { get; }

        /// <summary>
        /// 服务器名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 服务器组
        /// </summary>
        string GroupName { get;}

        /// <summary>
        /// 服务器标签
        /// </summary>
        string[] Tags { get;}

        /// <summary>
        /// 备注
        /// </summary>
        string Remark { get; }
    }
}
