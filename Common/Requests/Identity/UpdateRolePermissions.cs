using Common.Responses.Identity;

namespace Common.Requests.Identity
{
    public class UpdateRolePermissions
    {
        public string RoleId { get; set; } = string.Empty;
        public List<RoleClaimViewModel> RoleClaims { get; set; } = new();
    }
}
