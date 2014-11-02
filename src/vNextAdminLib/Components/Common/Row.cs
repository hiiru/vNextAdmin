using System;
using System.Collections.Generic;

namespace vNextAdminLib.Components.Common
{
    public class Row : AAdminPageItemChildren
    {
        public override string ViewComponentIdentifier { get { return "common"; } }
        public override string ViewComponentMethod { get { return "row"; } }
        
    }
}