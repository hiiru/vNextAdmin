using System;
using System.Collections.Generic;

namespace vNextAdminLib.Components
{
    /// <summary>
    /// This Interfaces contains all the properties which are required for the generic component generation.
    /// </summary>
    public interface IAdminComponent
    {
        string ViewComponentIdentifier { get; }
        string ViewComponentMethod { get; }
    }
}