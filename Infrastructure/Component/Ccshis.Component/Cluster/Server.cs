using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ccshis.Cluster
{
    public class Server : IServerNode
    {
        public long Id { get; set; }

        public VirtualizationEnum Virtualization { get; set; }

        public IPAddress IPAddress { get; set; }

        public string Name { get; set; }

        public string GroupName { get; set; }

        public string[] Tags { get; set; }

        public string Remark { get; set; }
    }
}
