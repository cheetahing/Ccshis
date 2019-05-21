using Ccshis.Cluster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Util
{
    public class IdentifiedGenerateService : IIdentifiedGenerateService
    {
        public IdentifiedGenerateService(IClusterService clusterService)
        {
            if(clusterService==null||clusterService.ServerMember==null)
            {
                throw new SysException();
            }
        }

        public long GetIdentified()
        {
            throw new NotImplementedException();
        }
    }
}
