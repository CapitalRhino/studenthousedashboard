using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Models
{
    public enum UserRole
    {
        [Display(Name = "Tenant")]
        TENANT,
        [Display(Name = "Manager")]
        MANAGER,
        [Display(Name = "Administrator")]
        ADMIN
    }
}