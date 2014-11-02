using System;
using System.Collections.Generic;

namespace vNextAdminLib.Components
{
    public interface IAdminMenuEntry : IAdminComponent
    {
        bool IsTopMenu { get; }

        string Label { get; }
        string Target { get; }
    }
}