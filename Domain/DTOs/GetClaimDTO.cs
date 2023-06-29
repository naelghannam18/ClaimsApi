namespace Domain.DTOs;

public class GetClaimDTO : CreateClaimDTO
{
    public int Id { get; set; }

    public GetInsuredDTO Insured { get; set; }
}
