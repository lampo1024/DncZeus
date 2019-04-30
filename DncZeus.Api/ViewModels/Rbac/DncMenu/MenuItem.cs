using System.Collections.Generic;

namespace DncZeus.Api.ViewModels.Rbac.DncMenu
{
    public class MenuItem
    {
        public MenuItem()
        {
            Meta = new MenuMeta();
            Children = new List<MenuItem>();
            MetaPermission = new List<string>();
        }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Component { get; set; }
        public string ParentId { get; set; }

        public bool MetaHideInMenu { get; set; }
        public string MetaIcon { get; set; }
        public bool MetaNotCache { get; set; }
        public string MetaTitle { get; set; }
        public List<string> MetaPermission { get; set; }
        /// <summary>
        /// 关闭前是否确认
        /// </summary>
        public bool MetaConfirmBeforeClose { get; set; }

        public MenuMeta Meta { get; set; }
        public List<MenuItem> Children { get; set; }
    }

    public class MenuMeta
    {
        public MenuMeta()
        {
            Permission = new List<string>();
        }
        public bool HideInMenu { get; set; }
        public string Icon { get; set; }
        public bool NotCache { get; set; }
        public string Title { get; set; }
        public List<string> Permission { get; set; }
        /// <summary>
        /// 关闭前是否确认
        /// </summary>
        public bool ConfirmBeforeClose { get; set; }
    }
}
