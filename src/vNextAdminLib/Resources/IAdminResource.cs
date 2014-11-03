using System;

namespace vNextAdminLib.Resources
{
    public interface IAdminResource
    {
        string Url { get; }
        AdminResourceType Type { get; }
    }
}