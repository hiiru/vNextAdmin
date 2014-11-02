using System;
using System.Collections.Generic;
using System.Text;

namespace vNextAdminLib.Components.Form
{
    public class Option : AFormComponent
    {
        public Option()
        {
            Values=new Dictionary<string, OptionItem>();
        }
        public override string ViewComponentMethod { get { return "option"; } }

        public string Label { get; set; }
        public bool Checkboxes { get; set; }
        public bool Inline { get; set; }

        public Dictionary<string, OptionItem> Values { get; set; }

        public string GetItemCss()
        {
            if (Checkboxes)
            {
                if (Inline)
                    return "checkbox-inline";
                return "checkbox";
            }
            if (Inline)
                return "radio-inline";
            return "radio";
        }

    }
    public class OptionItem
    {
        public string Label { get; set; }
        public bool Disabled { get; set; }
        public bool Checked { get; set; }

        public string GetTagAttributes(bool checkbox)
        {
            var sb = new StringBuilder();
            if (checkbox)
                sb.Append(" type=\"checkbox\"");
            else
                sb.Append(" type=\"radio\"");
            if (Disabled)
                sb.Append(" disabled=\"disabled\"");
            if (Checked)
                sb.Append(" checked=\"checked\"");
            return sb.ToString();
        }
    }
}