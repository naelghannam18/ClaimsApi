using Core.Services.Contracts;
using Domain.DTOs;
using Domain.Extensions;
using Domain.Models;
using OfficeOpenXml;

namespace Core.Services.Implementations;

public class ExcelService : IExcelService
{
    #region Private readonly Fields
    private readonly IClaimsService ClaimsService;
    #endregion

    #region Constructor
    public ExcelService(IClaimsService claimService)
    {
        ClaimsService = claimService;
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }
    #endregion

    #region Public Methods
    public async Task<MemoryStream> CreateExcel(ClaimSearchFilter filter)
    {
        var stream = new MemoryStream();

        var claims = await ClaimsService.Get(filter);

        using (var package = new ExcelPackage(stream))
        {
            var worksheet = package.Workbook.Worksheets.Add("Claims");
            CreateHeaders(worksheet);
            FilLData(worksheet, claims);

            // Auto-fit columns
            worksheet.Cells.AutoFitColumns();

            // Save the changes to the stream
            package.Save();
        }

        // Reset the stream position
        stream.Position = 0;

        return stream;
    }

    #endregion

    #region Private Methods
    private static void CreateHeaders(ExcelWorksheet worksheet)
    {
        // Set headers
        worksheet.Cells[1, 1].Value = "Insured ID";
        worksheet.Cells[1, 2].Value = "Hospital";
        worksheet.Cells[1, 3].Value = "Treating Doctor";
        worksheet.Cells[1, 4].Value = "Claim Status";
        worksheet.Cells[1, 5].Value = "Admission Date";
        worksheet.Cells[1, 6].Value = "Medical Case";
        worksheet.Cells[1, 7].Value = "Amount";
        worksheet.Cells[1, 8].Value = "Remarks";
    }

    private static void FilLData(ExcelWorksheet worksheet, List<GetClaimDTO> claims)
    {
        if (claims.IsNullOrEmpty()) return;
        int row = 2;
        int col = 1;
        foreach (var claim in claims)
        {
            // Fill data
            worksheet.Cells[row, 1].Value = claim.InsuredId;
            worksheet.Cells[row, 2].Value = claim.Hospital;
            worksheet.Cells[row, 3].Value = claim.TreatingDoctor;
            worksheet.Cells[row, 4].Value = claim.ClaimStatus;
            worksheet.Cells[row, 5].Value = claim.AdmissionDate.ToString("yyyy-MM-dd");
            worksheet.Cells[row, 6].Value = claim.MedicalCase;
            worksheet.Cells[row, 7].Value = claim.Amount + "$";
            worksheet.Cells[row, 8].Value = claim.Remarks;

            row++;
            col++;
            if (col > 8) col = 1;
        }
        worksheet.Cells[row, 7].Value = "Total (Covered + Pending)";
        worksheet.Cells[row, 8].Value = claims.Select(c => c.Amount).Sum() + "$";
    } 
    #endregion
}
