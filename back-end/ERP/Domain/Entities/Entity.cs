using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Classe base para todas as entidades de domínio.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Identificador da chave primária.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Data e hora em que o registro foi criado.
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Usuário que criou o registro.
    /// </summary>
    [MaxLength(200)]
    public required string CreatedBy { get; set; }

    /// <summary>
    /// Data e hora em que o registro foi atualizado pela última vez.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Usuário que atualizou o registro pela última vez.
    /// </summary>
    [MaxLength(200)]
    public string? UpdatedBy { get; set; }
}
