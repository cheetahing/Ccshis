using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Cluster
{
    public interface IClusterService
    {
        IServerMember ServerMember { get; }

        IServerMember JoinCluster(string clusterServerIp, IServerMember serverMember);

        IServerMember QuitCluster(string clusterServerIp, IServerMember serverMember);
    }
}
