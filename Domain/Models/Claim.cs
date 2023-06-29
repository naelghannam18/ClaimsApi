using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Claim")]
[Index(nameof(Id))]
public class Claim : IBaseDatabaseModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Required]
    public DateTime AdmissionDate { get; set; }

    [Required]
    [ForeignKey(nameof(InsuredId))]
    public Insured Insured { get; set; }

    [Required]
    public int InsuredId { get; set; }

    [Required]
    public HospitalsEnum Hospital{ get; set; }

    [Required]
    public DoctorsEnum TreatingDoctor { get; set; }

    [Required]
    public ClaimStatusEnum ClaimStatus { get; set; }

    [Required]
    [MaxLength(100)]
    public string MedicalCase { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [MaxLength(300)]
    public string? Remarks { get; set; }
}
