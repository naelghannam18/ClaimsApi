using Core.Services.Contracts;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mime;

namespace ClaimsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClaimsController : ControllerBase
{
    #region Private Readonly Fields
    private readonly IClaimsService ClaimsService;
    private readonly IPdfService PdfService;
    private readonly IExcelService ExcelService;
    #endregion

    #region Constructor
    public ClaimsController(IClaimsService claimsService, IPdfService pdfService, IExcelService excelService)
    {
        ClaimsService = claimsService;
        PdfService = pdfService;
        ExcelService = excelService;
    }
    #endregion

    #region Web Actions
    #region Post
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateClaimDTO request)
    {
        var result = await ClaimsService.CreateClaim(request);
        return Ok(result);
    }
    #endregion

    #region Get By Id
    [HttpGet]
    [Route("{id:int:min(1)}")]
    public async Task<ActionResult<GetClaimDTO>> GetClaimById(int id)
    {
        var result = await ClaimsService.GetClaimById(id);
        if (result == null) { return NotFound(); }
        return Ok(result);
    }
    #endregion

    #region Region Get all with filtering
    [HttpPost]
    [Route("get")]
    // I preferred sending the filter parameters in a json body
    // So that the query parameters dont get too messy 
    public async Task<ActionResult<List<GetClaimDTO>>> GetClaims([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] ClaimSearchFilter? filter)
    {
        var results = await ClaimsService.Get(filter);
        return Ok(results);
    }
    #endregion

    #region Update

    [HttpPut]
    public async Task UpdateClaim([FromBody] GetClaimDTO request)
    {
        await ClaimsService.Update(request);
    }
    #endregion

    #region Delete
    [HttpDelete]
    public async Task DeleteClaims(int[] ids)
    {
        await ClaimsService.Delete(ids);
    }
    #endregion

    #region Create Pdf
    [HttpPost]
    [Route("pdf")]
    public async Task<ActionResult> GetPdf([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] ClaimSearchFilter? filter)
    {
        var pdfDocument = await PdfService.CreatePdf(filter);
        var title = "Claims.pdf";
        var dataBytes = pdfDocument.Stream;

        return File(dataBytes, "application/pdf", title);
    }
    #endregion

    #region Create Excel
    [HttpPost]
    [Route("excel")]
    public async Task<IActionResult> GetExcel([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] ClaimSearchFilter? filter)
    {
        var stream = await ExcelService.CreateExcel(filter);
        Response.Headers.Add("Content-Disposition", "attachment; filename=claims.xlsx");
        Response.Headers.Add("Content-Length", stream.Length.ToString());
        return File(stream.ToArray(), MediaTypeNames.Application.Octet, "claims.xlsx");
    }
    #endregion
    #endregion
}
