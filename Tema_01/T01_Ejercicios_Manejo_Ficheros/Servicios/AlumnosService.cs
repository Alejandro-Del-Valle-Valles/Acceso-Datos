using System.Collections.ObjectModel;
using T01_Ejercicios_Manejo_Ficheros.Modelo;

namespace T01_Ejercicios_Manejo_Ficheros.Servicios
{
    internal static class AlumnosService
    {
        /// <summary>
        /// Save (And create if not exists) into "alumnos_edades.csv" all alumnos of the Collection.
        /// Save their NIA, Name, Surname and Age.
        /// </summary>
        /// <param name="alumnos">Collection of Alumnos to be saved</param>
        public static void SaveAlumnosWithAges(ICollection<Alumno> alumnos)
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
        public static Dictionary<int, ICollection<Alumno>> GetDiccionarioAnyosNacimiento(ICollection<Alumno> alumnosToProcess)
        {
            Dictionary<int, ICollection<Alumno>> alumnos = new Dictionary<int, ICollection<Alumno>>();
            foreach(Alumno alumno in alumnosToProcess)
            {
                int year = alumno.BirthDay.Year;
                if (!alumnos.ContainsKey(year)) alumnos[year] = new HashSet<Alumno>();
                alumnos[year].Add(alumno);
            }
            return alumnos;
        }

        /// <summary>
        /// Saves a list of students grouped by age to a text file.
        /// </summary>
        /// <remarks>The method writes the data to a file named "informe_edades.txt" in the directory
        /// specified by  <see cref="DirectoryService.GetFilePath(string)"/>. Each age group is written on a new line, 
        /// followed by the names and surnames of the students in that group.</remarks>
        /// <param name="alumnosToBeSaved">A dictionary where the key represents the age of the students, and the value is a collection of  <see
        /// cref="Alumno"/> objects corresponding to that age group.</param>
        public static void SaveListadoEdadesAlumnos(Dictionary<int, ICollection<Alumno>> alumnosToBeSaved)
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
