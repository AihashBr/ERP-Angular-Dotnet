using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Representa uma cidade no sistema / Represents a city in the system.
/// </summary>
public class City : Entity
{
    /// <summary>
    /// Nome da cidade / Name of the city
    /// </summary>
    [MaxLength(200)]
    public required string Name { get; set; }

    /// <summary>
    /// Estado ou província / State or province
    /// </summary>
    [MaxLength(200)]
    public required string State { get; set; }
}
