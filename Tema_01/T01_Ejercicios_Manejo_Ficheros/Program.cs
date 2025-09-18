using T01_Ejercicios_Manejo_Ficheros.Apps;
using T01_Ejercicios_Manejo_Ficheros.Repositorio;
using T01_Ejercicios_Manejo_Ficheros.Servicios;

namespace T01_Ejercicios_Manejo_Ficheros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = DirectoryService.GetFilePath("alumnos.txt");
            var alumnos = AlumnosRepositorio.GetAlumnos(path);
            ExpresionesLambdaApp.GenerateReportByCicle(alumnos);
        }
    }
}
