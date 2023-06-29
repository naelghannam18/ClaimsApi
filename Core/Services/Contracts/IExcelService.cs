using Domain.Models;

namespace Core.Services.Contracts
{
    public interface IExcelService
    {
        Task<MemoryStream> CreateExcel(ClaimSearchFilter filter);
    }
}