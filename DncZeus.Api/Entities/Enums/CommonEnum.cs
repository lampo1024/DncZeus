/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

namespace DncZeus.Api.Entities.Enums
{
    /// <summary>
    /// 通用枚举类
    /// </summary>
    public class CommonEnum
    {
        /// <summary>
        /// 是否已删
        /// </summary>
        public enum IsDeleted
        {
            /// <summary>
            /// 所有
            /// </summary>
            All=-1,
            /// <summary>
            /// 否
            /// </summary>
            No = 0,
            /// <summary>
            /// 是
            /// </summary>
            Yes = 1
        }

        /// <summary>
        /// 是否已被锁定
        /// </summary>
        public enum IsLocked
        {
            /// <summary>
            /// 未锁定
            /// </summary>
            UnLocked = 0,
            /// <summary>
            /// 已锁定
            /// </summary>
            Locked = 1
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        public enum IsEnabled
        {
            /// <summary>
            /// 否
            /// </summary>
            No = 0,
            /// <summary>
            /// 是
            /// </summary>
            Yes = 1
        }


        /// <summary>
        /// 用户状态
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// 未指定
            /// </summary>
            All = -1,
            /// <summary>
            /// 已禁用
            /// </summary>
            Forbidden = 0,
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 1
        }

        /// <summary>
        /// 权限类型
        /// </summary>
        public enum PermissionType
        {
            /// <summary>
            /// 菜单
            /// </summary>
            Menu = 0,
            /// <summary>
            /// 按钮/操作/功能
            /// </summary>
            Action = 1
        }

        /// <summary>
        /// 是否枚举
        /// </summary>
        public enum YesOrNo
        {
            /// <summary>
            /// 所有
            /// </summary>
            All = -1,
            /// <summary>
            /// 否
            /// </summary>
            No = 0,
            /// <summary>
            /// 是
            /// </summary>
            Yes = 1
        }
    }
}
