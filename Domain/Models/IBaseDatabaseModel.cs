using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public interface IBaseDatabaseModel
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }
}
