using T01_Ejercicios_Manejo_Ficheros.Repositorio;
using T01_Ejercicios_Manejo_Ficheros.Servicios;

namespace T01_Ejercicios_Manejo_Ficheros.Apps
{
    internal static class Ejercicio11App
    {
        public static void start()
        {
            string path = DirectoryService.GetFilePath("alumnos.txt");
            var dictionaryAlumnos = AlumnosService.GetDiccionarioAnyosNacimiento(AlumnosRepositorio.GetAlumnos(path));
            AlumnosService.SaveListadoEdadesAlumnos(dictionaryAlumnos);
        }
    }
}
