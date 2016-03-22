using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.User_Permissions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PermissionHandled : System.Attribute { }

    [AttributeUsage(AttributeTargets.All)]
    public class HandleAccess : System.Attribute { }

    [AttributeUsage(AttributeTargets.All)]
    public class HandleVisibility : System.Attribute { }
}
