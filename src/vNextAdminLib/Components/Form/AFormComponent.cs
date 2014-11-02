using System;
using System.Collections.Generic;

namespace vNextAdminLib.Components.Form
{
    public abstract class AFormComponent : IAdminPageItem
    {
        public bool AllowsChildren { get { return false; } }
        public List<IAdminPageItem> Children { get { return null; } }
        public string ViewComponentIdentifier { get { return "form"; } }

        public abstract string ViewComponentMethod { get; }
        public bool Disabled { get; set; }
        public string StatusText { get; set; }
        public FormControlStatus Status { get; set; }

        public virtual string GetStatusCss()
        {
            switch (Status)
            {
                case FormControlStatus.Error:
                    return "has-error";
                case FormControlStatus.Warning:
                    return "has-warning";
                case FormControlStatus.Success:
                    return "has-success";
                default:
                    return "";
            }
        }

    }

    public enum FormControlStatus
    {
        None,
        Error,
        Warning,
        Success
    }
}