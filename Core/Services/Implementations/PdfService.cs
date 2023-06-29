using Core.Services.Contracts;
using Domain.DTOs;
using Domain.Enums;
using Domain.Html;
using Domain.Models;
using System.Text;

namespace Core.Services.Implementations;

public class PdfService : IPdfService
{
    private readonly IClaimsService ClaimsService;

    public PdfService(IClaimsService claimsService)
    {
        ClaimsService = claimsService;
    }

    public async Task<PdfDocument> CreatePdf(ClaimSearchFilter? filter)
    {
        var ChromePdfRenderer = new ChromePdfRenderer();
        ChromePdfRenderer.RenderingOptions.FirstPageNumber = 1;

        CreateHeader(ChromePdfRenderer, filter);
        CreateFooter(ChromePdfRenderer);

        var results = await ClaimsService.Get(filter);
        var sb = new StringBuilder();
        
        sb.AppendLine($"<p>{GenerateFilterText(filter)}</p>");
        sb.Append(PdfHtmlStrings.HtmlStart);
        sb.Append(GenerateTable(results));
        sb.Append(PdfHtmlStrings.HtmlEnd);

        var htmlResult = sb.ToString();
        return ChromePdfRenderer.RenderHtmlAsPdf(htmlResult);
    }

    private static void CreateHeader(ChromePdfRenderer renderer, ClaimSearchFilter? filter)
    {


        renderer.RenderingOptions.TextHeader.DrawDividerLine = true;
        renderer.RenderingOptions.UseMarginsOnHeaderAndFooter = UseMargins.All;
        
        renderer.RenderingOptions.TextHeader.CenterText = "Claims";
        renderer.RenderingOptions.TextHeader.FontSize = 12;
    }

    private static void CreateFooter(ChromePdfRenderer renderer)
    {
        renderer.RenderingOptions.TextFooter.DrawDividerLine = true;
        renderer.RenderingOptions.TextFooter.FontSize = 10;
        renderer.RenderingOptions.TextFooter.LeftText = "{date} {time}";
        renderer.RenderingOptions.TextFooter.RightText = "Page {page}";
    }

    private static string GenerateTable(List<GetClaimDTO> claims)
    {
        var sb = new StringBuilder();
        sb.Append(PdfHtmlStrings.TableStart);
        foreach (var claim in claims)
        {
            sb.AppendFormat(
                PdfHtmlStrings.TableRow,
                claim.AdmissionDate,
                claim.Insured.CardNumber,
                claim.Insured.InsuredName,
                Enum.GetName(typeof(HospitalsEnum),
                claim.Hospital),
                claim.MedicalCase,
                claim.Amount,
                Enum.GetName(typeof(ClaimStatusEnum), claim.ClaimStatus)
                );
        }

        var total = claims
            .Where(c => c.ClaimStatus == ClaimStatusEnum.Covered || c.ClaimStatus == ClaimStatusEnum.Pending)
            .Select(c => c.Amount)
            .Sum();

        sb.AppendFormat(PdfHtmlStrings.TotalRowHtml, total);
        return sb.ToString();
    }

    private static string GenerateFilterText(ClaimSearchFilter filter)
    {
        var filterStringBuilder = new StringBuilder();

        if (filter is not null)
        {
            filterStringBuilder.Append("Claims by: ");

            if (filter.Hospital is not null)
            {
                filterStringBuilder.AppendLine($"Hospital: {Enum.GetName(typeof(HospitalsEnum), filter.Hospital)}<br/>");
            }
            if (filter.ClaimStatus is not null)
            {
                filterStringBuilder.AppendLine($"Claim Status: {Enum.GetName(typeof(ClaimStatusEnum), filter.ClaimStatus)}<br/>");
            }
            if (filter.CardNumber is not null)
            {
                filterStringBuilder.AppendLine($"Card Number: {filter.CardNumber}<br/>");
            }
            if (filter.Range is not null)
            {
                filterStringBuilder.AppendLine($"From: {filter.Range.From.ToString("dd/mm/yy")} - To: {filter.Range.To.ToString("dd/mm/yy")}<br/>");
            }
        }
        return filterStringBuilder.ToString();
    }
    
}
