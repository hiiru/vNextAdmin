using System;
using System.Collections.Generic;
using System.Text;

namespace vNextAdminLib.Components.Form
{
    public class Select : AFormComponent
    {
        public Select()
        {
            Values = new Dictionary<string, SelectItem>();
        }
        public override string ViewComponentMethod { get { return "select"; } }

        public string Label { get; set; }
        public bool MultiSelect { get; set; }

        public Dictionary<string, SelectItem> Values { get; set; }
    }
    public class SelectItem
    {
        public string Label { get; set; }
        public bool Value { get; set; }
        public bool Disabled { get; set; }
        public bool Selected { get; set; }

        public string GetTagAttributes()
        {
            var sb = new StringBuilder();
            if (Disabled)
                sb.Append(" disabled=\"disabled\"");
            if (Selected)
                sb.Append(" selected=\"selected\"");
            return sb.ToString();
        }
    }
}