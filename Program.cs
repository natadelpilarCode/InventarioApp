using InventarioApp.Models;
using InventarioApp.Services;

var servicio = new InventarioService();
bool activo = true;

while (activo)
{
  MostrarMenu();
  string opcion = Console.ReadLine() ?? "";
  switch (opcion)
  {
    case "1":
      AgregarProducto();
      break;
    case "2":
      ListarProductos();
      break;
    case "3":
      BuscarPorId();
      break;
    case "4":
      EliminarProducto();
      break;
    case "5":
      BuscarPorCategoria();
      break;
    case "6":
      MostrarResumen();
      break;
    case "7":
      MostrarStockBajo();
      break;
    case "8":
      MostrarEstadisticas();
      break;
    case "9":
      ExportarCsv();
      break;
    case "10":
      activo = false;
      Console.WriteLine("\n¡Hasta Luego!");
      break;
    default:
      Console.WriteLine("\nOpción no válida");
      break;
  }
}

void MostrarMenu()
{
  Console.WriteLine("\n===SISTEMA DE INVENTARIO===");
  Console.WriteLine("1. Agregar Producto");
  Console.WriteLine("2. Listar Productos");
  Console.WriteLine("3. Buscar Producto Por Id");
  Console.WriteLine("4. Eliminar Producto");
  Console.WriteLine("5. Buscar Producto Por Categoria");
  Console.WriteLine("6. Ver Resumen");
  Console.WriteLine("7. Ver Stock Bajo");
  Console.WriteLine("8. Ver Estadísticas");
  Console.WriteLine("9. Exportar CSV");
  Console.WriteLine("10. Salir");
  Console.WriteLine("\nSelecciona una opción");
}

void AgregarProducto()
{
  Console.WriteLine("\nNombre: ");
  string nombre = Console.ReadLine() ?? "";

  Console.WriteLine("Precio: ");
  decimal precio = decimal.Parse(Console.ReadLine() ?? "0");

  Console.WriteLine("Cantidad: ");
  int cantidad = int.Parse(Console.ReadLine() ?? "0");

  Console.WriteLine("Categorías: Electronica, Ropa, Alimentos, Hogar, Deportes, Libros, Muebles, Otros");
  Console.WriteLine("Categoría: ");
  string categoriaStr = Console.ReadLine() ?? "";

  if(Enum.TryParse<CategoriaProducto>(categoriaStr,true,out var categoria))
  {
    servicio.AgregarProducto(nombre,precio,cantidad,categoria);
    Console.WriteLine("\nProducto agregado exitosamente");
  }
  else
    Console.WriteLine("\nCategoría no válida");
}

void ListarProductos()
{
  var productos = servicio.ObtenerTodosLosProductos();
  if(!productos.Any())
  {
    Console.WriteLine("\nNo hay productos");
    return;
  }

  Console.WriteLine("\n===PRODUCTOS===");
  foreach(var producto in productos)
  {
    Console.WriteLine($"ID: {producto.Id} | {producto.Nombre} | Precio: ${producto.Precio} | Cantidad: {producto.Cantidad} | Total: ${producto.ValorTotal} | {producto.Categoria}");
  }

}

void BuscarPorId()
{
  Console.WriteLine("\nID del producto: ");
  int id = int.Parse(Console.ReadLine() ?? "0");
  var producto = servicio.ObtenerProductoPorId(id);
  if (producto != null)
  {
    Console.WriteLine($"\nID: {producto.Id}");
    Console.WriteLine($"\nNombre: {producto.Nombre}");
    Console.WriteLine($"\nPrecio: ${producto.Precio}");
    Console.WriteLine($"\nCantidad: {producto.Cantidad}");
    Console.WriteLine($"\nValor Total: ${producto.ValorTotal}");
    Console.WriteLine($"\nCategoría: {producto.Categoria}");
  }
  else
    Console.WriteLine("\nProducto no encontrado");
}

void EliminarProducto()
{
  Console.WriteLine("\nID del producto a eliminar: ");
  int id = int.Parse(Console.ReadLine() ?? "0");
  var producto = servicio.ObtenerProductoPorId(id);
  if (producto != null)
  {
    servicio.EliminarProducto(id);
    Console.WriteLine("\nProducto eliminado");    
  }
  else
    Console.WriteLine("\nProducto no encontrado");
}

