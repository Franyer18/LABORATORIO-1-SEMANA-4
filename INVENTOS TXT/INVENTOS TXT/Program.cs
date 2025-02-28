using System;
using System.IO;

class Program
{
    // SE ALMACENARAN LOS NOMBRES DE LAS VARIABLES.
    static string archivo = "inventos.txt";
    static string backupDir = "Backup";
    static string clasificadosDir = "ArchivosClasificados";
    static string proyectosDir = "ProyectosSecretos";
    static string laboratorioDir = "LaboratorioAvengers";

    static void Main()
    {
        while (true) // BUCLE INFINITO QUE SE REPETIRA ASTA QUE EL USUARIO SE SALGA.
        {

            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Crear archivo");
            Console.WriteLine("2. Agregar invento");
            Console.WriteLine("3. Leer línea por línea");
            Console.WriteLine("4. Leer todo el texto");
            Console.WriteLine("5. Copiar archivo");
            Console.WriteLine("6. Mover archivo");
            Console.WriteLine("7. Crear carpeta");
            Console.WriteLine("8. Listar archivos");
            Console.WriteLine("9. Eliminar archivo");
            Console.WriteLine("10. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine(); // SE ANALISARA LA OPCION INGRESADA POR EL USUARIO.

            // SWITCH SE ENCARGARA DE EJECTUTAR EL METODO INGRESADO
            switch (opcion)
            {
                case "1":
                    Console.WriteLine("\nCreando archivo...");
                    CrearArchivo(); // LLAMARA AL METODO QUE CREA LA VARIABLE.
                    break;
                case "2":
                    Console.Write("Ingrese el nombre del invento: ");
                    string invento = Console.ReadLine();
                    Console.WriteLine("\nAgregando invento...");
                    AgregarInvento(invento); // Llama al método que agrega un invento al archivo.
                    break;
                case "3":
                    Console.WriteLine("\nLeyendo el archivo línea por línea...");
                    LeerLineaPorLinea(); // Llama al método que lee línea por línea.
                    break;
                case "4":
                    Console.WriteLine("\nLeyendo todo el contenido del archivo...");
                    LeerTodoElTexto(); // Llama al método que lee todo el texto.
                    break;
                case "5":
                    Console.WriteLine("\nCopiando archivo...");
                    CopiarArchivo(backupDir); // Llama al método que copia el archivo.
                    break;
                case "6":
                    Console.WriteLine("\nMoviendo archivo...");
                    MoverArchivo(clasificadosDir); // Llama al método que mueve el archivo.
                    break;
                case "7":
                    Console.WriteLine("\nCreando carpeta...");
                    CrearCarpeta(proyectosDir); // Llama al método que crea una carpeta.
                    break;
                case "8":
                    Console.WriteLine("\nListando archivos en 'LaboratorioAvengers'...");
                    ListarArchivos(laboratorioDir); // Llama al método que lista archivos en un directorio.
                    break;
                case "9":
                    Console.WriteLine("\nEliminando archivo...");
                    EliminarArchivo(); // Llama al método que elimina un archivo.
                    break;
                case "10":
                    Console.WriteLine("\nSaliendo del programa...");
                    return; // Finaliza el programa saliendo del bucle.
                default:
                    Console.WriteLine("\nOpción no válida."); // Mensaje de error para opciones inválidas.
                    break;
            }
        }
    }

    // Método que crea un archivo.
    static void CrearArchivo()
    {
        try
        {
            // Verifica si el archivo ya existe para evitar sobrescribirlo.
            if (!File.Exists(archivo))
            {
                // Si no existe, lo crea con contenido predeterminado.
                File.WriteAllText(archivo, "1. Traje Mark I\n2. Reactor Arc\n3. Inteligencia Artificial JARVIS\n");
                Console.WriteLine("Archivo creado exitosamente.");
            }
            else
            {
                Console.WriteLine("El archivo ya existe."); // Informa si el archivo ya está presente.
            }
        }
        catch (Exception e) // Atrapa errores si fallan las operaciones con archivos.
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    // Método que agrega un invento al archivo sin borrar el contenido existente.
    static void AgregarInvento(string invento)
    {
        try
        {
            // Agrega el invento al final del archivo.
            File.AppendAllText(archivo, invento + "\n");
            Console.WriteLine("Invento agregado correctamente.");
        }
        catch (Exception e) // Captura y maneja errores durante la escritura.
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    // Método que lee el archivo línea por línea (útil para archivos grandes).
    static void LeerLineaPorLinea()
    {
        try
        {
            foreach (string linea in File.ReadLines(archivo))
            {
                Console.WriteLine(linea);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    // Método que lee todo el contenido del archivo de una vez.
    static void LeerTodoElTexto()
    {
        try
        {
            Console.WriteLine(File.ReadAllText(archivo)); // Imprime todo el contenido.
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    // Método que copia el archivo a una carpeta de destino.
    static void CopiarArchivo(string destino)
    {
        try
        {
            if (File.Exists(archivo)) // Verifica si el archivo existe antes de copiarlo.
            {
                Directory.CreateDirectory(destino); // Asegura que la carpeta destino exista.
                File.Copy(archivo, Path.Combine(destino, Path.GetFileName(archivo)), true); //  PATH COPIA EL ARCHIVO.
                Console.WriteLine("Archivo copiado correctamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo no existe.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    // Método que mueve el archivo a otra carpeta.
    static void MoverArchivo(string destino)
    {
        try
        {
            if (File.Exists(archivo)) // Verifica si el archivo existe.
            {
                Directory.CreateDirectory(destino); // Asegura que la carpeta destino exista.
                File.Move(archivo, Path.Combine(destino, Path.GetFileName(archivo))); // Mueve el archivo.
                Console.WriteLine("Archivo movido correctamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo no existe.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    // Método que crea una nueva carpeta.
    static void CrearCarpeta(string nombreCarpeta)
    {
        try
        {
            Directory.CreateDirectory(nombreCarpeta); // Crea la carpeta.
            Console.WriteLine($"Carpeta '{nombreCarpeta}' creada exitosamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    // Método que lista todos los archivos en una carpeta específica.
    static void ListarArchivos(string ruta)
    {
        try
        {
            if (Directory.Exists(ruta)) // Verifica que la carpeta exista.
            {
                string[] archivos = Directory.GetFiles(ruta); // Obtiene todos los archivos en la carpeta.
                if (archivos.Length > 0)
                {
                    Console.WriteLine("Archivos en la carpeta:");
                    foreach (string archivo in archivos)
                    {
                        Console.WriteLine(Path.GetFileName(archivo)); // Muestra solo los nombres de los archivos.
                    }
                }
                else
                {
                    Console.WriteLine("No hay archivos en la carpeta."); // Informa si no hay archivos.
                }
            }
            else
            {
                Console.WriteLine("Error: La carpeta no existe.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    // Método que elimina un archivo específico.
    static void EliminarArchivo()
    {
        try
        {
            if (File.Exists(archivo)) // Verifica que el archivo exista.
            {
                File.Delete(archivo); // Elimina el archivo.
                Console.WriteLine("Archivo eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo no existe.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
