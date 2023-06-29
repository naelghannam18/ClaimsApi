using Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InsuredController : ControllerBase
{
    #region Private readonly Fields
    private readonly IInsuredService InsuredService;
    #endregion

    #region Constructor
    public InsuredController(IInsuredService insuredService)
    {
        InsuredService = insuredService;
    }
    #endregion

    #region Web Actions
    #region Get By Card Number
    // This endpoint is useful when the the claims officer enters or swipes the card
    // they will get the data for autofill or get a 404 Error
    [HttpGet]
    [Route("card/{cardNumber}")]
    public async Task<IActionResult> Get(string cardNumber)
    {
        var results = await InsuredService.GetInsuredByCardNumber(cardNumber);

        if (results is not null) return Ok(results);
        return NotFound();
    }
    #endregion

    #region Get By Id
    [HttpGet]
    [Route("{id:int:min(1)}")]
    public async Task<IActionResult> GetById(int id)
    {
        var results = await InsuredService.GetInsuredById(id);
        if (results is not null) return Ok(results);
        return NotFound();
    }  
    #endregion
    #endregion
}
