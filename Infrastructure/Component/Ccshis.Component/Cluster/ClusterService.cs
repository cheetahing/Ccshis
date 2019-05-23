using Ccshis.Settings.Cluster;
using ECommon.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ccshis.Cluster
{
    [Component]
    public class ClusterService : IClusterService
    {
        /// <summary>
        /// 当前服务器所在集群内的成员信息
        /// </summary>
        /// <remarks>
        /// author:catdemon
        /// date:2019-5-21
        /// </remarks>
        public IServerMember ServerMember { get; private set; }

        private IFileConfigurationService _fileConfigurationService;

        public ClusterService(IFileConfigurationService fileConfigurationService)
        {
            _fileConfigurationService = fileConfigurationService;
        }

        /// <summary>
        /// 加入集群
        /// </summary>
        /// <param name="clusterServerIp"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public IServerMember JoinCluster(string clusterServerIp, IServerMember serverMember)
        {
            //todo
            /*
             * 调用集群组件，注册服务，并获取分配到的服务器IServerMember.Id
             * IServerMember.Id作为雪花算法的服务器节点id
             */
            var serverMemberInstance = serverMember as ServerMember;

           //模拟服务器分配的节点id
            var config = _fileConfigurationService.GetAsync<ServerMemberSetting>(SettingsPath.ServerMemberSettingPath);
            if (config == null)
            {
#warning 随机分配一个节点id，需要使用集群管理进行分配
                /*后期需要修改为，跟服务器通信，然后再分配服务器集群成员id*/
                serverMemberInstance.Id = new System.Random().Next(1000);
            }
            else
            {
                serverMemberInstance.Id = config.Id;
            }

            ServerMember = serverMemberInstance as IServerMember;

            return ServerMember;
        }

        /// <summary>
        /// 离开集群
        /// </summary>
        /// <param name="clusterServerIp"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public IServerMember QuitCluster(string clusterServerIp, IServerMember member)
        {
            //todo 退出服务
            throw new NotImplementedException();
        }
    }
}
