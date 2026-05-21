using InventarioApp.Factories;
using InventarioApp.Models;
using InventarioApp.Repositories;
using InventarioApp.Infrastructure;

Console.WriteLine("====================== InventarioApp====================");

var fileManager = new Filemanager();
string contenido = "Inventario actualizado";
fileManager.Escribir("inventario.txt", contenido);

string leerContenido = fileManager.Leer("inventario.txt");
Console.WriteLine(contenido);


var repository = new InMemoryProductoRepository();

Producto laptop = ProductFactory.Crear(nombre: "Laptop Dell XPS 13", precio: 1200, cantidad: 5, CategoriaProducto.Electronica);
Producto mouse = ProductFactory.Crear(nombre: "Mouse Logitech MX Master", precio: 99, cantidad: 20, CategoriaProducto.Electronica);
Producto teclado = ProductFactory.Crear(nombre: "Teclado Mecánico", precio: 150, cantidad: 3, CategoriaProducto.Electronica);
Producto silla = ProductFactory.Crear(nombre: "Silla Ergonómica Herman Miller", precio: 500, cantidad: 8, CategoriaProducto.Muebles);
Producto escritorio = ProductFactory.Crear(nombre: "Escritorio Stand-up", precio: 300, cantidad: 2, CategoriaProducto.Muebles);

repository.Agregar(laptop);
repository.Agregar(mouse);
repository.Agregar(teclado);
repository.Agregar(silla);
repository.Agregar(escritorio);

Console.WriteLine($"Productos agregados: {repository.Cantidad}");

IEnumerable<Producto> electronicos = repository.BuscarPorCategoria(CategoriaProducto.Electronica);
Console.WriteLine($"Productos electronicos: {electronicos.Count()}");

foreach (Producto producto in electronicos)
{
    Console.WriteLine($" {producto.Nombre} : {producto.Precio:C2}");
}

IEnumerable<Producto> conMouse = repository.BuscarPorNombre("mouse");
Console.WriteLine($"\nProductos con mouse: {conMouse.Count()}");

foreach (Producto producto in conMouse)
{
    Console.WriteLine($" {producto.Nombre} : {producto.Precio:C2}");
}

IEnumerable<string> nombres = repository.ObtenerNombres();
Console.WriteLine($"\nTodos los nombres de los productos: {string.Join(", ", nombres)}");

bool hayStockBajo = repository.HayStockBajo();
Console.WriteLine($"\nHay stock bajo: {hayStockBajo}");
