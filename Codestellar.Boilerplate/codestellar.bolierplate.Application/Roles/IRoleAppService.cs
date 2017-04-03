using System.Threading.Tasks;
using Abp.Application.Services;
using codestellar.bolierplate.Roles.Dto;

namespace codestellar.bolierplate.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
