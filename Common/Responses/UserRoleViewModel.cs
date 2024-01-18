namespace Common.Responses
{
    public class UserRoleViewModel
    {
        public string RoleName { get; set; } = string.Empty;
        public string RoleDescription { get; set; } = string.Empty;
        public bool IsAssignedToUser { get; set; }
    }
}
