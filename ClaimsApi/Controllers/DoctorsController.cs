using Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        #region Private Readonly Fields
        private readonly IDoctorsService DoctorService;

        #endregion

        #region Constructor
        public DoctorsController(IDoctorsService doctorService)
        {
            DoctorService = doctorService;
        }
        #endregion

        #region Web Actions
        #region Get Doctors
        // returns a dictionary of Doctor names and their respective enum int
        // useful for dropdown lists
        // Cached Client-Side for performance improvement on larger datasets
        [HttpGet]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]
        public IActionResult GetDoctors() => Ok(DoctorService.GetLookup());  
        #endregion
        #endregion
    }
}
