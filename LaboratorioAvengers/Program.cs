using System;
using System.IO; 

class Program
{
    static void Main()
    {
        //ruta principal del archivo
        string rutaArchivo = "C:\\Usuarios\\PC\\Documents\\INVENTOS.TXT";

        //si el archivo existe
        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("El archivo no existe. ¿Desea crearlo? (si/Nop)");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta == "si")
            {
                try
                {
                    File.Create(rutaArchivo).Close(); //Crear el archivo
                    Console.WriteLine("Archivo creado exitosamente.");
                }
                catch (Exception)
                {
                    Console.WriteLine("¡Ultron te ha hackeado! Error al crear el archivo.");
                }
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
                return;
            }
        }

        //menú
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Agregar texto");
        Console.WriteLine("2. Leer archivo");
        Console.WriteLine("3. Mover archivo");
        Console.WriteLine("4. Eliminar archivo");
        Console.WriteLine("5. Copiar archivo");

        int opcion;
        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("¡Ultron te ha hackeado! Opción inválida.");
            return;
        }

        try
        {
            switch (opcion)
            {
                case 1:
                    AgregarTexto(rutaArchivo);
                    break;
                case 2:
                    LeerLineaPorLinea(rutaArchivo);
                    break;
                case 3:
                    Console.WriteLine("Ingrese la nueva ruta:");
                    string nuevaRuta = Console.ReadLine();
                    MoverArchivo(rutaArchivo, nuevaRuta);
                    break;
                case 4:
                    EliminarArchivo(rutaArchivo);
                    break;
                case 5:
                    Console.WriteLine("Ingrese la ruta de destino para la copia:");
                    string destinoCopia = Console.ReadLine();
                    CopiarArchivo(rutaArchivo, destinoCopia);
                    break;
                default:
                    Console.WriteLine("¡Ultron te ha hackeado! Opción no válida.");
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("¡Ultron te ha hackeado! YA VALIO QUESO");
        }
    }

    static void AgregarTexto(string rutaArchivo)
    {
        try
        {
            Console.WriteLine("Escribe el texto que deseas agregar :");
            string nuevoTexto = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(rutaArchivo, true)) // 'true' indica que no se sobrescribe el archivo
            {
                sw.WriteLine(nuevoTexto);
            }

            Console.WriteLine("Texto agregado exitosamente.");
        }
        catch (Exception)
        {
            Console.WriteLine("¡Ultron te ha hackeado! Error al agregar texto.");
        }
    }

    static void LeerLineaPorLinea(string rutaArchivo)
    {
        try
        {
            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    Console.WriteLine(linea);
                }
            }
            else
            {
                Console.WriteLine("¡Ultron te ha hackeado! El archivo no existe.");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("¡Ultron te ha hackeado! Error al leer el archivo.");
        }
    }

    static void MoverArchivo(string origen, string destino)
    {
        try
        {
            if (File.Exists(origen))
            {
                File.Move(origen, destino);
                Console.WriteLine("traslado exitosamente.");
            }
            else
            {
                Console.WriteLine("¡Ultron te ha hackeado! El archivo de origen no existe.");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("¡Ultron te ha hackeado! Error al mover el archivo.");
        }
    }

    static void EliminarArchivo(string rutaArchivo)
    {
        try
        {
            if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
                Console.WriteLine("depuració n exitosamente.");
            }
            else
            {
                Console.WriteLine("¡Ultron te ha hackeado! El archivo no existe.");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("¡Ultron te ha hackeado! Error al eliminar el archivo.");
        }
    }

    static void CopiarArchivo(string origen, string destino)
    {
        try
        {
            string directorioDestino = Path.GetDirectoryName(destino);

            if (!Directory.Exists(directorioDestino))
            {
                Directory.CreateDirectory(directorioDestino);
                Console.WriteLine("Carpeta de destino creada exitosamente.");
            }

            if (File.Exists(origen))
            {
                File.Copy(origen, destino, true);
                Console.WriteLine("Archivo copiado exitosamente.");
            }
            else
            {
                Console.WriteLine("¡Ultron te ha hackeado! El archivo de origen no existe.");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("¡Ultron te ha hackeado! RAPIDO BORRA TU HISTORIAL ANTES QUE LO PUBLIQUE EN X");
        }
    }
}
