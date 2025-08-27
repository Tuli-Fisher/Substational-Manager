using System.ComponentModel.DataAnnotations;

namespace Substational_Manager.Data.Models;


[Flags]
public enum Availability
{
    None = 0,
    AM = 1,
    PM = 2,
    Custom = 4
}
public class Substitute
{
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string FullName { get; set; } = default!;

    [EmailAddress, MaxLength(200)]
    public string? Email { get; set; }

    [Phone, MaxLength(40)]
    public string? Phone { get; set; }

    public bool HasText { get; set; }

    public Availability Availability { get; set; } = Availability.AM | Availability.PM;

    public bool IsActive { get; set; } = true;

    [MaxLength(500)]
    public string? Notes { get; set; }

    // dont think its needed
    //public ICollection<Job> Jobs { get; set; } = new List<Job>();
}



