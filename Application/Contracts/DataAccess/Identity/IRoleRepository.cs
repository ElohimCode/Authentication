using Common.Requests.Identity;
using Common.Responses.Wrappers;

namespace Application.Contracts.DataAccess.Identity
{
    public interface IRoleRepository
    {
        Task<IResponseWrapper> CreateAsync(CreateRole request);
        Task<IResponseWrapper> GetAsync();
        Task<IResponseWrapper> UpdateAsync(UpdateRole request);
        Task<IResponseWrapper> GetByIdAsync(string roleId);
        Task<IResponseWrapper> DeleteAsync(string roleId);
        Task<IResponseWrapper> GetPermissionsAsync(string roleId);
        Task<IResponseWrapper> UpdatePermissionsAsync(UpdateRolePermissions request);
    }
}
