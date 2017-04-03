using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using codestellar.bolierplate.MultiTenancy;

namespace codestellar.bolierplate.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}