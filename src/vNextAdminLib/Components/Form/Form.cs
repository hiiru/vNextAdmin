using System;
using System.Text;

namespace vNextAdminLib.Components.Form
{
    public class Form : AAdminPageItemChildren
    {
        public override string ViewComponentIdentifier { get { return "form"; } }
        public override string ViewComponentMethod { get { return "form"; } }

        public string Method { get; set; }
        public string Action { get; set; }

        public string GetTagAttributes()
        {
            var sb = new StringBuilder();
            if (Method!=null && Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
                sb.Append(" method=\"GET\"");
            else
                sb.Append(" method=\"POST\"");
            if (!string.IsNullOrWhiteSpace(Action))
                sb.Append(" action=\"" + Action + "\"");
            return sb.ToString();
        }
    }
}