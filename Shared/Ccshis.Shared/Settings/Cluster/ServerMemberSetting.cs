using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Settings.Cluster
{
    /// <summary>
    /// 服务器配置成员，注册到集群后，集群会分配一个服务器节点id给到当前节点
    /// 当前节点会存储集群分配的节点，并使用该节点作为雪花算法的服务器节点id
    /// </summary>
    /// <remarks>
    /// authro:catdemon
    /// date:2019-5-21
    /// </remarks>
    public class ServerMemberSetting:ISetting
    {
        /// <summary>
        /// 服务器节点，在集群中全局唯一
        /// </summary>
        public long Id { get; set; }
    }
}
