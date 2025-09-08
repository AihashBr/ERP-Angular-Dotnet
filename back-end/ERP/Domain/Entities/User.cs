using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Represents a system user.
/// </summary>
public class User : Entity
{
    /// <summary>
    /// Full name of the user.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// User's email (optional).
    /// </summary>
    [EmailAddress]
    public string? Email { get; set; }

    /// <summary>
    /// User's password (hashed).
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Indicates if the user is active.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// IDs of the companies the user belongs to.
    /// </summary>
    public required List<int> CompanyId { get; set; }
}