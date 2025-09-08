using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Base entity class for all domain entities.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Primary key identifier.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Date and time when the record was created.
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// User who created the record.
    /// </summary>
    public required string CreatedBy { get; set; }

    /// <summary>
    /// Date and time when the record was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// User who last updated the record.
    /// </summary>
    public string? UpdatedBy { get; set; }
}
