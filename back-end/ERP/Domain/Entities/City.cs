namespace Domain.Entities;

/// <summary>
/// Representa uma cidade no sistema / Represents a city in the system.
/// </summary>
public class City : Entity
{
    /// <summary>
    /// Name of the city
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// State or province
    /// </summary>
    public required string State { get; set; }
}
