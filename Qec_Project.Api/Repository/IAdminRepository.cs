
using Qec_Project.Api.model;
using QEC_Project.API.Common;

namespace Qec_Project.Api.Repository
{
public interface IAdminRepository
{
    public Task<Result<ResponseAdminDTO>> CreateAdmin(CreateAdminDTO createAdminDto);
    public Task<Result<ResponseAdminDTO>> GetAdminData(string id);
}
}