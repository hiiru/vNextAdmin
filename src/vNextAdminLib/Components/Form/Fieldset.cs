using System;
using System.Text;

namespace vNextAdminLib.Components.Form
{
    public class Fieldset : AAdminPageItemChildren
    {
        public override string ViewComponentIdentifier { get { return "form"; } }
        public override string ViewComponentMethod { get { return "fieldset"; } }

        public bool Disabled { get; set; }

        public string CssClasses { get; set; }

        public string GetTagAttributes()
        {
            var sb = new StringBuilder();
            if (Disabled)
                sb.Append(" disabled=\"disabled\"");
            if (!string.IsNullOrWhiteSpace(CssClasses))
                sb.Append(" class=\""+CssClasses+"\"");
            return sb.ToString();
        }
    }
}