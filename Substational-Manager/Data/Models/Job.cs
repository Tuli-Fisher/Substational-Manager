using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Substational_Manager.Data.Models;
public enum JobStatus
{
    Scheduled = 0,
    Completed = 1,
    Cancelled = 2
}

public enum Period
{
    none = 0,
    Hebrew = 1,
    English = 2,
    Custom = 4,
    FullDay = 5
}

public class Job
{
    public int Id { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    public Period Period { get; set; }

    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }

    [Required]
    public int SchoolId { get; set; }
    public School School { get; set; } = default!;

    // A job can be unassigned initially
    public int? SubstituteId { get; set; }
    public Substitute? Substitute { get; set; }

    public JobStatus Status { get; set; } = JobStatus.Scheduled;

    [Column(TypeName = "decimal(10,2)")]
    public decimal? PaymentPerHour { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }
}


