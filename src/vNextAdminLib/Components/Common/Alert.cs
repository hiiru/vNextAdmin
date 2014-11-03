using System;
using System.Collections.Generic;
using System.Text;

namespace vNextAdminLib.Components.Common
{
    public class Alert : AAdminPageItem
    {
        public override string ViewComponentIdentifier { get { return "common"; } }
        public override string ViewComponentMethod { get { return "alert"; } }
        
        public bool Dismissable { get; set; }
        public string Text { get; set; }
        public AlertStatus Status { get; set; }
        public bool IsHtmlText { get; set; }

        public string GetCssClasses()
        {
            var sb = new StringBuilder("alert alert-");
            switch (Status)
            {
                case AlertStatus.Danger:
                    sb.Append("danger");
                    break;
                case AlertStatus.Warning:
                    sb.Append("warning");
                    break;
                case AlertStatus.Success:
                    sb.Append("success");
                    break;
                case AlertStatus.Info:
                    sb.Append("info");
                    break;
            }
            if (Dismissable)
                sb.Append(" alert-dismissable");
            return sb.ToString();
        }
    }
    public enum AlertStatus
    {
        Info,
        Success,
        Warning,
        Danger
    }
}