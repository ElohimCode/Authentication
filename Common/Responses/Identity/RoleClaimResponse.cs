namespace Common.Responses.Identity
{
    public class RoleClaimResponse
    {
        public RoleResponse Role { get; set; } = new RoleResponse();
        public List<RoleClaimViewModel> RoleClaims { get; set; } = new();
    }
}
