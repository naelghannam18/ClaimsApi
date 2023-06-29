using Core.Services.Contracts;
using Domain.Enums;

namespace Core.Services.Implementations;

public class HospitalsService : BaseEnumService<HospitalsEnum>, IHospitalsService
{
    public HospitalsService() : base()
    {
        
    }
}
