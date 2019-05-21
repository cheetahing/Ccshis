namespace Ccshis.Cluster
{
    /// <summary>
    /// 虚拟化类型
    /// </summary>
    public enum Virtualization
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