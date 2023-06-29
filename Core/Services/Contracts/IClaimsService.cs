using Domain.DTOs;
using Domain.Models;

namespace Core.Services.Contracts
{
    public interface IClaimsService
    {
        Task<int> CreateClaim(CreateClaimDTO request);
        Task Delete(params int[] ids);
        Task<List<GetClaimDTO>> Get(ClaimSearchFilter filter);
        Task<GetClaimDTO> GetClaimById(int id);
        Task Update(GetClaimDTO request);
    }
}