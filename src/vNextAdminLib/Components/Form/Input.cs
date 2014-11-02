using System;
using System.Text;

namespace vNextAdminLib.Components.Form
{
    public class Input : AFormComponent
    {
        public Input()
        {
            Rows = 3;
        }
        public override string ViewComponentMethod { get { return "input"; } }

        public string Label { get; set; }
        public string Placholder { get; set; }
        public string Value { get; set; }

        public InputType Type { get; set; }
        /// <summary>
        /// This is only used if type is Textarea
        /// </summary>
        public int Rows { get; set; }

        public string GetTagAttributes()
        {
            var sb = new StringBuilder();
            if (Disabled)
                sb.Append(" disabled=\"disabled\"");
            if (!string.IsNullOrWhiteSpace(Placholder))
                sb.Append(" placeholder=\""+Placholder+"\"");

            switch (Type)
            {
                case InputType.Password:
                    sb.Append(" type=\"password\"");
                    break;
                case InputType.Text:
                    sb.Append(" type=\"text\"");
                    break;
            }

            return sb.ToString();
        }
    }
    public enum InputType
    {
        Text,
        Password,
        Static,
        Textarea
    }
}