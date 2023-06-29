using Domain.Enums;

namespace Domain.DTOs;

public class GetInsuredDTO
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; } 

    public string CardNumber { get; set; }

    public string InsuredName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public GenderEnum Gender { get; set; }
}
