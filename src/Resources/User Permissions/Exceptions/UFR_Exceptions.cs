using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModel.User_Permissions.Exceptions
{
    public class ActiveRoleNotSetException : Exception
    {
        public ActiveRoleNotSetException() { }

        public ActiveRoleNotSetException(String mess) : base(mess) {}

        public ActiveRoleNotSetException(String mess, Exception inner) : base(mess, inner) { }
    }

    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException() { }

        public RoleNotFoundException(String mess) : base(mess) { }

        public RoleNotFoundException(String mess, Exception inner) : base(mess, inner) { }
    }

    public class UserHasNoRoleException : Exception
    {
        public UserHasNoRoleException() { }

        public UserHasNoRoleException(String mess) : base(mess) { }

        public UserHasNoRoleException(String mess, Exception inner) : base(mess, inner) { }
    }

    public class FeatureNotFoundException : Exception
    {
        public FeatureNotFoundException() { }

        public FeatureNotFoundException(String mess) : base(mess) { }

        public FeatureNotFoundException(String mess, Exception inner) : base(mess, inner) { }
    }
}
