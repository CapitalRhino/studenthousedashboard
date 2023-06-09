using System.ComponentModel;

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