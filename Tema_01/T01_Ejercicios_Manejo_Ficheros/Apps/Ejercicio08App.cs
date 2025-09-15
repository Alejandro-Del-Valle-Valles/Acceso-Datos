using T01_Ejercicios_Manejo_Ficheros.Modelo;
using T01_Ejercicios_Manejo_Ficheros.Repositorio;
using T01_Ejercicios_Manejo_Ficheros.Servicios;

namespace T01_Ejercicios_Manejo_Ficheros.Apps
{
    internal class Ejercicio08App
    {
        public static void Start()
        {
            HashSet<Alumno> alumnos = AlumnosRepositorio.GetAlumnos(DirectoryService.GetFilePath("alumnos.txt"));
            AlumnosService.SaveAlumnosWithAges(alumnos);
            AlumnosService.SaveListadoEdadesAlumnos(AlumnosService.GetDiccionarioAnyosNacimiento(alumnos));
        }
    }
}
