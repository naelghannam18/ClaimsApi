using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models;
[Table("Insured")]
[Index(nameof(Id))]
public class Insured : IBaseDatabaseModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [Required]
    [MaxLength(16)]
    public string CardNumber { get; set; } = GeneratedCardNumber();

    [Required]
    [MaxLength(50)]
    public string InsuredName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public GenderEnum Gender { get; set; }

    private static string GeneratedCardNumber()
    {
        var rand = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringBuilder = new StringBuilder(16);

        for (int i = 0; i < 16; i++)
        {
            stringBuilder.Append(chars[rand.Next(chars.Length)]);
        }

        return stringBuilder.ToString();
    }
}
