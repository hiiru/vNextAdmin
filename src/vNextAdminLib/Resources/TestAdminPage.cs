using System;

namespace vNextAdminLib.Resources
{
    public class TestAdminPage : IAdminResource
    {
        public AdminResourceType Type { get { return AdminResourceType.AdminPage; } }

        public string Url { get { return "/Admin/Test"; } }
    }
}