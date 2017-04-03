using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using codestellar.bolierplate.MultiTenancy.Dto;

namespace codestellar.bolierplate.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
