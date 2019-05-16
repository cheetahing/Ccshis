using Consul;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.ServiceDiscovery.ConsulExtend
{
    public interface IConsulSetting
    {
        void InitFromConsulSetting(AgentServiceCheck agentServiceCheck, AgentServiceRegistration agentServiceRegistration);

        AgentServiceCheck AgentServiceCheck { get; }

        AgentServiceRegistration AgentServiceRegistration { get;}
    }
}
