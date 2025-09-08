using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Represents an address in the system.
/// </summary>
public class Address : Entity
{
    /// <summary>
    /// Name or label of the address (e.g., Home, Office)
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Street information
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    /// Number
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public int? CityId { get; set; }
    public City? City { get; set; }
}
