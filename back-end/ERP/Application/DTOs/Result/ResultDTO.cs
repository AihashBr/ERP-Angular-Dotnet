using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Result;


/// <summary>
/// Representa o resultado de uma operação genérica.
/// </summary>
/// <typeparam name="T">Tipo de dado retornado pela operação.</typeparam>
public class ResultDTO<T>
{
    /// <summary>
    /// Indica se a operação foi bem-sucedida.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Mensagem adicional sobre o resultado da operação.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Dados retornados pela operação, se houver.
    /// </summary>
    public T? Data { get; set; }
}
