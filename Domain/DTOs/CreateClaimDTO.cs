using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class CreateClaimDTO
{
    public int InsuredId { get; set; }

    public HospitalsEnum Hospital { get; set; }

    public DoctorsEnum TreatingDoctor { get; set; }

    public ClaimStatusEnum ClaimStatus { get; set; }

    public DateTime AdmissionDate { get; set; }

    public string MedicalCase { get; set; }

    public decimal Amount { get; set; }

    public string Remarks { get; set; }
}
