using InventarioApp.Infrastructure;
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
Console.WriteLine("\n");

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