namespace InventarioApp.Models;

/// <summary>
/// Ciclo de vida de un producto en el inventario
/// </summary>

public enum EstadoProducto
{
    /// <summary> Disponible para la venta </summary>
    Activo,
    /// <summary> Temporalmente fuera de disponibilidad </summary>
    Inactivo,
    /// <summary> Retirado permanentemente del catálogo </summary>
    Descontinuado
}