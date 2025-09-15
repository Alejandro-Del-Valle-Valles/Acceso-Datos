using System.Collections.ObjectModel;
using T01_Ejercicios_Manejo_Ficheros.Modelo;

namespace T01_Ejercicios_Manejo_Ficheros.Servicios
{
    internal static class AlumnosService
    {
        /// <summary>
        /// Save (And create if not exists) into "alumnos_edades.csv" all alumnos of the List.
        /// Save their NIA, Name, Surname and Age.
        /// </summary>
        /// <param name="alumnos">List of Alumnos to be saved</param>
        public static void SaveAlumnosWithAges(HashSet<Alumno> alumnos)
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

        /// <summary>
        /// Groups a collection of students by their year of birth.
        /// </summary>
        /// <remarks>This method organizes the provided collection of students into groups based on their
        /// year of birth. Each year is associated with a distinct set of students who share that birth year.</remarks>
        /// <param name="alumnosToProcess">A collection of students to process. Each student must have a valid birth year.</param>
        /// <returns>A dictionary where the keys are birth years and the values are sets of students born in those years.</returns>
        public static Dictionary<int, HashSet<Alumno>> GetDiccionarioAnyosNacimiento(HashSet<Alumno> alumnosToProcess)
        {
            Dictionary<int, HashSet<Alumno>> alumnos = new Dictionary<int, HashSet<Alumno>>();
            foreach(Alumno alumno in alumnosToProcess)
            {
                int year = alumno.BirthDay.Year;
                if (!alumnos.ContainsKey(year)) alumnos[year] = new HashSet<Alumno>();
                alumnos[year].Add(alumno);
            }
            return alumnos;
        }

        public static void SaveListadoEdadesAlumnos(Dictionary<int, HashSet<Alumno>> alumnosToBeSaved)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(DirectoryService.GetFilePath("informe_edades.txt")))
                {
                    foreach(int key in alumnosToBeSaved.Keys)
                    {
                        sw.WriteLine(key);
                        foreach(Alumno alumno in alumnosToBeSaved[key]) sw.Write($"{alumno.Name} {alumno.Surname}, ");
                        sw.WriteLine();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
        }
    }
}
