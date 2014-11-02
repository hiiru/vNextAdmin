using System;
using System.Text;

namespace vNextAdminLib.Components.Form
{
    public class Button : AFormComponent
    {
        public Button()
        {
            ButtonCss = "btn btn-default";
        }

        public override string ViewComponentMethod { get { return "button"; } }

        public string Label { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }

        public string ButtonCss { get; set; }

        public string GetTagAttributes()
        {
            var sb = new StringBuilder();
            sb.Append(" class=\""+ ButtonCss+"\"");

            if (!string.IsNullOrWhiteSpace(Type))
                sb.Append(" type=\"" + Type + "\"");

            if (Disabled)
                sb.Append(" disabled=\"disabled\"");

            return sb.ToString();
        }
    }
}