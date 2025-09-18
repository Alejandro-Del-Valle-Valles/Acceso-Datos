using T01_Ejercicios_Manejo_Ficheros.Apps;
using T01_Ejercicios_Manejo_Ficheros.Modelo;
using T01_Ejercicios_Manejo_Ficheros.Repositorio;
using T01_Ejercicios_Manejo_Ficheros.Servicios;

namespace T01_Ejercicios_Manejo_Ficheros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (Alumno alumno in AlumnosRepositorio.GetAlumnos(DirectoryService.GetFilePath("alumnos.txt")))
            {
                Console.WriteLine(alumno);
            }
        }
    }
}
