using Core.Services.Contracts;
using Domain.Enums;

namespace Core.Services.Implementations;

public class DoctorsService : BaseEnumService<DoctorsEnum>, IDoctorsService
{
    public DoctorsService() : base()
    {
        
    }
}
