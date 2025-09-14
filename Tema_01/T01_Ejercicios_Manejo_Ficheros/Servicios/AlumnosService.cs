using T01_Ejercicios_Manejo_Ficheros.Modelo;

namespace T01_Ejercicios_Manejo_Ficheros.Servicios
{
    internal class AlumnosService
    {
        /// <summary>
        /// Save (And create if not exists) into "alumnos_edades.csv" all alumnos of the List.
        /// Save their NIA, Name, Surname and Age.
        /// </summary>
        /// <param name="alumnos">List of Alumnos to be saved</param>
        public static void SaveAlumnosWithAges(List<Alumno> alumnos)
        {
            string filePath = DirectoryService.GetFilePath("alumnos_edades.csv");
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (Alumno alumno in alumnos)
                    {
                        sw.WriteLine($"{alumno.NIA};{alumno.Name};{alumno.Surname};{alumno.Age};");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El fichero no se ha encontrado. Compruebe que la dirección es correcta.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
        }
    }
}
