
using Microsoft.AspNetCore.Mvc;
using Qec_Project.Api.model;

namespace Qec_Project.Api.Repository
{
public interface IAdminRepository
{
    public Task<ResponseDTO> CreateAdmin(CreateAdminDTO createAdminDto);
    public Task<List<ResponseAdminDTO>> GetAdminData();
}
}