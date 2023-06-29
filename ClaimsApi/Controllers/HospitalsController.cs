using Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HospitalsController : ControllerBase
{
    #region Private Readonly Fields
    private readonly IHospitalsService HospitalService;

    #endregion

    #region Constructor
    public HospitalsController(IHospitalsService hospitalService)
    {
        HospitalService = hospitalService;
    }
    #endregion

    #region Web Actions
    #region Get Hospitals
    // returns a dictionary of hospital names and their respective enum int
    // useful for dropdown lists
    // Cached Client-Side for performance improvement on larger datasets
    [HttpGet]
    [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]
    public IActionResult Get() => Ok(HospitalService.GetLookup());  
    #endregion
    #endregion
}