void BuscarPorCategoria()
{
  Console.WriteLine("Categorías: Electronica, Ropa, Alimentos, Hogar, Deportes, Libros, Muebles, Otros");
  Console.WriteLine("Categoría: ");
  string categoriaStr = Console.ReadLine() ?? "";

  if(Enum.TryParse<CategoriaProducto>(categoriaStr,true,out var categoria))
  {
    var productos = servicio.BuscarPorCategoria(categoria);
    if(!productos.Any())
    {
      Console.WriteLine("\nNo hay productos en esta categoría");
      return;
    }

    Console.WriteLine($"\n===PRODUCTOS EN {categoria}===");
    foreach(var producto in productos)
    {
      Console.WriteLine($"ID: {producto.Id} | {producto.Nombre} | Precio: ${producto.Precio} | Cantidad: {producto.Cantidad}");
    }
  }
  else
    Console.WriteLine("\nCategoría no válida");
}

void MostrarResumen()
{
  var resumen = servicio.GenerarResumen();
  Console.WriteLine($"\n{resumen}");
}

void MostrarStockBajo()
{
  var reporte = servicio.GenerarReporteStockBajo();
  Console.WriteLine($"\n{reporte}");
}

void MostrarEstadisticas()
{
  Console.WriteLine("\n===ESTADÍSTICAS===");
  Console.WriteLine($"\nValor Total del Inventario: ${servicio.ObtenerValorTotalInventario()}");
  Console.WriteLine($"\nPrecio Promedio: ${servicio.ObtenerPrecioPromedio():F2}");
  var masCaro = servicio.ObtenerProductoMasCaro();
  if(masCaro != null)
    Console.WriteLine($"\nProducto más caro: {masCaro.Nombre} (${masCaro.Precio})");
}

void ExportarCsv()
{
  string csv = servicio.ExportarCsv();
  Console.WriteLine($"\n{csv}");
}
/*using InventarioApp.Infrastructure;
using InventarioApp.Models;
using InventarioApp.Factories;


var productos = new List<Producto>
{
  ProductFactory.Crear("Laptop",1200.00m,3,CategoriaProducto.Electronica),  
  ProductFactory.Crear("Camisa",45.00m,15,CategoriaProducto.Ropa),
  ProductFactory.Crear("Arroz",12.00m,50,CategoriaProducto.Alimentos),
  ProductFactory.Crear("Lámpara",35.00m,2,CategoriaProducto.Hogar),
  ProductFactory.Crear("Balón",25.00m,8,CategoriaProducto.Deportes),
  ProductFactory.Crear("Mesa",150.00m,4,CategoriaProducto.Muebles),
};

var generador = new GeneradorReporte(productos);

Console.WriteLine(generador.GenerarResumen());
Console.WriteLine("\n");


Console.WriteLine(generador.GenerarReporteStockBajo());
Console.WriteLine("\n");


Console.WriteLine(generador.GenerarTopProductos());
Console.WriteLine("\n");


Console.WriteLine(generador.ExportarCsv());
Console.WriteLine("\n");


Console.WriteLine(generador.ExportarResumenJson());
Console.WriteLine("\n");*/

/*using InventarioApp.Factories;
using InventarioApp.Models;
using InventarioApp.Repositories;
using InventarioApp.Infrastructure;

Console.WriteLine("====================== Prueba integracion JSON ====================");

var almacenamiento = new JsonInventarioStorage();
var productos = new List<Producto>();
{
    new Producto
    {
      Id = 1,
      Nombre = "Laptop",
      Precio = 999.99m,
      Cantidad = 10,
      Categoria = CategoriaProducto.Electronica,
      Estado = EstadoProducto.Activo  
    };
    new Producto
    {
      Id = 2,
      Nombre = "Camiseta",
      Precio = 19.99m,
      Cantidad = 50,
      Categoria = CategoriaProducto.Ropa,
      Estado = EstadoProducto.Activo  
    };
}
string ruta = "inventario_test.json";
almacenamiento.CrearBackUp(ruta);
almacenamiento.Guardar(productos,ruta);
Console.WriteLine("Inventario guardado correctamente");
var productosCargados = almacenamiento.Cargar(ruta);
Console.WriteLine("Inventario cargado correctamente");

foreach(var p in productosCargados)
{
    Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio}, Cantidad: {p.Cantidad}, Categoria: {p.Categoria}, Estado: {p.Estado}");
}

*/