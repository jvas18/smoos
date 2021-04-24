using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Smoos.Domain.Users
{
    public enum EUserProfile
    {
        [Description("Administrator")]
        Admin,
        [Description("Common")]
        Common

    }
}
