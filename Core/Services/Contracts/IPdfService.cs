using Domain.Models;

namespace Core.Services.Contracts
{
    public interface IPdfService
    {
        Task<PdfDocument> CreatePdf(ClaimSearchFilter filter);
    }
}