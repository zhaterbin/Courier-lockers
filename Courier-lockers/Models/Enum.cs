namespace Courier_lockers.Models
{
    public class Enum
    {
        /// <summary>
        /// 运行状态
        /// </summary>
        public enum RUN_STATUS_ENMU
        {
            /// <summary>
            /// 禁用
            /// </summary>
            Disable,
            /// <summary>
            /// 待用
            /// </summary>
            Enable,
            /// <summary>
            /// 运行
            /// </summary>
            Run
        }

        /// <summary>
        /// 存储状态
        /// </summary>
        public enum CELL_STATUS_ENUM
        {
            /// <summary>
            /// 有
            /// </summary>
            Full,
            /// <summary>
            /// 无
            /// </summary>
            Nohave,

            /// <summary>
            /// 异常
            /// </summary>
            Exception,

            /// <summary>
            /// 禁用
            /// </summary>
            Forbiden
        }
    }
}
