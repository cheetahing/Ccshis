using Ccshis.Cluster;
using System;
using System.Collections.Generic;
using System.Text;
using Snowflake.Core;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Ccshis.Util
{
    public class IdentifiedGenerateService : IIdentifiedGenerateService
    {
        IdWorker _idWorker;

        public IdentifiedGenerateService(IClusterService clusterService)
        {
            if(clusterService==null||clusterService.ServerMember==null)
            {
                throw new SysException(ExcpetionCode.EX1100000.ToString(), Localization.Sy000000.ToString());
            }

            _idWorker = new IdWorker(clusterService.ServerMember.Id, 1);
        }

        public long GetIdentified()
        {
            return _idWorker.NextId();
        }
    }
}
