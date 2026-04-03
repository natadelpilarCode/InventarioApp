// ============================================================
// SISTEMA DE INVENTARIO - Clase 1.1
// Estado: Mensaje de bienvenida
// ============================================================

using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

MostrarBanner();

/* Console.WriteLine("Ingrese un valor: ");
string? entrada = Console.ReadLine();
int? longitud = entrada?.Length;

string comandoLimpio = string.IsNullOrEmpty(entrada) ? "Salir" : entrada.Trim().ToLower();
Console.WriteLine($"Longitud: {longitud?? 0}");
Console.WriteLine($"Comando limpio: {comandoLimpio} "); */



if (args.Length > 0)
{
    switch (args[0].ToLower())
    {
        case "--help":
            MostrarAyuda();
            Environment.Exit(0);
            break;

        case "--version":
            Console.WriteLine($"InventarioApp v[{version}]");
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine($"Error: Comando desconocido '{args[0]}'");
            Console.WriteLine("Use --help para ver los comandos disponibles");
            Environment.Exit(2);
            break;
    }
}

int cantidadProductos = 0;
decimal valorTotalDelInventario = 0.00m;
bool sistemaActivo = true;
string nombreSistema = "Sistema de Gestión de Inventario";


Console.WriteLine("Estado del Sistema");
Console.WriteLine($"Nombre: {nombreSistema}");
Console.WriteLine($"Productos registrados: {cantidadProductos}");
Console.WriteLine($"Valor total del inventario: {valorTotalDelInventario:N2}");
Console.WriteLine($"Sistema activo: {(sistemaActivo ? "Si" : "No")}");

Console.WriteLine("Comandos: Listar, Agregar, Buscar, Salir");
Console.WriteLine();

while (sistemaActivo)
{
    Console.WriteLine("Inventario: ");
    string? entrada = Console.ReadLine();

    string comando = String.IsNullOrEmpty(entrada) ? "salir" : entrada.Trim().ToLower();
    Console.WriteLine($"Comando recibido: {comando}");
    switch (comando)
    {
        case "salir":
            sistemaActivo = false;
            Console.WriteLine("Hasta Luego");
            break;

        case "listar":
            Console.WriteLine($"Productos de inventario: {cantidadProductos}");
            break;
        
        case "":
            break;
        
        default:
            Console.WriteLine($"Comando '{comando}' no reconocido");
            Console.WriteLine("Comandos disponibles: Listar, Agregar, Buscar, Salir");
            break;
    }

}


/* Console.WriteLine("Ingrese una cantidad:");
string? entradaCantidad = Console.ReadLine();

//Conversión segura TryParse
if(int.TryParse(entradaCantidad,out int cantidad))
{
    Console.WriteLine($"Cantidad valida: {cantidad}");
    cantidadProductos = cantidad;
}
else
{
    Console.WriteLine("Error debe ingresar un número entero"); 
}

Console.WriteLine("Ingrese un precio: ");
string? entradaPrecio = Console.ReadLine();

if(decimal.TryParse(entradaPrecio, out decimal precio2))
{
    Console.WriteLine($"Precio valido: {precio2}");
    valorTotalDelInventario = cantidadProductos * precio2;
    Console.WriteLine($"Valor total del inventario actualizado: {valorTotalDelInventario:N2}");
}
else
{
    Console.WriteLine("Error debe ingresar un número decimal"); 
} */

//Modo interactivo si no hay argumentos

/* Console.Write("Ingrese un comando (o 'salir' para terminar): ");
string? entrada = Console.ReadLine();

if(String.IsNullOrEmpty(entrada) || entrada.ToLower() == "salir")
{
    Console.WriteLine("Hasta Luego");
    Environment.Exit(0);
}
Console.WriteLine("Estructura del Proyecto:");
Console.WriteLine(" InventarioApp");
Console.WriteLine("   |-- Program.cs");
Console.WriteLine("   |-- InventarioApp.csproj");
Console.WriteLine("   |-- .gitignore");
Console.WriteLine("   |-- README.md");
Console.WriteLine("   |-- src/");
Console.WriteLine("       |-- Models/");
Console.WriteLine("Configuración .csproj");
Console.WriteLine("Carpeta src/ creada");
Console.WriteLine("Medadatos configurados");
Console.WriteLine();
Console.WriteLine("Próximo paso: Checkpoint"); */

// ============== FUNCIONES ========================
void MostrarBanner()
{
    Console.WriteLine("==========================================");
    Console.WriteLine("    SISTEMA DE GESTIÓN DE INVENTARIO      ");
    Console.WriteLine("==========================================");
    Console.WriteLine();
    Console.WriteLine($"Versión: {version}");
    Console.WriteLine($"Plataforma: {Environment.OSVersion}");
    Console.WriteLine($".NET Version: {Environment.Version}");
    Console.WriteLine();
}

void MostrarAyuda()
{
    Console.WriteLine("USO: InventarioApp [comando] [opciones]");
    Console.WriteLine();
    Console.WriteLine("COMANDOS:");
    Console.WriteLine("  --help, -h      Muestra esta ayuda");
    Console.WriteLine("  --version, -v   Muestra la version del programa");
    Console.WriteLine();
    Console.WriteLine("EJEMPLOS:");
    Console.WriteLine(" dotnet run -- --help");
    Console.WriteLine(" dotnet run -- --version");
}