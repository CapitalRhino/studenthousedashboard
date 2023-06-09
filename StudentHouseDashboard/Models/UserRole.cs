using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Models
{
    public enum UserRole
    {
        [Description("Tenant")]
        TENANT,
        [Description("Manager")]
        MANAGER,
        [Description("Administrator")]
        ADMIN
    }
}