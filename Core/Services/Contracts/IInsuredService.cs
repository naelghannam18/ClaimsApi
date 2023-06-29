using Domain.DTOs;

namespace Core.Services.Contracts
{
    public interface IInsuredService
    {
        Task<GetInsuredDTO?> GetInsuredByCardNumber(string cardNumber);

        Task<GetInsuredDTO?> GetInsuredById(int id);
    }
}