using System.ComponentModel.DataAnnotations;

namespace Substational_Manager.Data.Models;
public class School
{
    public int Id { get; set; }

    [Required, MaxLength(160)]
    public string Name { get; set; } = default!;

    [MaxLength(240)]
    public string? Address { get; set; }

    [MaxLength(120)]
    public string? ContactPerson { get; set; }

    [Phone, MaxLength(40)]
    public string? Phone { get; set; }

    [EmailAddress, MaxLength(200)]
    public string? Email { get; set; }

    //dont think its needed
    //public ICollection<Job> Jobs { get; set; } = new List<Job>();
}
