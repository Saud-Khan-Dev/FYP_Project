
using Microsoft.AspNetCore.Mvc;

namespace Qec_Project.Api.Repository
{
public interface IAdminRepository
{
    public Task<(bool success,string message)> CreateAdmin(CreateAdminDTO createAdminDto);
    public Task<List<ResponseAdminDTO>> GetAdminData();
}
}