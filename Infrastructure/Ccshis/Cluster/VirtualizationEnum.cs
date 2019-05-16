namespace Ccshis.Cluster
{
    /// <summary>
    /// 服务器类型
    /// </summary>
    public enum VirtualizationEnum
    {
        /// <summary>
        /// docker容器
        /// </summary>
        Docker=0,

        /// <summary>
        /// 实体服务器或虚拟机
        /// </summary>
        Machine=1
    }
}