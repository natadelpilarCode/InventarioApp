namespace InventarioApp.Models;

/// <summary>
/// Record inmutable para representar proveedores.
/// Utilizado para ilustrar records en el curso.
/// </summary>

public record Proveedor
(
    int Id,
    string Nombre,
    string Email,
    string Telefono
);